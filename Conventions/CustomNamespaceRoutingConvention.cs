using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace NHL_Dashboards.Conventions;

public class CustomNamespaceRoutingConvention : IControllerModelConvention
{
    public void Apply(ControllerModel controller)
    {
        string output = string.Empty;
        var namespaceSegments = controller.ControllerType.Namespace!.Split('.');

        /* If it is in the API namespace then it gets it's own rules
            Each controller in the API namespace will have the following happen to it:
                1) 'api/' prepended
                2) the namespace added between the api and the controller name
                3) the last 3 letters (should be Api) removed from the controller name
        */
        if (namespaceSegments.Length > 2 && namespaceSegments[2].Equals("Api", StringComparison.OrdinalIgnoreCase))
        {
            foreach (var selector in controller.Selectors)
            {
                if (selector.AttributeRouteModel != null)
                {
                    output += "Api/";
                    if (namespaceSegments.Length > 3)
                    {
                        output += string.Join("/", namespaceSegments.Skip(3)) + "/";
                    }
                    output += controller.ControllerName[..^3];
                    selector.AttributeRouteModel = new AttributeRouteModel(new RouteAttribute(output));
                }
            }
        }
        // Everything outside the API namespace
        else
        {
            var route = string.Join("/", namespaceSegments.Skip(2));
            // If the controllerName is Home then skip adding the controller name to the route. This makes the Home controller the root controller.
            if (controller.ControllerName != "Home")
            {
                route += $"/{controller.ControllerName}";
            }

            foreach (var action in controller.Actions)
            {
                // This sets the URL to be a wildcard format so it catches all paths that don't get set elsewhere
                if (action.ActionName.Equals("NotFound", StringComparison.OrdinalIgnoreCase))
                {
                    action.Selectors.Clear();
                    action.Selectors.Add(new SelectorModel
                    {
                        AttributeRouteModel = new AttributeRouteModel()
                        {
                            Template = "{*url}" // Wildcard to catch unmatched requests
                        }
                    });
                }
                else
                {
                    foreach (var selector in action.Selectors)
                    {
                        if (selector.AttributeRouteModel != null)
                        {
                            output = $"{route}/{selector.AttributeRouteModel.Template}";
                            selector.AttributeRouteModel.Template = output;
                        }
                        else
                        {
                            output = $"{route}/{(action.ActionName == "Index" ? "" : action.ActionName)}";
                            selector.AttributeRouteModel = new AttributeRouteModel
                            {
                                Template = output
                            };
                        }
                    }
                }
            }
        }
    }
}