using ApiIBGE.Models;
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
            ibge _ibge= new ibge();
            _ibge.city = "OSASCO";
            _ibge.state = "SP";

            using (var db = new DemoContext())
            {
                db.Add(_ibge);
                db.SaveChanges();
            }
            return "TESTEAPI";
        }

    }
}
