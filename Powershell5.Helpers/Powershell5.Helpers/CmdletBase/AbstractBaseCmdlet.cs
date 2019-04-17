// ***********************************************************************
// Assembly         : Powershell5.Helpers
// Author           : joirwi
// Created          : 04-17-2019
//
// Last Modified By : joirwi
// Last Modified On : 04-17-2019
// ***********************************************************************
// <copyright file="AbstractBaseCmdlet.cs" company="">
//     Copyright ©  2019
// </copyright>
// <summary></summary>
// ***********************************************************************
namespace Powershell5.Helpers.CmdletBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;

    /// <summary>
    /// Class AbstractBaseCmdlet.
    /// Implements the <see cref="System.Management.Automation.Cmdlet" />
    /// </summary>
    /// <seealso cref="System.Management.Automation.Cmdlet" />
    public abstract class AbstractBaseCmdlet : Cmdlet
    {
        /// <summary>
        /// Begins the cmdlet processing.
        /// </summary>
        protected virtual void BeginCmdletProcessing()
        {
        }

        /// <summary>
        /// Processes the cmdlet record.
        /// </summary>
        protected virtual void ProcessCmdletRecord()
        {
        }

        /// <summary>
        /// Ends the cmdlet processing.
        /// </summary>
        protected virtual void EndCmdletProcessing()
        {
        }

        /// <summary>
        /// Stops the cmdlet processing.
        /// </summary>
        protected virtual void StopCmdletProcessing()
        {
        }

        /// <summary>
        /// Begins the processing.
        /// </summary>
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

        /// <summary>
        /// Processes the record.
        /// </summary>
        protected sealed override void ProcessRecord()
        {
            this.ProcessCmdletRecord();
        }

        /// <summary>
        /// Ends the processing.
        /// </summary>
        protected sealed override void EndProcessing()
        {
            this.EndCmdletProcessing();
        }

        /// <summary>
        /// Stops the processing.
        /// </summary>
        protected override void StopProcessing()
        {
            this.StopCmdletProcessing();
        }

        /// <summary>
        /// Class ShouldInjectAttribute. This class cannot be inherited.
        /// Implements the <see cref="System.Attribute" />
        /// </summary>
        /// <seealso cref="System.Attribute" />
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.GenericParameter | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        protected sealed class ShouldInjectAttribute : Attribute
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name.</value>
            public string Name { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ShouldInjectAttribute"/> class.
            /// </summary>
            public ShouldInjectAttribute()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ShouldInjectAttribute"/> class.
            /// </summary>
            /// <param name="name">The name.</param>
            public ShouldInjectAttribute(string name)
            {
                this.Name = name;
            }
        }
    }
}