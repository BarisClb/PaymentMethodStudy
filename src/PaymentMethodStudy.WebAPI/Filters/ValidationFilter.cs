using Microsoft.AspNetCore.Mvc.Filters;

namespace PaymentMethodStudy.WebAPI.Filters
{
    public class ValidationFilter : IAsyncActionFilter
    {
        private readonly ILogger<ValidationFilter> _logger;

        public ValidationFilter(ILogger<ValidationFilter> logger)
        {
            _logger = logger;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            // This might only work with MVC, requests through swagger does not drop here. I will leave it as it is for future use.
            // It works with HttpGet, need to look into it more.
            // It works with HttpPost too, after model passes the FluentValidation.

            // Not sure how to use this part, need more learning.

            if (!context.ModelState.IsValid)
            {
                _logger.LogError("Model state is not valid.");
                return;
            }

            await next();
        }
    }
}
