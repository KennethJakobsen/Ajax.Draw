using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Integration.Persistence;

namespace Acme.Draw.Core.Application.Validation
{
    public class SerialRegistrationValidator : ISerialRegistrationValidator
    {
        private readonly ISerialRegistrationRepository _registrationRepository;
        private readonly ISerialRepository _serialRepository;
        private const short MaxRegistrations = 2;

        public SerialRegistrationValidator(ISerialRegistrationRepository registrationRepository, ISerialRepository serialRepository)
        {
            _registrationRepository = registrationRepository;
            _serialRepository = serialRepository;
        }
        public async Task<bool> CanEnterSerialAsync(string serial)
        {
            var registrations = await _registrationRepository.GetRegistrationsBySerialAsync(serial);
            if (registrations != null &&  registrations.Count() >= MaxRegistrations)
                return false;
            if (await _serialRepository.GetSerialAsync(serial) == null)
                return false;
            return true;
        }
    }
}
