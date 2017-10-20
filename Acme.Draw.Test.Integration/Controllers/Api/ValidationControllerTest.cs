using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Controllers.Api;
using LinqToDB.Data;
using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Integration.Settings;
using Microsoft.AspNetCore.Mvc;
using Shouldly;

namespace Acme.Draw.Test.Integration.Controllers.Validation
{
    [TestClass]
    public class ValidationControllerTest
    {
        private ValidationController _sut;
        private OrmSettings _ormSettings;


        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Database=AcmeDrawTest;Integrated Security=True;MultipleActiveResultSets=True;";
        [TestInitialize]
        public void Init()
        {
            _ormSettings = new OrmSettings(new AcmeSettings(ConnectionString));
            DataConnection.DefaultSettings = _ormSettings;
            var validator = new SerialRegistrationValidator(new SerialRegistrationRepository(), new SerialRepository());
            _sut = new ValidationController(validator);
        }

        [TestMethod]
        public async Task ValidationController_Serial_VALID()
        {
            Serial serial; 
            using (var db = new DataConnection())
            {
               serial =  db.GetTable<Serial>().First();
            }
            
            var response = await _sut.ValidateSerial(serial.SerialNumber);


            response.ShouldBeOfType<OkResult>();
        }
        [TestMethod]
        public async Task ValidationController_Serial_NOT_VALID()
        {
            var serial = new Serial()
            {
                SerialNumber = "Test"
            };
            

            var response = await _sut.ValidateSerial(serial.SerialNumber);


            response.ShouldBeOfType<BadRequestResult>();
        }
    }
}
