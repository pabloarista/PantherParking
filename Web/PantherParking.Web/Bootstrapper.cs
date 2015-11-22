using PantherParking.Data;
using PantherParking.Services;
using PantherParking.Services.Administration;
using PantherParking.Services.HistoricalData;
using PantherParking.Services.Location;
using PantherParking.Services.Login;
using PantherParking.Services.Registration;
using StructureMap;

namespace PantherParking.Web
{
    public static class Bootstrapper
    {
        public static void ConfigureStructureMap()
        {
            ObjectFactory.Configure(c =>
            {
                c.AddRegistry(new DataRegistry());
                c.AddRegistry(new ServiceRegistry());
                c.SetAllProperties(p =>
                {
                    p.OfType<IAdministrationService>();
                    p.OfType<IHistoryicalDataService>();
                    p.OfType<ILocationService>();
                    p.OfType<ILoginService>();
                    p.OfType<IRegistrationService>();
                });
            });
        }
    }
}