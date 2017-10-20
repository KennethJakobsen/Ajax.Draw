using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Draw.Core.Domain;
using LinqToDB;
using LinqToDB.Data;
using LinqToDB.DataProvider.SqlServer;

namespace Acme.Draw.Core.Integration.Persistence
{
    public class SerialRegistrationRepository : ISerialRegistrationRepository
    {
        public SerialRegistrationRepository()
        {
        }

        /// <summary>
        /// Gets Registrations for a specific serial
        /// </summary>
        /// <param name="serial">Serial for product</param>
        /// <returns>List of registrations</returns>
        public async Task<IEnumerable<SerialRegistration>> GetRegistrationsBySerialAsync(string serial)
        {
            using (var db = new AcmeDrawDatabase())
            {
                return await db.Registrations.Where(r => r.Serial == serial).ToListAsync();
            }
        }

        /// <summary>
        /// Saves a restration to the database
        /// </summary>
        /// <param name="registration">The registration to save</param>
        /// <returns>awaitable Task</returns>
        public async Task SaveRegistrationAsync(SerialRegistration registration)
        {
            using (var db = new AcmeDrawDatabase())
            {
                await db.InsertAsync(registration);
            }
        }

        /// <summary>
        /// Gets all registrations paged
        /// </summary>
        /// <param name="page">The current page</param>
        /// <param name="amount">Amount of registrations to fetch</param>
        /// <param name="totalRecords">The total number of registrations registered</param>
        /// <returns>List of registrations</returns>
        public async Task<PageResult<SerialRegistration>> GetAllByPageAsync(int page, int amount)
        {
            using (var db = new AcmeDrawDatabase())
            {
                var registrations = db.Registrations.AsQueryable();

               var totalRecords = registrations.Count();

                var results = await registrations.Skip((page - 1) * amount).Take(amount).ToListAsync();
                return new PageResult<SerialRegistration>
                {
                    PageNumber = page,
                    PageSize = amount,
                    Rows = results,
                    TotalCount = totalRecords
                };
            }
        }

       
    }
}
