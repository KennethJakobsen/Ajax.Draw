using Acme.Draw.Core.Application.Validation;
using Acme.Draw.Core.Domain;
using Acme.Draw.Core.Integration.Persistence;
using Acme.Draw.Core.Integration.Settings;
using LightInject;

namespace Acme.Draw.Core.IoC
{
    public class Bootstrapper
    {
        private readonly ServiceContainer _container;

        public Bootstrapper()
        {
            _container = new ServiceContainer(new ContainerOptions { EnablePropertyInjection = false });
        }

        public void RegisterServices()
        {
            _container.Register<ISerialRegistrationValidator, SerialRegistrationValidator>();
            _container.Register<ISerialRepository, SerialRepository>();
            _container.Register<ISerialRegistrationRepository, SerialRegistrationRepository>();
        }


        public IServiceContainer Container => _container;

    }
}
