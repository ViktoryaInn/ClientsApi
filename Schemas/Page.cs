using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Threading.Tasks;
using ClientsApi.Attributes;
using ClientsApi.Enums;
using ClientsApi.Interfaces;
using ClientsApi.Services;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;

namespace ClientsApi.Schemas
{
    public class Page<T>
    {
        public int Total { get; set; }
        public int PageNumber { get; set; }
        public int PerPage { get; set; }
        public int LastPage { get; set; }
        public IEnumerable<T> Data { get; set; }

        private Page()
        {
        }

        public static async Task<Page<T>> Create(PageInfo info, IQueryable<T> data)
        {
            var page = new Page<T>
            {
                PerPage = info.Limit,
                PageNumber = info.Page
            };

            info.SortBy = info.SortBy.Capitalize();

            if (!string.IsNullOrEmpty(info.Query))
            {
                var search = typeof(T).GetProperties()
                    .Where(prop => prop.GetCustomAttributes(false).Any(attr => attr is SearcherAttribute))
                    .Where(prop => prop.PropertyType == typeof(string))
                    .Select(it => it.Name)
                    .ToArray();

                if (search.Length > 0)
                {
                    var x = Expression.Parameter(typeof(T), "x");
                    Expression call = Expression.Constant(false);
                    var contains = typeof(string).GetMethod("Contains", new[] {typeof(string)});
                    var query = Expression.Constant(info.Query);

                    call = search.Aggregate(call,
                        (current, s) => Expression.OrElse(current,
                            Expression.Call(Expression.MakeMemberAccess(x, typeof(T).GetProperty(s)!),
                                contains!, query)));

                    var expr = Expression.Lambda<Func<T, bool>>(call, x);

                    data = data.Where(expr);
                }
            }

            page.Total = await data.CountAsync();
            page.LastPage = (int) Math.Ceiling((decimal) page.Total / page.PerPage);

            if (!typeof(T).GetProperties()
                .Where(prop => prop.GetCustomAttributes(false).Any(attr => attr is SorterAttribute))
                .Select(it => it.Name)
                .Contains(info.SortBy))
            {
                throw new ValidationException("Wrong sorter",
                    new[] {new ValidationFailure(info.SortBy, "Wrong sorter")});
            }

            data = info.SortDir == SortingDirection.Asc
                ? data.OrderBy(it => EF.Property<IComparable>(it, info.SortBy))
                : data.OrderByDescending(it => EF.Property<IComparable>(it, info.SortBy));


            page.Data = await data
                .Skip(info.Limit * (info.Page - 1))
                .Take(info.Limit)
                .ToArrayAsync();

            return page;
        }
    }
}