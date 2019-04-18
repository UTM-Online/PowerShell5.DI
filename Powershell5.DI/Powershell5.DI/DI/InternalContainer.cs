namespace Powershell5.Helpers
{
    using System;
    using System.Linq;
    using System.Reflection;

    internal static class InternalContainer
    {
        static InternalContainer()
        {
            Container = new Lazy<IPowerShellDiContainer>(LoadContainer);
        }

        internal static Lazy<IPowerShellDiContainer> Container { get; set; }

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