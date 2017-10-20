using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Controllers.Api;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using LinqToDB.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestPlatform.ObjectModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Shouldly;

namespace Acme.Draw.Test.Unit.Application.Validation
{
    [TestClass]
    public class RegistrationControllerTest
    {
        private RegistrationController _sut;
        private OrmSettings _ormSettings;
        private Mock<ISerialRegistrationValidator> _regValidator;


        [TestInitialize]
        public void Init()
        {
            _regValidator = new Mock<ISerialRegistrationValidator>();
            var serialregistrationRepo = new Mock<ISerialRegistrationRepository>();
            serialregistrationRepo.Setup(s => s.SaveRegistrationAsync(It.IsAny<SerialRegistration>())).Returns(Task.CompletedTask);
            _sut = new RegistrationController(_regValidator.Object, serialregistrationRepo.Object);
        }

        [TestMethod]
        public async Task RegistrationController_Register_VALID()
        {

            _regValidator.Setup(r => r.CanEnterSerialAsync(It.IsAny<string>())).ReturnsAsync(true);
            var response = await _sut.EnterRegistration(new EnterRegistrationRequest());
            response.ShouldBeOfType<OkResult>();
        }
        [TestMethod]
        public async Task RegistrationController_Register_NOT_VALID()
        {

            _regValidator.Setup(r => r.CanEnterSerialAsync(It.IsAny<string>())).ReturnsAsync(false);
            var response = await _sut.EnterRegistration(new EnterRegistrationRequest());
            response.ShouldBeOfType<BadRequestResult>();
        }

    }
}