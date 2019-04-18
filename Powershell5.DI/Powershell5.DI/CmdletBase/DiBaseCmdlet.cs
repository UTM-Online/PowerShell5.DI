// ***********************************************************************
// Assembly         : Powershell5.Helpers
// Author           : joirwi
// Created          : 04-17-2019
//
// Last Modified By : joirwi
// Last Modified On : 04-17-2019
// ***********************************************************************
// <copyright file="DiBaseCmdlet.cs" company="UTM-Online">
//     Copyright ©  2019
// </copyright>
// <summary>The base class for use with cmdlets that want Dependance Injection and want to derive them selves from the Cmdlet Base Class</summary>
// ***********************************************************************
namespace UTMO.Powershell5.DI.CmdletBase
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Management.Automation;
    using System.Reflection;
    using DI;

    /// <summary>
    /// Class DiBaseCmdlet.
    /// Implements the <see cref="System.Management.Automation.Cmdlet" />
    /// </summary>
    /// <seealso cref="System.Management.Automation.Cmdlet" />
    public abstract class DiBaseCmdlet : Cmdlet
    {
        /// <summary>
        /// This method replaces the call you would make to the "BeginProcessing" method on the <see cref="PSCmdlet"/> class.
        /// </summary>
        protected virtual void BeginCmdletProcessing()
        {
        }

        /// <summary>
        /// This method replaces the call you would make to the "ProcessRecord" method on the <see cref="PSCmdlet"/> class.
        /// </summary>
        protected virtual void ProcessCmdletRecord()
        {
        }

        /// <summary>
        /// This method replaces the call you would make to the "EndProcessing" method on the <see cref="PSCmdlet"/> class.
        /// </summary>
        protected virtual void EndCmdletProcessing()
        {
        }

        /// <summary>
        /// This method replaces the call you would make to the "StopProcessing" method on the <see cref="PSCmdlet"/> class.
        /// </summary>
        protected virtual void StopCmdletProcessing()
        {
        }

        /// <summary>
        /// Overrides the BeginProcessing method from the base class.  In this method we perform the act of injection dependencies in to properties and fields
        /// decorated with the <see cref="ShouldInjectAttribute"/>.
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

                    var instance = string.IsNullOrWhiteSpace(resolverName) ? InternalContainer.Container.Value.Resolve(targetType) : InternalContainer.Container.Value.Resolve(targetType, resolverName);

                    property.SetValue(property, instance);
                }
            }

            this.BeginCmdletProcessing();
        }

        /// <summary>
        /// Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a uniform naming convention for class
        /// methods
        /// </summary>
        protected sealed override void ProcessRecord()
        {
            this.ProcessCmdletRecord();
        }

        /// <summary>
        /// Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a uniform naming convention for class
        /// methods
        /// </summary>
        protected sealed override void EndProcessing()
        {
            this.EndCmdletProcessing();
        }

        /// <summary>
        /// Overrides the base class implementation.  Well I have no plans to add logic here it's been overriden to provide a uniform naming convention for class
        /// methods
        /// </summary>
        protected override void StopProcessing()
        {
            this.StopCmdletProcessing();
        }

        /// <summary>
        /// This class is used to decorate properties and fields that require dependency injection.
        /// This class cannot be inherited.
        /// Implements the <see cref="System.Attribute" />
        /// </summary>
        /// <seealso cref="System.Attribute" />
        [AttributeUsage(AttributeTargets.Field | AttributeTargets.GenericParameter | AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
        protected sealed class ShouldInjectAttribute : Attribute
        {
            /// <summary>
            /// Gets or sets the name.
            /// </summary>
            /// <value>The name specified for a registered type with the DI container that you want retrieved.</value>
            /// <remarks>This is useful only when you are using named dependencies in your container.</remarks>
            public string Name { get; set; }

            /// <summary>
            /// Initializes a new instance of the <see cref="ShouldInjectAttribute" /> class.
            /// </summary>
            public ShouldInjectAttribute()
            {
            }

            /// <summary>
            /// Initializes a new instance of the <see cref="ShouldInjectAttribute" /> class.
            /// </summary>
            /// <param name="name">The name.</param>
            public ShouldInjectAttribute(string name)
            {
                this.Name = name;
            }
        }
    }
}