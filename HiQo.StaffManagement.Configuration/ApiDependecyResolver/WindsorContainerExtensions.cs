using Castle.Windsor;
using System.Linq;
using System.Reflection;

namespace HiQo.StaffManagement.Configuration.ApiDependecyResolver
{
    public static class WindsorContainerExtensions
    {
        public static void InjectPropertiesTo(this IWindsorContainer container, object target)
        {
            var type = target.GetType();
            var properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance).Where(p => p.CanWrite && container.Kernel.HasComponent(p.PropertyType));

            foreach (var property in properties)
            {
                var value = container.Resolve(property.PropertyType);
                property.SetValue(target, value, null);
            }
        }
    }
}
