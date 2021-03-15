using Sitecore.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.XA.Foundation.Abstractions;
using Sitecore.XA.Foundation.Multisite.Extensions;
using Sitecore.Pipelines.ParseDataSource;

namespace Sitecore.Support
{
    public class CheckSitecoreQuery
    {
        protected bool IsDatasourceValid(string datasource) =>
           ((datasource.Length > 1) && (datasource.Contains(":") && (!datasource.StartsWith("local:") && (!datasource.StartsWith("page:") && (!datasource.StartsWith("field:") && !datasource.StartsWith("code:") && !datasource.StartsWith("query:"))))));

        public void Process(ParseDataSourceArgs args)
        {
            if (ServiceProviderServiceExtensions.GetService<IContext>(ServiceLocator.ServiceProvider).Site.IsSxaSite() && !this.IsDatasourceValid(args.Datasource))
            { 
                args.AbortPipeline();
            }
        }
    }
}