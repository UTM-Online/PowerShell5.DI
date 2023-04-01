namespace UTMO.Powershell5.DI.Exceptions
{
  using System;
  using System.Runtime.CompilerServices;

  public class InjectablePropertyMissingSetterException : ApplicationException
  {
    public InjectablePropertyMissingSetterException(string propertyName, string missingAccessor) : base(message: $"The property \"{propertyName}\" is missing the following accessor \"{missingAccessor}\"")
    {
      this.propertyName = propertyName;
      this.MissingAccessor = missingAccessor;
    }

    public string propertyName { get; }

    public string MissingAccessor { get; }
  }
}