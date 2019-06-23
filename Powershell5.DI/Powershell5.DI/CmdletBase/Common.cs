namespace UTMO.Powershell5.DI.CmdletBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;

    using UTMO.Powershell5.DI.DI;

    public static class Common
    {
        public static void PerformFieldInjection<T>(this Cmdlet cmdlet) where T : Attribute, IShouldInject
        {
            List<PropertyInfo> injectableProperties = cmdlet.GetType().GetProperties(BindingFlags.NonPublic | BindingFlags.Instance).Where(
                     p => p.CustomAttributes.Any(a => a.AttributeType == typeof(T))).ToList();

            if (injectableProperties.Any())
            {
                foreach (var property in injectableProperties)
                {
                    // ReSharper disable once SuggestVarOrType_BuiltInTypes
                    string resolverName = property.GetCustomAttribute<T>().Name;
                    var targetType = property.PropertyType;

                    var instance = string.IsNullOrWhiteSpace(resolverName)
                                       ? InternalContainer.Container.Value.Resolve(targetType)
                                       : InternalContainer.Container.Value.Resolve(targetType, resolverName);

                    property.SetValue(cmdlet, instance);
                }
            }
        }
    }
}