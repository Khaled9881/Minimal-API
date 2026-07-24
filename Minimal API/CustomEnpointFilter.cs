namespace Minimal_API
{
    public class CustomEnpointFilter : IEndpointFilter
    {
        private readonly ILogger<CustomEnpointFilter> logger;

        public CustomEnpointFilter(ILogger<CustomEnpointFilter> logger)
        {
            this.logger = logger;
        }

        public ValueTask<object?> InvokeAsync(EndpointFilterInvocationContext context, EndpointFilterDelegate next)
        {

            logger.LogInformation("it is before");

            var result = next(context);

            logger.LogInformation("it is after");
            return result;
        }
    }
}
