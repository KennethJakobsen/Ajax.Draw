using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using LinqToDB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Acme.Draw.Test.Integration.Integration.Persistence
{
    [TestClass]
    public class SerialRepositoryTests
    {
        private SerialRepository _sut;
        private OrmSettings _ormSettings;
        private List<string> _registeredSerials;


        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Database=AcmeDrawTest;Integrated Security=True;MultipleActiveResultSets=True;";
        [TestInitialize]
        public void Init()
        {
            _registeredSerials = new List<string>();
            _ormSettings = new OrmSettings(new AcmeSettings(ConnectionString));
            DataConnection.DefaultSettings = _ormSettings;
            _sut = new SerialRepository();
        }

      
        [TestMethod]
        public async Task SerialRepository_Can_Get_Serial()
        {
            var serial = await _sut.GetSerialAsync("08780a9b-08c7-46bd-b198-3e08e25c8f3b");
            serial.ShouldNotBeNull();
        }

        
    }
}
