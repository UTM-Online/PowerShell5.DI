namespace Powershell5.Helpers.CmdletExtentions
{
    using System.Collections;
    using System.Collections.ObjectModel;
    using System.Management.Automation;

    using Powershell5.Helpers.Models;

    public static class InvokeCmdletExtensions
    {
        public static void InvokePsCmdlet(this Cmdlet _, string cmdletName, CmdletParameterSet parameters = null, IEnumerable pipelineInput = null)
        {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand(cmdletName);

                if (parameters != null)
                {
                    ps.AddParameters(parameters);
                }

                if (pipelineInput != null)
                {
                    ps.Invoke(pipelineInput);
                }
                else
                {
                    ps.Invoke();
                }
            }
        }

        public static Collection<T> InvokePsCommand<T>(
            this Cmdlet _,
            string cmdletName,
            CmdletParameterSet parameters = null,
            IEnumerable pipelineInput = null)
        {
            using (var ps = PowerShell.Create(RunspaceMode.CurrentRunspace))
            {
                ps.AddCommand(cmdletName);

                if (parameters != null)
                {
                    ps.AddParameters(parameters);
                }

                if (pipelineInput != null)
                {
                    return ps.Invoke<T>(pipelineInput);
                }
                else
                {
                    return ps.Invoke<T>();
                }
            }
        }
    }
}