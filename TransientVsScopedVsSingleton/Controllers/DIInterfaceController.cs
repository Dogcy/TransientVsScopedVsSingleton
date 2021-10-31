using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TransientVsScopedVsSingleton.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DIInterfaceController : ControllerBase
    {
        private readonly IFuncDemo _demo;
        public DIInterfaceController(IFuncDemo funcDemo)
        {
            
            this._demo = funcDemo;
        }
        [HttpGet]
        public string GET()
        {
            return _demo.Demo();
        }
    }
}
