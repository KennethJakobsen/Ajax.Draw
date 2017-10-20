using Acme.Draw.Core.Domain;
using LinqToDB;
using LinqToDB.Data;

namespace Acme.Draw.Core.Integration.Persistence
{
    public class AcmeDrawDatabase : DataConnection
    {
        public AcmeDrawDatabase() : base("AcmeDraw")
        {
        }

        public ITable<SerialRegistration> Registrations => GetTable<SerialRegistration>();
        public ITable<Serial> Serials => GetTable<Serial>();
    }
}
