namespace Powershell5.Helpers.CmdletExtentions
{
    using System.Management.Automation;

    public static class PowerShellRunTimeVariablesExtensions
    {
        public static void SetPsVariable(this PSCmdlet cmdlet, string name, object value)
        {
            cmdlet.SessionState.PSVariable.Set(name, value);
        }

        public static T GetPsVariable<T>(this PSCmdlet cmdlet, string name, object defaultValue = null)
        {
            return (T)cmdlet.SessionState.PSVariable.GetValue(name, defaultValue);
        }
    }
}