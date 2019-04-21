// ***********************************************************************
// Assembly         : UTMO.Powershell5.DI
// Author           : joirwi
// Created          : 04-18-2019
//
// Last Modified By : joirwi
// Last Modified On : 04-18-2019
// ***********************************************************************
// <copyright file="InternalContainer.cs" company="UTM-Online">
//     Copyright ©  2019
// </copyright>
// <summary>
//     The internal container implementation.  This class is used to abstract the custom implementation of IPowerShellDiContainer away from the cmdlet base classes
//     that consume the containers.
//     NOTE: There can only be class that implements IPowerShellDiContainer.  Having more then one can result in undesired behavior in your cmdlets.
// </summary>
// ***********************************************************************
namespace UTMO.Powershell5.DI.DI
{
    using System;
    using System.Linq;

    /// <summary>
    /// Class InternalContainer.
    /// </summary>
    internal static class InternalContainer
    {
        /// <summary>
        /// Initializes static members of the <see cref="InternalContainer"/> class.
        /// </summary>
        static InternalContainer()
        {
            Container = new Lazy<IPowerShellDiContainer>(LoadContainer);
        }

        /// <summary>
        /// Gets or sets the container.
        /// </summary>
        /// <value>The container.</value>
        internal static Lazy<IPowerShellDiContainer> Container { get; set; }

        /// <summary>
        /// Loads the container.
        /// </summary>
        /// <returns>IPowerShellDiContainer.</returns>
        private static IPowerShellDiContainer LoadContainer()
        {
            var type = typeof(IPowerShellDiContainer);

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var knownTypes = loadedAssemblies.SelectMany(a => a.GetTypes());

            var containerType = knownTypes.First(a => type.IsAssignableFrom(a));

            return (IPowerShellDiContainer)Activator.CreateInstance(containerType);
        }
    }
}