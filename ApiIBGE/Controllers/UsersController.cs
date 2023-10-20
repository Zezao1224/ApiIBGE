using ApiIBGE.Data;
using ApiIBGE.Models;
using ApiIBGE.util;
using ApiIBGE.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace ApiIBGE.Controllers
{
    /// <summary>
    /// Controlador de usuários
    /// </summary>
    [ApiController]
    [Route(template: "v1")]
    public class UsersController : ControllerBase
    {
        private AppDbContext _context;
        private IConfiguration _config;

        /// <summary>
        /// Controlador de usuários com o contexto de banco de dados e configuration
        /// </summary>
        /// <param name="context"></param>
        /// <param name="Configuration"></param>
        public UsersController(AppDbContext context, IConfiguration Configuration)
        {
            _context = context;
            _config = Configuration;
        }

        /// <summary>
        /// POST para criar um usuário, baseado no e-mail e senha.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(template: "CreateUser")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUsersViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Users user = new Users()
            {
                Email = model.Email,
                Password = model.Password
            };

            try
            {
       
                if (ClsUtil.ValidaEmail(user.Email!) != true)
                {
                    return NotFound();
                }

                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created(uri: $"v1/user/{user.id}", user);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }

        /// <summary>
        /// GET para localizar um usuário cadastrado através do e-mail e senha.
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route(template: "Login")]
        public async Task<IActionResult> GetByIdAsync([FromBody] CreateUsersViewModel model)
        {
            var user = await _context.users.AsNoTracking().FirstOrDefaultAsync(x=> x.Password == model.Password &&
                                                                                   x.Email==model.Email );

            var key = _config["Jwt:Key"];              

            if (user == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(ClsUtil.GerarTokenJWT(key!));
            }
        }
    }
}
