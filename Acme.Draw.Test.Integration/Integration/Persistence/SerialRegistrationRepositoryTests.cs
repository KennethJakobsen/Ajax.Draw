using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using LinqToDB;
using LinqToDB.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Shouldly;

namespace Acme.Draw.Test.Integration.Integration.Persistence
{
    [TestClass]
    public class SerialRegistrationRepositoryTests
    {
        private SerialRegistrationRepository _sut;
        private OrmSettings _ormSettings;
        private List<SerialRegistration> _registeredSerials;
        private const string ConnectionString = @"Data Source=.\SQLEXPRESS;Database=AcmeDrawTest;Integrated Security=True;MultipleActiveResultSets=True;";


        [TestInitialize]
        public void Init()
        {
            _registeredSerials = new List<SerialRegistration>();
            _ormSettings = new OrmSettings(new AcmeSettings(ConnectionString));
            DataConnection.DefaultSettings = _ormSettings;
            _sut = new SerialRegistrationRepository();
        }

        private SerialRegistration CreateRegistration(string serial)
        {
            
            var reg = new SerialRegistration(
                "Kenneth",
                "Jakobsen",
                "kenneth.jakobsen@yahoo.com",
                "+45 22 22 58 05",
                new DateTime(1983, 4, 27),
                serial,
                DateTime.UtcNow);
            _registeredSerials.Add(reg);
            return reg;
        }

        [TestMethod]
        public async Task SerialRegistrationRepository_Can_Save_Registration()
        {
            Serial serial;
            using (var db = new DataConnection())
                serial = db.GetTable<Serial>().First();
            

            await _sut.SaveRegistrationAsync(CreateRegistration(serial.SerialNumber));

            using (var db = new DataConnection())
                db.GetTable<SerialRegistration>().Count(t => t.Serial == serial.SerialNumber).ShouldBe(1);
            
            
        }

        [TestMethod]
        public async Task SerialRegistrationRepository_Can_Get_Registrations()
        {
            Serial serial;
            using (var db = new DataConnection())
            {
                serial = db.GetTable<Serial>().First();
                await db.InsertAsync(CreateRegistration(serial.SerialNumber));
            }

            var registrations = await _sut.GetRegistrationsBySerialAsync(serial.SerialNumber);
            registrations.Count().ShouldBe(1);
        }

        [TestMethod]
        public async Task SerialRegistrationRepository_Can_Get_PagedResult()
        {
            List<Serial> serials;
            using (var db = new DataConnection())
            {
                serials = await db.GetTable<Serial>().Take(20).ToListAsync();
                foreach (var serial in serials)
                {
                    await db.InsertAsync(CreateRegistration(serial.SerialNumber));
                }
            }

            var page1 = await _sut.GetAllByPageAsync(1, 10);
            var page2 = await _sut.GetAllByPageAsync(2, 10);


            page1.Rows.Count().ShouldBe(10);
            page1.Rows.Any(t => t.Serial == serials.First().SerialNumber).ShouldBeTrue();

            page2.Rows.Count().ShouldBe(10);
            page2.Rows.Any(t => t.Serial == serials.Last().SerialNumber).ShouldBeTrue();
        }

        [TestCleanup]
        public void CleanUp()
        {
            using (var db = new DataConnection())
            {
                foreach (var registration in _registeredSerials)
                {
                    db.GetTable<SerialRegistration>().Delete(t => t.Serial == registration.Serial && t.Registered == registration.Registered);
                }
                
            }
        }
    }
}
