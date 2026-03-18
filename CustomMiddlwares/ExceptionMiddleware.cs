namespace Fiscalizator.CustomMidlwares
{
    public class ExceptionMiddleware 
    {
        private readonly RequestDelegate _next;
        public ExceptionMiddleware(RequestDelegate next)
        {
            _next = next;
        }
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch(Exception ex)
            {
                await Handle(context, ex);
            }
        }
        private static async Task Handle(HttpContext context, Exception ex)
        {
            context.Response.ContentType = "application/json";

            var statusCode = ex switch
            {
                UnauthorizedAccessException => StatusCodes.Status403Forbidden,
                _ => StatusCodes.Status500InternalServerError
            };

            context.Response.StatusCode = statusCode;
            Console.WriteLine(ex.Message + "\n");
            Console.WriteLine(ex.StackTrace + "\n");
            Console.WriteLine(ex.Source + "\n");
            var response = new
            {
                status = statusCode,
                message = ex.Message
            };

            await context.Response.WriteAsJsonAsync(response);
        }
    }
}
