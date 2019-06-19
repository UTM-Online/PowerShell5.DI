namespace UTMO.Powershell5.DI.Exceptions
{
    using System;
    using System.Collections.Generic;

    using UTMO.Powershell5.DI.DI;

    public class TooManyContainersException : Exception
    {
        //// TODO: this message is rather massive and should be optimized away to a resex or strings file
        public TooManyContainersException(IEnumerable<Type> discoveredTypes) : base($"More then one type was discovered that had the {nameof(PowerShellDiContainerAttribute)} attribute applied.\r\nUpdate your code so that only a single type that has {nameof(PowerShellDiContainerAttribute)} applied to it is present.\r\n For more details check the {nameof(DiscoveredTypes)} property of this exception in PowerShell or a debugger to view what types were discovered with the {nameof(PowerShellDiContainerAttribute)} applied to them.")
        {
            this.DiscoveredTypes = discoveredTypes;
        }

        public IEnumerable<Type> DiscoveredTypes { get; set; }
    }
}