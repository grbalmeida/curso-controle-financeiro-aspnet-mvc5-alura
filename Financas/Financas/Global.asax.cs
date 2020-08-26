using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using WebMatrix.WebData;

namespace Financas
{
    public class MvcApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            WebSecurity.InitializeDatabaseConnection("FinancasContext", "Usuarios", "Id", "Nome", true);
        }
    }
}
