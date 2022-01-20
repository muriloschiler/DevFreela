using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DevFreela.API.Filters
{
    public class ValidatorFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            throw new System.NotImplementedException();
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if(!context.ModelState.IsValid){
                var messages = context.ModelState
                                .SelectMany(ms=>ms.Value.Errors)
                                .Select(err => err.ErrorMessage)
                                .ToList();
                context.Result= new BadRequestObjectResult(messages);
            }
        }
    }
}