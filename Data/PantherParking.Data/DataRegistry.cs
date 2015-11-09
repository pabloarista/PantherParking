using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PantherParking.Data.DAL.Interfaces;
using PantherParking.Data.DAL.Repositories;
using StructureMap.Configuration.DSL;

namespace PantherParking.Data
{
    public class DataRegistry : Registry
    {
        public DataRegistry()
        {
            For<ILoginRepository>().Use<LoginRepository>();
            For<IAdministrationRepository>().Use<AdministrationRepository>();
            For<IHistoricalDataRepository>().Use<HistoricalDataRepository>();
            For<ILocationRepository>().Use<LocationRepository>();
            For<IRegistrationRepository>().Use<RegistrationRepository>();
        }
    }
}