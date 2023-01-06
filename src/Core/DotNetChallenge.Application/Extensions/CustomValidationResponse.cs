using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetChallenge.Application.Wrappers;

namespace DotNetChallenge.Application.Extensions
{
    public static class CustomValidationResponse
    {
        public static void AddCustomValidationResponse(this IServiceCollection services)
        {
            services.Configure<ApiBehaviorOptions>(opt =>
            {
                opt.InvalidModelStateResponseFactory = context =>
                {
                    var errors = context.ModelState.Values.Where(x => x.Errors.Count > 0).SelectMany(x => x.Errors)
                        .Select(x => x.ErrorMessage).ToList();
                    CustomError customError = new CustomError(errors, true);
                    var response = CustomResponse<CustomNoContent>.Fail(customError, 400);
                    return new BadRequestObjectResult(response)
                    {
                        StatusCode = response.StatusCode
                    };
                };
            });
        }
    }
}
