using System.Threading.Tasks;

namespace Acme.Draw.Core.Application.Validation
{
    public interface ISerialRegistrationValidator
    {
        Task<bool> CanEnterSerialAsync(string serial);
    }
}