using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherParking.Services.Administration;
using PantherParking.Services.HistoricalData;
using PantherParking.Services.Location;
using PantherParking.Services.Login;
using PantherParking.Services.Registration;
using StructureMap.Configuration.DSL;

namespace PantherParking.Services
{
    public class ServiceRegistry : Registry
    {
        public ServiceRegistry()
        {
            For<ILoginService>().Use<LoginService>();
            For<IRegistrationService>().Use<RegistrationService>();
            For<IAdministrationService>().Use<AdministrationService>();
            For<ILocationService>().Use<LocationService>();
            For<IHistoryicalDataService>().Use<HistoricalDataService>();
        }
    }
}
