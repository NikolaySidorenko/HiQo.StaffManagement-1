using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Castle.Windsor;

namespace HiQo.StaffManagement.Configuration.ApiDependecyResolver
{
    class WindsorFilterProvider : IFilterProvider
    {
        
        private readonly IWindsorContainer _container;

        public WindsorFilterProvider(IWindsorContainer container)
        {
            _container = container;
        }

        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var filters = new ActionDescriptorFilterProvider().GetFilters(configuration,actionDescriptor);

            foreach (var filter in filters)
            {
                _container.InjectPropertiesTo(filter.Instance);
                yield return filter;
            }
        }
    }
}
