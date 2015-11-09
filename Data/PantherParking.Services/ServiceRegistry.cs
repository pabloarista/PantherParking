using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherParking.Services.HistoricalData;
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
            For<IHistoryicalDataService>().Use<HistoricalDataService>();
        }
    }
}
