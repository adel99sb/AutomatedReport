using Microsoft.AspNetCore.Mvc;

namespace AutomatedReportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [ApiExplorerSettings(GroupName = "v2")]
    public class MessagesController : ControllerBase
    {
        //private readonly WhatsAppService whatsAppService;        
       // private readonly IClassRepository classRepository;
        //private readonly IBackgourndJobService backgourndJobService;
        private readonly ILogger<MessagesController> _logger;

        public MessagesController(
            ILogger<MessagesController> logger
            //WhatsAppService whatsAppService,
            //IClassRepository classRepository,
            /*IBackgourndJobService backgourndJobService*/)
        {
            _logger = logger;
            //this.whatsAppService = whatsAppService;
            //this.classRepository = classRepository;
            /*this.backgourndJobService = backgourndJobService*/;
        }
        [HttpGet("GetAllPhoneNumbers")]
        public async Task<IActionResult> GetAllPhoneNumbers()
        {
            return Ok();
        }        
        [HttpGet("GetTodayBirthDayNumbers")]
        public async Task<IActionResult> GetTodayBirthDayNumbers()
        {
            return Ok();
        }
    }    
}