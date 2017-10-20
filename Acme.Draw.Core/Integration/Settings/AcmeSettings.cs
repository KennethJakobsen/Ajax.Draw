namespace Acme.Draw.Core.Integration.Settings
{
    public class AcmeSettings
    {
        
        public string SqlConnectionString { get; protected set; }

        public AcmeSettings(string sqlConnectionString)
        {
            SqlConnectionString = sqlConnectionString;
        }
    }
}
