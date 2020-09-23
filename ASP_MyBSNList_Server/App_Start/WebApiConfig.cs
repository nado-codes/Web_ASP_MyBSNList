using System.Net.Http.Headers;
using System.Web.Http;

public class WebApiConfig
{
    public static void Register(HttpConfiguration configuration)
    {
        configuration.MapHttpAttributeRoutes();

        configuration.Routes.MapHttpRoute("API Default", "api/{controller}/{id}",
          new { id = RouteParameter.Optional });

        configuration.Formatters.JsonFormatter.SupportedMediaTypes
            .Add(new MediaTypeHeaderValue("text/html"));
    }
}