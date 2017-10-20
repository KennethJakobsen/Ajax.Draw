using System.Threading.Tasks;
using Acme.Draw.Core.Domain;

namespace Acme.Draw.Core.Integration.Persistence
{
    public interface ISerialRepository
    {
        Task<Serial> GetSerialAsync(string serial);
    }
}