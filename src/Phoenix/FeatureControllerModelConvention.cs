using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc.ApplicationModels;

namespace Phoenix
{
    public class FeatureControllerModelConvention : IControllerModelConvention
    {
        public void Apply(ControllerModel controller)
        {
            if (controller == null)
                throw new ArgumentNullException(nameof(controller));

            controller.Properties.Add("feature", GetFeatureName(controller));
        }

        private string GetFeatureName(ControllerModel controller)
        {
            var controllerInfo = controller.ControllerType;
            
            var tokens = controllerInfo.FullName.Split('.');
            if (!tokens.Any(t => t == "Features")) 
                return string.Empty;
            
            return tokens.SkipWhile(t => !t.Equals("features", StringComparison.CurrentCultureIgnoreCase))
                    .Skip(1)
                    .Take(1)
                    .FirstOrDefault();
        }
    }
}