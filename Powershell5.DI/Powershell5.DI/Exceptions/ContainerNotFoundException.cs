namespace UTMO.Powershell5.DI.Exceptions
{
    using System;

    using UTMO.Powershell5.DI.DI;

    public class ContainerNotFoundException : Exception
    {
        public ContainerNotFoundException() : base($"No containers were found that implement the {nameof(IPowerShellDiContainer)} interface.")
        {
            
        }
    }
}