using Microsoft.AspNetCore.Mvc;

namespace ApiIBGE.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TesteController : ControllerBase
    {
        [HttpGet]
        public string TesteApi()
        {
            return "TESTEAPI";
        }

    }
}
