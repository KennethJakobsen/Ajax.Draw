using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Acme.Draw.Test.IntegrationTests.Integration.Persistence
{
    [TestClass]
    public class SerialRegistrationRepositoryTests
    {
        private const string ConnectionString =
                @"Data Source=.\SQLEXPRESS;Initial Catalog=AcmeDraw;Integrated Security=True;MultipleActiveResultSets=True;";
        [TestInitialize]
        public void Init()
        {
            _sut = new SerialRegistrationRepository();
        }
    }
}
