using System.Threading.Tasks;
using CanalDotNet.Data;
using CanalDotNet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CanalDotNet.Controllers
{
    [ApiController]
    [Route("v1/todos")]
    public class TodoController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [Authorize]
        public async Task<ActionResult> Get([FromServices] DataContext context)
        {
            try
            {
                var result = await context.Todos.AsNoTracking().ToListAsync();

                return Ok(result);
            }
            catch
            {
                return StatusCode(500, "Não foi possível listar as tarefas");
            }
        }

        [HttpPost]
        [Route("")]
        [Authorize]
        public async Task<ActionResult> Post(
            [FromServices] DataContext context,
            [FromBody] TodoItem model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            try
            {
                model.User = User.Identity.Name ?? "";
                context.Todos.Add(model);
                await context.SaveChangesAsync();

                return Created("v1/todos", model);
            }
            catch
            {
                return StatusCode(500, "Não foi possível listar as tarefas");
            }
        }
    }
}