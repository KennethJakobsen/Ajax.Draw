using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace Acme.Draw.Test.Unit.Application.Validation
{
    [TestClass]
    public class SerialRegistrationValidatorTest
    {
        private SerialRegistrationValidator _sut;
        private Mock<ISerialRegistrationRepository> _registrationRepository;
        private Mock<ISerialRepository> _serialRepository;

        [TestInitialize]
        public void Initialize()
        {
            _registrationRepository = new Mock<ISerialRegistrationRepository>();
            _serialRepository = new Mock<ISerialRepository>();

            _sut = new SerialRegistrationValidator(_registrationRepository.Object, _serialRepository.Object);
        }

        [TestMethod]
       public async Task SerialRegistrationValidator_Can_Validate_VALID()
        {
            var serial = new Serial(){SerialNumber = Guid.NewGuid().ToString()};
            _serialRepository.Setup(s => s.GetSerialAsync(It.IsAny<string>())).ReturnsAsync(() => serial);
            _registrationRepository.Setup(r => r.GetRegistrationsBySerialAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var canEnter = await _sut.CanEnterSerialAsync(serial.SerialNumber);
            canEnter.ShouldBe(true);
        }

        [TestMethod]
        public async Task SerialRegistrationValidator_Can_Validate_no_serial_NOT_VALID()
        {
            var serial = new Serial() { SerialNumber = Guid.NewGuid().ToString() };
            _serialRepository.Setup(s => s.GetSerialAsync(It.IsAny<string>())).ReturnsAsync(() => null);
            _registrationRepository.Setup(r => r.GetRegistrationsBySerialAsync(It.IsAny<string>()))
                .ReturnsAsync(() => null);

            var canEnter = await _sut.CanEnterSerialAsync(serial.SerialNumber);
            canEnter.ShouldBe(false);
        }

        [TestMethod]
        public async Task SerialRegistrationValidator_Can_Validate_too_many_registrations_NOT_VALID()
        {
            var serial = new Serial() { SerialNumber = Guid.NewGuid().ToString() };
            _serialRepository.Setup(s => s.GetSerialAsync(It.IsAny<string>())).ReturnsAsync(() => serial);
            _registrationRepository.Setup(r => r.GetRegistrationsBySerialAsync(It.IsAny<string>()))
                .ReturnsAsync(() => new [] { new SerialRegistration(), new SerialRegistration()});

            var canEnter = await _sut.CanEnterSerialAsync(serial.SerialNumber);
            canEnter.ShouldBe(false);
        }
    }
}