using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Threading.Tasks;
using UserManagement.Core.Exceptions;
using UserManagement.Models;
using UserManagement.Models.Responses;

namespace UserManagement.Core.Helpers
{
    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                var response = context.Response;
                response.ContentType = "application/json";

                switch (error)
                {
                    case UserInvalidDataException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    case DataNotFoundException e:
                        response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case PermissionAlreadyAssignedException e:
                        response.StatusCode = (int)HttpStatusCode.BadRequest;
                        break;
                    default:
                        // unhandled error
                        response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        break;
                }

                var result = JsonConvert.SerializeObject(new UserManagementResponse<User>
                {
                    Success = false,
                    ErrorMessage = error.Message,
                });

                await response.WriteAsync(result);
            }
        }
    }
}
