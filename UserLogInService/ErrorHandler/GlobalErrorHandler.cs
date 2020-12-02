using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace UserLogInService.ErrorHandler
{
    public static class GlobalErrorHandle
    {
        public static void GobalErrorhandler(this IApplicationBuilder app, int StatusCode = 0, string message = "")
        {
            app.UseExceptionHandler(
                                 options =>
                                 {
                                     options.Run(
                                     async context =>
                                     {
                                         context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                                         context.Response.ContentType = "text/html";
                                         var ex = context.Features.Get<IExceptionHandlerFeature>();
                                         if (ex != null)
                                         {
                                             var err = $"<h1>Error: {ex.Error.Message}</h1>{ex.Error.StackTrace}";
                                             await context.Response.WriteAsync(new Exception()
                                             {
                                                 StatusCode = context.Response.StatusCode,
                                                 Message = "Internal Server Error."
                                             }.ToString());
                                         }
                                     });
                                 }
                            );
        }
    }
}
