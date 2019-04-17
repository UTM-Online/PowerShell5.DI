namespace Powershell5.Helpers.CmdletBase
{
    using System;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;

    public abstract class AbstractBaseCmdlet : Cmdlet
    {
        protected virtual void BeginCmdletProcessing()
        {
        }

        protected virtual void ProcessCmdletRecord()
        {
        }

        protected virtual void EndCmdletProcessing()
        {
        }

        protected virtual void StopCmdletProcessing()
        {
        }

        protected sealed override void BeginProcessing()
        {
            if (this.GetType()
                    .GetProperties(BindingFlags.NonPublic)
                    .Where(
                           p => p.CustomAttributes.Any(a => a.AttributeType == typeof(ShouldInjectAttribute))
                           ) is List<PropertyInfo> injectableProperties
                    && injectableProperties.Any())
            {
                foreach (var property in injectableProperties)
                {
                    // ReSharper disable once SuggestVarOrType_BuiltInTypes
                    string resolverName = property.GetCustomAttribute<ShouldInjectAttribute>().Name;
                    var targetType = property.PropertyType;

                    object instance = null;

                    instance = string.IsNullOrWhiteSpace(resolverName) ? InternalContainer.Container.Value.Resolve(targetType) : InternalContainer.Container.Value.Resolve(targetType, resolverName);

                    property.SetValue(property, instance);
                }
            }

            this.BeginCmdletProcessing();
        }

        protected sealed override void ProcessRecord()
        {
            this.ProcessCmdletRecord();
        }

        protected sealed override void EndProcessing()
        {
            this.EndCmdletProcessing();
        }

        protected override void StopProcessing()
        {
            this.StopCmdletProcessing();
        }

        [AttributeUsage(AttributeTargets.Field | AttributeTargets.GenericParameter | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        protected sealed class ShouldInjectAttribute : Attribute
        {
            public string Name { get; set; }

            public ShouldInjectAttribute()
            {
            }

            public ShouldInjectAttribute(string name)
            {
                this.Name = name;
            }
        }
    }
}