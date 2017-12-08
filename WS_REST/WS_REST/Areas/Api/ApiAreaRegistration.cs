using System.Web.Mvc;

namespace WS_REST.Areas.Api
{
    public class ApiAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Api";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AccesoCliente",
                "Api/Clientes/Cliente/{id}",
                new {
                    action = "Cliente",
                    controller = "Cliente",
                    id = UrlParameter.Optional
                }
            );

            context.MapRoute(
                "AccesoClientes",
                "Api/Clientes/Clientes",
                new
                {
                    action = "Clientes",
                    controller = "Cliente",
                }
            );

            context.MapRoute(
                "AccesoDefault",
                "Api/{controller}/{action}/{id}",
                new
                {
                    action = "Index",
                    id=UrlParameter.Optional
                }
            );
        }
    }
}