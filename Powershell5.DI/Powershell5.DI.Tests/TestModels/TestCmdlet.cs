namespace Powershell5.DI.Tests.TestModels
{
    using System.Security.AccessControl;

    using UTMO.Powershell5.DI.CmdletBase;

    public class TestCmdlet : DiBaseCmdlet
    {
        [ShouldInject]
        private string TestProperty { get; set; }

        protected override void ProcessCmdletRecord()
        {
            this.WriteObject(this.TestProperty);
        }
    }
}