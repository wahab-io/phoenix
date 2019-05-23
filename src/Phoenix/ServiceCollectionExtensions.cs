using System;
using Phoenix;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceCollectionExtensions
    {
        public static IMvcBuilder AddFeaturesFolder(this IMvcBuilder services)
        {
            if (services == null)
                throw new ArgumentNullException(nameof(services));

            services.AddMvcOptions(options => 
            { 
                options.Conventions.Add(new FeatureControllerModelConvention());
            })
            .AddRazorOptions(options => 
            {
                // {0} - Action Name
                // {1} - Controller Name
                // {2} - Area Name
                // {3} - Feature Name
                options.ViewLocationFormats.Clear(); 
                options.ViewLocationFormats.Add("/Features/{3}/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/{3}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Features/Shared/{0}.cshtml");
                
                options.ViewLocationExpanders.Add(new FeatureViewLocationExpander());
            });
            
            return services;
        }
    }
}