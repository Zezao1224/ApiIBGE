using ApiIBGE.Data;
using ApiIBGE.Models;
using ApiIBGE.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ApiIBGE.Controllers
{
    [ApiController]
    [Route(template: "v1")]
    public class UsersController : ControllerBase
    {
        private AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        [Route(template: "CreateUser")]
        public async Task<IActionResult> PostAsync([FromBody] CreateUsersViewModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            Users user = new Users
            {
                Email = model.Email,
                Senha = model.Senha
            };

            try
            {
                await _context.users.AddAsync(user);
                await _context.SaveChangesAsync();
                return Created(uri: $"v1/user/{user.id}", user);
            }
            catch (Exception)
            {
                return UnprocessableEntity();
            }

        }


    }
}
