using System.Collections.Generic;
using System.Threading.Tasks;
using Acme.Draw.Core.Domain;

namespace Acme.Draw.Core.Integration.Persistence
{
    public interface ISerialRegistrationRepository
    {
        Task<PageResult<SerialRegistration>> GetAllByPageAsync(int page, int amount);
        Task<IEnumerable<SerialRegistration>> GetRegistrationsBySerialAsync(string serial);
        Task SaveRegistrationAsync(SerialRegistration registration);
    }
}