using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ApiItaliaMi.Data;
using ApiItaliaMi.Models;
using Microsoft.EntityFrameworkCore;
using ApiItaliaMi.ViewModels;

namespace ApiItaliaMi.Controllers
{
    [ApiController]
    public class PassportController : ControllerBase
    {
        [HttpGet("v1/passports")]
        public async Task<IActionResult> GetAllAsync(
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var passports = await context.Passports
                                             .Include(p => p.Customer)
                                             .Include(p => p.User)
                                             .ToListAsync();
                return Ok(new ResultViewModel<List<Passport>>(passports));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<List<Passport>>("Erro interno no servidor"));
            }
        }

        [HttpGet("v1/passports/{id:int}")]
        public async Task<IActionResult> GetByIdAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var passport = await context.Passports
                                            .Include(p => p.Customer)
                                            .Include(p => p.User)
                                            .FirstOrDefaultAsync(x => x.Id == id);

                if (passport == null)
                    return NotFound(new ResultViewModel<Passport>("Passaporte não encontrado"));

                return Ok(new ResultViewModel<Passport>(passport));
            }
            catch
            {
                return StatusCode(500, new ResultViewModel<Passport>("Erro interno no servidor"));
            }
        }

        [HttpPost("v1/passports")]
        public async Task<IActionResult> PostAsync(
            [FromBody] CreatePassportViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Passport>("Não foi possivel criar um passaporte, valide se os dados estão de acordo para a criação"));

            try
            {
                var passport = new Passport
                {
                    ContractorCompleteName = model.ContractorCompleteName,
                    ContractorEmail = model.ContractorEmail,
                    ContractorCPF = model.ContractorCPF,
                    ContractorPhone = model.ContractorPhone,
                    PrenotamiEmail = model.PrenotamiEmail,
                    PrenotamiPassword = model.PrenotamiPassword,
                    FastitEmail = model.FastitEmail,
                    FastitPassword = model.FastitPassword,
                    DateUnavailability = model.DateUnavailability,
                    HaveExpiredItalianPassport = model.HaveExpiredItalianPassport,
                    HaveMinorChildren = model.HaveMinorChildren,
                    NumberOfMinorChildren = model.NumberOfMinorChildren,
                    CompleteResidentialAddress = model.CompleteResidentialAddress,
                    CivilState = model.CivilState,
                    DateOfExpiredItalianPassport = model.DateOfExpiredItalianPassport,
                    MinorsCompleteNames = model.MinorsCompleteNames,
                    Customer = new Customer
                    {
                        CompleteName = model.Customer.CompleteName,
                        PersonalEmail = model.Customer.PersonalEmail,
                        PrenotamiEmail = model.Customer.PrenotamiEmail,
                        PrenotamiPassword = model.Customer.PrenotamiPassword,
                        FastitEmail = model.Customer.FastitEmail,
                        FastitPassword = model.Customer.FastitPassword,
                        Process = model.Customer.Process
                    },
                    User = new User
                    {
                        Username = model.User.Username,
                        Name = model.User.Name,
                        Email = model.User.Email,
                        Password = model.User.Password,
                        CPF = model.User.CPF,
                        PhoneNumber = model.User.PhoneNumber,
                        Role = model.User.Role
                    }
                };

                await context.Passports.AddAsync(passport);
                await context.SaveChangesAsync();

                return Created($"v1/passports/{passport.Id}", new ResultViewModel<Passport>(passport));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Passport>("Não foi possível incluir o passaporte, tente sem Id"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Passport>("Erro interno no servidor"));
            }
        }

        [HttpPut("v1/passports/{id:int}")]
        public async Task<IActionResult> PutAsync(
            [FromRoute] int id,
            [FromBody] EditPassportViewModel model,
            [FromServices] ItaliaMiDataContext context)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultViewModel<Passport>("Não foi possível editar um passaporte, verifique se os dados estão corretos"));

            try
            {
                var passport = await context.Passports
                                            .Include(p => p.Customer)
                                            .Include(p => p.User)
                                            .FirstOrDefaultAsync(x => x.Id == id);

                if (passport == null)
                    return NotFound(new ResultViewModel<Passport>("Passaporte não encontrado"));

                passport.ContractorCompleteName = model.ContractorCompleteName;
                passport.ContractorEmail = model.ContractorEmail;
                passport.ContractorPhone = model.ContractorPhone;
                passport.PrenotamiEmail = model.PrenotamiEmail;
                passport.PrenotamiPassword = model.PrenotamiPassword;
                passport.FastitEmail = model.FastitEmail;
                passport.FastitPassword = model.FastitPassword;
                passport.DateUnavailability = model.DateUnavailability;
                passport.HaveExpiredItalianPassport = model.HaveExpiredItalianPassport;
                passport.HaveMinorChildren = model.HaveMinorChildren;
                passport.NumberOfMinorChildren = model.NumberOfMinorChildren;
                passport.CompleteResidentialAddress = model.CompleteResidentialAddress;
                passport.CivilState = model.CivilState;
                passport.DateOfExpiredItalianPassport = model.DateOfExpiredItalianPassport;
                passport.MinorsCompleteNames = model.MinorsCompleteNames;

                passport.Customer.CompleteName = model.Customer.CompleteName;
                passport.Customer.PersonalEmail = model.Customer.PersonalEmail;
                passport.Customer.PrenotamiEmail = model.Customer.PrenotamiEmail;
                passport.Customer.PrenotamiPassword = model.Customer.PrenotamiPassword;
                passport.Customer.FastitEmail = model.Customer.FastitEmail;
                passport.Customer.FastitPassword = model.Customer.FastitPassword;
                passport.Customer.Process = model.Customer.Process;

                passport.User.Username = model.User.Username;
                passport.User.Name = model.User.Name;
                passport.User.Email = model.User.Email;
                passport.User.Password = model.User.Password;
                passport.User.CPF = model.User.CPF;
                passport.User.PhoneNumber = model.User.PhoneNumber;
                passport.User.Role = model.User.Role;

                context.Passports.Update(passport);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Passport>(passport));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Passport>("Não foi possível atualizar o passaporte, tente novamente"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Passport>("Erro interno no servidor"));
            }
        }

        [HttpDelete("v1/passports/{id:int}")]
        public async Task<IActionResult> DeleteAsync(
            [FromRoute] int id,
            [FromServices] ItaliaMiDataContext context)
        {
            try
            {
                var passport = await context.Passports
                                            .Include(p => p.Customer)
                                            .Include(p => p.User)
                                            .FirstOrDefaultAsync(x => x.Id == id);

                if (passport == null)
                    return NotFound(new ResultViewModel<Passport>("Passaporte não encontrado"));

                context.Passports.Remove(passport);
                await context.SaveChangesAsync();

                return Ok(new ResultViewModel<Passport>(passport));
            }
            catch (DbUpdateException)
            {
                return BadRequest(new ResultViewModel<Passport>("Não foi possível deletar o passaporte, tente novamente"));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultViewModel<Passport>("Erro interno no servidor"));
            }
        }
    }
}
