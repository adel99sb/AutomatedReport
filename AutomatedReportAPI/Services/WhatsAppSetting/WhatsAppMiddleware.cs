namespace AutomatedReportAPI.Services.WhatsAppSetting
{
    public class WhatsAppMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly WhatsAppService _whatsAppService;

        public WhatsAppMiddleware(RequestDelegate next, WhatsAppService whatsAppService)
        {
            _next = next;
            _whatsAppService = whatsAppService;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            //uncomment for production
            if (!_whatsAppService.isReadyToRun())
            {
                context.Response.StatusCode = 503; // Service Unavailable
                await context.Response.WriteAsync("<h1>WhatsApp Service is not ready to run.</h1>");
                return;
            }
            await _next(context);
        }
    }
}
