using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Extensions;
using Acme.Draw.Core.Integration.Persistence;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Draw.Core.Controllers.Api
{
    [Route("api/[controller]")]
    public class RegistrationController : Controller
    {
        private readonly ISerialRegistrationValidator _validator;
        private readonly ISerialRegistrationRepository _registrationRepository;

        public RegistrationController(ISerialRegistrationValidator validator, ISerialRegistrationRepository registrationRepository)
        {
            _validator = validator;
            _registrationRepository = registrationRepository;
        }
        [Route("")]
        [HttpPost]
        public async Task<IActionResult> EnterRegistration([FromBody]EnterRegistrationRequest enterSerial)
        {
            
            if (ModelState.IsValid)
            {
                if (!await _validator.CanEnterSerialAsync(enterSerial.Serial))
                    return BadRequest();
                await _registrationRepository.SaveRegistrationAsync(enterSerial.ToRegistration());
                return Ok();
            }
            return BadRequest();
            
        }

        [Route("page/{page:int}/amount/{amount:int}")]
        [HttpGet]
        public async Task<IActionResult> GetRegistrationsPaged(int page, int amount)
        {
            if (page < 1)
                return BadRequest();
            if (amount < 1)
                return BadRequest();
            return Ok(await _registrationRepository.GetAllByPageAsync(page, amount));
        }
    }
}
