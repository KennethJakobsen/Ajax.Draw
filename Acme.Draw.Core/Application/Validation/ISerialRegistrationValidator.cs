using System.Threading.Tasks;

namespace Acme.Draw.Core.Application.Validation
{
    public interface ISerialRegistrationValidator
    {
        /// <summary>
        /// Method for verifying whether a serial can be entered into the draw
        /// </summary>
        /// <param name="serial">Serial to verify</param>
        /// <returns>True if serial is valid, false if not</returns>
        Task<bool> CanEnterSerialAsync(string serial);
    }
}