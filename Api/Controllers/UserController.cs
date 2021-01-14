using System.Threading.Tasks;
using CanalDotNet.Data;
using CanalDotNet.Models;
using CanalDotNet.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanalDotNet.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController :ControllerBase
    {

        [HttpPost]
        [Route("")]
        [AllowAnonymous]
        public async Task<IActionResult> Create(
                    [FromServices] DataContext context,
                    [FromBody]User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                context.Users.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);
            }
            catch
            {
                return StatusCode(500, "Não foi possível incluir o usuário");
            }
        }

        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Authenticate(
                    [FromServices] DataContext context,
                    [FromBody]User model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.UserName == model.UserName && x.Password == model.Password);

                if (user == null)
                    return StatusCode(404, "Usuário ou senha inválidos");

                var token = TokenService.GenerateToken(model);
                model.Password = "";
                return Ok(new
                {
                    user = model,
                    token = token
                });
            }
            catch
            {
                return StatusCode(500, "Falha na autenticação");
            }
        }
            
    }
}