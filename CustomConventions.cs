using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace StaticApps.Conventions
{
    public class CustomRouteConvention : IApplicationModelConvention
    {
        public void Apply(ApplicationModel application)
        {
            foreach (var controller in application.Controllers)
            {
                var controllerName = controller.ControllerName;
                if (controllerName.EndsWith("API", StringComparison.OrdinalIgnoreCase))
                {
                    var routePrefix = controllerName[..^3];
                    foreach (var selector in controller.Selectors)
                    {
                        if (selector.AttributeRouteModel != null)
                        {
                            selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute("api/" + routePrefix));
                        }
                    }
                }
            }
        }
    }
}
