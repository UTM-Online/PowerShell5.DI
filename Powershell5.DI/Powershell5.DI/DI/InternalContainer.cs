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
    using System.Reflection;

    using UTMO.Powershell5.DI.Exceptions;

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
        /// <returns>The type implementing <see cref="IPowerShellDiContainer"/>.</returns>
        private static IPowerShellDiContainer LoadContainer()
        {
            var containerInterface = typeof(IPowerShellDiContainer);

            var loadedAssemblies = AppDomain.CurrentDomain.GetAssemblies();

            var discoveredTypes = loadedAssemblies.SelectMany(a => a.GetTypes());

            var discoveredContainers = discoveredTypes.Where(a => a.Namespace != null && (a.IsClass && !a.Namespace.StartsWith("UTMO.PowerShell5.DI.Unity") && containerInterface.IsAssignableFrom(a))).ToList();

            //// TODO: Add a guard clause here that will fail fast if no containers are discovered

            Type targetContainer;

            if (discoveredContainers.Count() > 1)
            {
                var containerAttribute = typeof(PowerShellDiContainerAttribute);

                var containersWithAttributeApplied = discoveredContainers.Where(c => c.GetCustomAttribute(containerAttribute) != null).ToList();

                if (containersWithAttributeApplied.Count() == 1)
                {
                    targetContainer = containersWithAttributeApplied.First();
                }
                else
                {
                    throw new TooManyContainersException(containersWithAttributeApplied);
                }
            }
            else if (discoveredContainers.Count() == 1)
            {
                targetContainer = discoveredContainers.First();
            }
            else
            {
                throw new ContainerNotFoundException();
            }

            return (IPowerShellDiContainer)Activator.CreateInstance(targetContainer);
        }
    }
}