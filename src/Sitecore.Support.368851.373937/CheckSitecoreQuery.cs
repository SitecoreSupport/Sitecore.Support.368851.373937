using Sitecore.DependencyInjection;
using Sitecore.Pipelines.ResolveRenderingDatasource;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.XA.Foundation.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Sitecore.XA.Foundation.Multisite.Extensions;

namespace Sitecore.Support
{
    public class CheckSitecoreQuery
    {
        protected bool IsDatasourceValid(string datasource) =>
           ((datasource.Length > 1) && (datasource.Contains(":") && (!datasource.StartsWith("local:") && (!datasource.StartsWith("page:") && (!datasource.StartsWith("field:") && !datasource.StartsWith("code:") && !datasource.StartsWith("query:"))))));

        public void Process(ResolveRenderingDatasourceArgs args)
        {
            if (ServiceProviderServiceExtensions.GetService<IContext>(ServiceLocator.ServiceProvider).Site.IsSxaSite() && !this.IsDatasourceValid(args.Datasource))
            { 
                args.AbortPipeline();
            }
        }
    }
}