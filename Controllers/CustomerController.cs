using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiItaliaMi.Data;
using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using ApiItaliaMi.ViewModels;

namespace ApiItaliaMi.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        [HttpGet("v1/customers")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var customers = await context.Customers.ToListAsync();
                return Ok(new ResultViewModel<List<Customer>>(customers));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Customer>>("Erro interno no servidor"));
            }
        }

        [HttpGet("v1/customers/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

                if (customer == null)
                    return NotFound(new ResultViewModel<Customer>("Cliente não encontrado"));

                return Ok(new ResultViewModel<Customer>(customer));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Customer>("Erro interno no servidor"));
            }
        }

        [HttpPost("v1/customers")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateCustomerViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Customer>("Não foi possivel criar um cliente, valide os dados ou tente mais tarde."));

            try
            {
                var customer = new Customer
                {
                    CompleteName = model.CompleteName,
                    PersonalEmail = model.PersonalEmail,
                    PrenotamiEmail = model.PrenotamiEmail,
                    PrenotamiPassword = model.PrenotamiPassword,
                    FastitEmail = model.FastitEmail,
                    FastitPassword = model.FastitPassword,
                    Process = model.Process
                };

                await context.Customers.AddAsync(customer);
                await context.SaveChangesAsync();

                return Created($"v1/customers/{customer.Id}", new ResultViewModel<Customer>(customer));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Customer>("Não foi possível incluir o cliente, tente sem Id"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Customer>("Erro interno no servidor"));
            }
        }

        [HttpPut("v1/customers/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditCustomerViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Customer>("Não foi possivel editar um cliente, por favor tente mais tarde e valide os dados necessarios."));

            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

                if (customer == null)
                    return NotFound(new ResultViewModel<Customer>("Cliente não encontrado"));

                customer.CompleteName = model.CompleteName;
                customer.PersonalEmail = model.PersonalEmail;
                customer.PrenotamiEmail = model.PrenotamiEmail;
                customer.PrenotamiPassword = model.PrenotamiPassword;
                customer.FastitEmail = model.FastitEmail;
                customer.FastitPassword = model.FastitPassword;
                customer.Process = model.Process;

                context.Customers.Update(customer);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Customer>(customer));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Customer>("Não foi possível atualizar o cliente, tente novamente"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Customer>("Erro interno no servidor"));
            }
        }

        [HttpDelete("v1/customers/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var customer = await context.Customers.FirstOrDefaultAsync(x => x.Id == id);

                if (customer == null)
                    return NotFound(new ResultViewModel<Customer>("Cliente não encontrado"));

                context.Customers.Remove(customer);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Customer>(customer));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Customer>("Não foi possível deletar o cliente, tente novamente"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Customer>("Erro interno no servidor"));
            }
        }
    }
}
