using System;
using System.Collections.Generic;
using System.Text;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Settings;
using LinqToDB.Configuration;

namespace Acme.Draw.Core.Integration.Persistence
{
    public class ConnectionStringSettings : IConnectionStringSettings
    {
        public string ConnectionString { get; set; }
        public string Name { get; set; }
        public string ProviderName { get; set; }
        public bool IsGlobal => false;
    }

    public class OrmSettings : ILinqToDBSettings
    {
        private readonly AcmeSettings _settings;

        public OrmSettings(AcmeSettings settings)
        {
            _settings = settings;
        }
        public IEnumerable<IDataProviderSettings> DataProviders
        {
            get { yield break; }
        }

        public string DefaultConfiguration => "AcmeDraw";
        public string DefaultDataProvider => "SqlServer";

        public IEnumerable<IConnectionStringSettings> ConnectionStrings
        {
            get
            {
                yield return
                    new ConnectionStringSettings
                    {
                        Name = "AcmeDraw",
                        ProviderName = "SqlServer",
                        ConnectionString = _settings.SqlConnectionString
                    };
            }
        }
    }
}
