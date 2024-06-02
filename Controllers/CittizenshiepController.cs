using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiItaliaMi.Data;
using ApiItaliaMi.Models;
using ApiItaliaMi.ViewModels;
using System.Threading.Tasks;

namespace ApiItaliaMi.Controllers
{
    [ApiController]
    public class CittizenshipController : ControllerBase
    {
        [HttpGet("v1/cittizenship")]
        public async Task<IActionResult> GetAsync([FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var cittizenships = await context.Cittizenships
                    .Include(c => c.Customer)
                    .Include(c => c.User)
                    .ToListAsync();

                return Ok(new ResultViewModel<List<Cittizenship>>(cittizenships));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Cittizenship>>("05x04 - Falha interna no servidor"));
            }
        }

        [HttpGet("v1/cittizenship/{id:int}")]
        public async Task<IActionResult> GetAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var cittizenship = await context.Cittizenships
                    .Include(c => c.Customer)
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (cittizenship == null)
                    return NotFound(new ResultViewModel<Cittizenship>("04x01 - Cidadania não encontrada"));

                return Ok(new ResultViewModel<Cittizenship>(cittizenship));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Cittizenship>("05x05 - Falha interna no servidor"));
            }
        }

        [HttpPost("v1/cittizenship")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreateCittizenshipViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var customer = new Customer
                {
                    CompleteName = model.Customer.CompleteName,
                    PersonalEmail = model.Customer.PersonalEmail,
                    PrenotamiEmail = model.Customer.PrenotamiEmail,
                    PrenotamiPassword = model.Customer.PrenotamiPassword,
                    FastitEmail = model.Customer.FastitEmail,
                    FastitPassword = model.Customer.FastitPassword,
                    Process = model.Customer.Process
                };

                var user = new User
                {
                    Username = model.User.Username,
                    Name = model.User.Name,
                    Email = model.User.Email,
                    Password = model.User.Password,
                    CPF = model.User.CPF,
                    PhoneNumber = model.User.PhoneNumber,
                    Role = model.User.Role
                };

                var cittizenship = new Cittizenship
                {
                    CustomerCompleteName = model.CustomerCompleteName,
                    ContractorEmail = model.ContractorEmail,
                    ContractorPhone = model.ContractorPhone,
                    Customer = customer,
                    User = user
                };

                await context.Cittizenships.AddAsync(cittizenship);
                await context.SaveChangesAsync();

                return Created($"v1/cittizenship/{cittizenship.Id}", new ResultViewModel<Cittizenship>(cittizenship));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Cittizenship>("04x01 - Não foi possivel incluir cidadania, tente novamente."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Cittizenship>("05x07 - Falha interna no servidor"));
            }
        }

        [HttpPut("v1/cittizenship/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditCittizenshipViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var cittizenship = await context.Cittizenships
                    .Include(c => c.Customer)
                    .Include(c => c.User)
                    .FirstOrDefaultAsync(x => x.Id == id);

                if (cittizenship == null)
                    return NotFound(new ResultViewModel<Cittizenship>("04x01 - Cidadania não encontrada"));

                cittizenship.CustomerCompleteName = model.CustomerCompleteName;
                cittizenship.ContractorEmail = model.ContractorEmail;
                cittizenship.ContractorPhone = model.ContractorPhone;

                cittizenship.Customer.CompleteName = model.Customer.CompleteName;
                cittizenship.Customer.PersonalEmail = model.Customer.PersonalEmail;
                cittizenship.Customer.PrenotamiEmail = model.Customer.PrenotamiEmail;
                cittizenship.Customer.PrenotamiPassword = model.Customer.PrenotamiPassword;
                cittizenship.Customer.FastitEmail = model.Customer.FastitEmail;
                cittizenship.Customer.FastitPassword = model.Customer.FastitPassword;
                cittizenship.Customer.Process = model.Customer.Process;

                cittizenship.User.Username = model.User.Username;
                cittizenship.User.Name = model.User.Name;
                cittizenship.User.Email = model.User.Email;
                cittizenship.User.Password = model.User.Password;
                cittizenship.User.CPF = model.User.CPF;
                cittizenship.User.PhoneNumber = model.User.PhoneNumber;
                cittizenship.User.Role = model.User.Role;

                context.Cittizenships.Update(cittizenship);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Cittizenship>(cittizenship));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Cittizenship>("Não foi possivel atualizar a cidadania, tente novamente."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Cittizenship>("Erro interno no servidor"));
            }
        }

        [HttpDelete("v1/cittizenship/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var cittizenship = await context.Cittizenships.FirstOrDefaultAsync(x => x.Id == id);

                if (cittizenship == null)
                    return NotFound(new ResultViewModel<Cittizenship>("04x01 - Cidadania não encontrada"));

                context.Cittizenships.Remove(cittizenship);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Cittizenship>(cittizenship));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Cittizenship>("Não foi possivel remover a cidadania, tente novamente."));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Cittizenship>("Erro interno no servidor"));
            }
        }
    }
}
