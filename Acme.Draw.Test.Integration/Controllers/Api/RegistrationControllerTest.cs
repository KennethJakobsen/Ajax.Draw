using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Controllers.Api;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Acme.Draw.Test.Integration.Controllers.Api
{
    [TestClass]
    public class RegistrationControllerTest
    {
        private RegistrationController _sut;
        private OrmSettings _ormSettings;
        private List<Serial> _registeredSerials;


        private const string ConnectionString =
            @"Data Source=.\SQLEXPRESS;Database=AcmeDrawTest;Integrated Security=True;MultipleActiveResultSets=True;";

        [TestInitialize]
        public void Init()
        {
            _registeredSerials = new List<Serial>();
            _ormSettings = new OrmSettings(new AcmeSettings(ConnectionString));
            DataConnection.DefaultSettings = _ormSettings;
            var validator = new SerialRegistrationValidator(new SerialRegistrationRepository(), new SerialRepository());
            var serialregistrationRepository = new SerialRegistrationRepository();
            _sut = new RegistrationController(validator, serialregistrationRepository);
        }

        [TestMethod]
        public async Task RegistrationController_EnterRegistration_VALID()
        {
            Serial serial;
            using (var db = new DataConnection())
            {
                serial = db.GetTable<Serial>().First();
            }

            var req = new EnterRegistrationRequest()
            {
                DateOfBirth = new DateTime(1983, 4, 27),
                Serial = serial.SerialNumber,
                Email = "kenneth.jakobsen@yahoo.com",
                FirstName = "Kenneth",
                LastName = "Jakobsen",
                Phone = "+45 22 22 58 05"
            };

            var response = await _sut.EnterRegistration(req);


            response.ShouldBeOfType<OkResult>();
            _registeredSerials.Add(serial);
        }

        [TestMethod]
        public async Task RegistrationController_EnterRegistration_NOT_VALID()
        {
            var serial = new Serial()
            {
                SerialNumber = "Test"
            };

            var req = new EnterRegistrationRequest()
            {
                DateOfBirth = new DateTime(1983, 4, 27),
                Serial = serial.SerialNumber,
                Email = "kenneth.jakobsen@yahoo.com",
                FirstName = "Kenneth",
                LastName = "Jakobsen",
                Phone = "+45 22 22 58 05"
            };

            var response = await _sut.EnterRegistration(req);


            response.ShouldBeOfType<BadRequestResult>();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var db = new DataConnection())
            {
                foreach (var registration in _registeredSerials)
                {
                    db.GetTable<SerialRegistration>().Delete(t => t.Serial == registration.SerialNumber);
                }

            }
        }



    }
}