using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Powershell5.DI.Tests
{
    using System.Linq;
    using System.Management.Automation;

    using Moq;

    using Powershell5.DI.Tests.TestModels;

    using UTMO.Powershell5.DI.DI;

    [TestClass]
    public class DITests
    {
        [TestMethod]
        public void TestMethod1()
        {
            var cmdlet = new TestCmdlet();

            string returnedMessage = cmdlet.Invoke<string>().First();

            Assert.IsTrue(returnedMessage == "DI Successful");
        }
    }
}
