using Microsoft.AspNetCore.Mvc.Filters;

namespace PaymentMethodStudy.WebAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // This might only work with MVC, requests through swagger does not drop here. I will leave it as it is for future use.

            if (!context.ModelState.IsValid)
            {
                Console.WriteLine("hey");
                return;
            }

            await next();
        }
    }
}
