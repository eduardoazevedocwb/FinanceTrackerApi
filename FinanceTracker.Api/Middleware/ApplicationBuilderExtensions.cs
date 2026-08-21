namespace FinanceTracker.Api.Middleware
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseGlobalExceptionHandling(this IApplicationBuilder app) 
        {
            return app.UseMiddleware<ExceptionHandlingMiddleware>();
        }
    }
}
