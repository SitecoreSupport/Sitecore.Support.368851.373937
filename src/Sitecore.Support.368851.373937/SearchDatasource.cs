using Sitecore.Pipelines.ResolveRenderingDatasource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sitecore.Support
{
    public class SearchDatasource : Sitecore.XA.Foundation.Search.Pipelines.ResolveRenderingDatasource.SearchDatasource
    {
        protected override bool IsDatasourceValid(string datasource) =>
           ((datasource.Length > 1) && (datasource.Contains(":") && (!datasource.StartsWith("local:") && (!datasource.StartsWith("page:") && (!datasource.StartsWith("field:") && !datasource.StartsWith("code:") && !datasource.StartsWith("query:"))))));

        public new void Process(ResolveRenderingDatasourceArgs args)
        {
            if (this.IsDatasourceValid(args.Datasource))
            {
                base.Process(args);
            }
        }
    }
}