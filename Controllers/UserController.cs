 using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiItaliaMi.Data;
using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using ApiItaliaMi.ViewModels;

namespace ApiItaliaMi.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        [HttpGet("v1/user")]
        public async Task<IActionResult> GetAsync(
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var users = await context.Users.ToListAsync();
                return Ok(new ResultViewModel<List<User>>(users));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<User>>("05x04 - Falha interna no servidor"));
            }



        }
        [HttpGet("v1/user/{id:int}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context
            )
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    return NotFound(new ResultViewModel<User>("04x01 - Usuario não encontrado"));
                }

                return Ok(new ResultViewModel<User>(user));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<User>("05x05 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/user/login")]
        public async Task<IActionResult> PostAsync(
            [FromBody] User model,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                await context.Users.AddAsync(model);
                await context.SaveChangesAsync();
                var user = model;
                return Created($"v1/users/{user.Id}", new ResultViewModel<User>(user));
            }
            catch(DbUpdateException ex)
            {
                return BadRequest(new ResultViewModel<User>(" 04x01 - Não foi possivel incluir usuario, tente sem Id"));
            }
            catch(Exception ex)
            {
                return StatusCode(500, new ResultViewModel<User>("05x07 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/user/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditUserViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    return NotFound();
                }
                user.Username = model.Username;
                user.Name = model.Name;
                user.PhoneNumber = model.PhoneNumber;
                user.Role = model.Role;

                context.Users.Update(user);
                await context.SaveChangesAsync();
               

                return Ok(model);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest("Não foi possivel incluir usuario, tente sem Id");
            }
            catch(Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }


        }

        [HttpDelete("v1/user/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var user = await context.Users.FirstOrDefaultAsync(x => x.Id == id);

                if (user == null)
                {
                    return NotFound();
                }

                context.Users.Remove(user);
                await context.SaveChangesAsync();

                return Ok(user);
            }
            catch(DbUpdateException ex)
            {
                return BadRequest("Não foi possivel incluir usuario, tente sem Id");
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno no servidor");
            }


        }



    }
}
