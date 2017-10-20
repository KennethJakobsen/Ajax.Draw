using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Application.Validation;
using Microsoft.AspNetCore.Mvc;

namespace Acme.Draw.Core.Controllers.Api
{
    [Route("api/[controller]")]
    public class ValidationController : Controller
    {
        private readonly ISerialRegistrationValidator _registrationValidator;

        public ValidationController(ISerialRegistrationValidator registrationValidator)
        {
            _registrationValidator = registrationValidator;
        }

        [Route("serial/{serial}")]
        public async Task<IActionResult> ValidateSerial(string serial)
        {
            if (serial == null)
                return BadRequest();
            if (await _registrationValidator.CanEnterSerialAsync(serial))
                return Ok();
            return BadRequest();

        }
    }
}
