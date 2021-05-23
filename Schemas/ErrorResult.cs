using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClientsApi.Schemas
{
    public class ErrorResult : IActionResult
    {
        public Task ExecuteResultAsync(ActionContext context)
        {
            var modelStateEntries = context.ModelState.Where(e => e.Value.Errors.Count > 0).ToArray();
            var errors = new List<ErrorMessage>();

            if (modelStateEntries.Any())
            {
                foreach (var modelStateEntry in modelStateEntries)
                {
                    foreach (var modelStateError in modelStateEntry.Value.Errors)
                    {
                        var error = new ErrorMessage
                        {
                            Validation = "ParsingValidator",
                            Field = modelStateEntry.Key.Substring(2),
                            Message = modelStateError.ErrorMessage
                        };

                        errors.Add(error);
                    }
                }
            }

            var problemDetails = new Error
            {
                Code = 422,
                Key = "VALIDATION_ERROR",
                Messages = errors
            };

            context.HttpContext.Response.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
            context.HttpContext.Response.WriteAsJsonAsync(problemDetails);
            return Task.CompletedTask;
        }
    }
}