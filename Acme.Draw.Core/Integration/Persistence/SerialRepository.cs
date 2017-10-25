using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Domain;
using LinqToDB;

namespace Acme.Draw.Core.Integration.Persistence
{
    public class SerialRepository : ISerialRepository
    {
        /// <summary>
        /// Gets ar serial by the serial it self
        /// </summary>
        /// <param name="serial">string serial</param>
        /// <returns>serial entity</returns>
        public async Task<Serial> GetSerialAsync(string serial)
        {
            using (var db = new AcmeDrawDatabase())
            {
                var list = await db.Serials.Where(s => s.SerialNumber == serial).ToListAsync();
                return list.FirstOrDefault();
            }
        }
    }
}
