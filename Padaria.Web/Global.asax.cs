using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using System.Data.Entity;
using Padaria.Repository.Data;
using Padaria.Web.DataInitializer;
using System.Web.Optimization;
using Padaria.Web.App_Start;
using Padaria.Repository.Repository;

namespace Padaria.Web
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        private PermissionRepository _permissionRepository = null;
        private TypeOfRegistrationRepository _typeOfRegistrationRepository = null;
        private TypeOfPaymentRepository _typeOfPaymentRepository = null;
        protected void Application_Start()
        {

            Database.SetInitializer<DataContext>(new DataContextInitializer());
            _permissionRepository = new PermissionRepository();
            _typeOfRegistrationRepository = new TypeOfRegistrationRepository();

            _permissionRepository.Creates();

            _typeOfPaymentRepository = new TypeOfPaymentRepository();
            _typeOfPaymentRepository.Creates();
            _typeOfRegistrationRepository.Creates();

            AreaRegistration.RegisterAllAreas();
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
        }
    }
}