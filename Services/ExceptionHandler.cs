using System.Linq;
using System.Net;
using System.Text.Json;
using ClientsApi.Schemas;
using FluentValidation;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;

namespace ClientsApi.Services
{
    public static class ExceptionHandler
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    if (contextFeature.Error is ValidationException validationException)
                    {
                        var response = HandleError(validationException, context);
                        if (response != null)
                        {
                            await context.Response.WriteAsJsonAsync(response);
                        }
                    }
                });
            });
        }

        private static Error HandleError(ValidationException validationException, HttpContext context)
        {
            context.Response.StatusCode = (int) HttpStatusCode.UnprocessableEntity;
            var errors = validationException.Errors
                .Select(x => new ErrorMessage
                {
                    Field = x.PropertyName,
                    Message = x.ErrorMessage,
                    Validation = x.ErrorCode
                })
                .ToArray();
            
            return new Error
            {
                Code = 422,
                Key = "VALIDATION_ERROR",
                Messages = errors
            };
        }
    }
}