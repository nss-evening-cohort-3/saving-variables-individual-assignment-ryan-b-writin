using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables.Tests
{
    [TestClass]
    public class InterfaceTests
    {
        [TestMethod]
        public void IntCanCreateInstance()
        {
            Lastq last = new Lastq();
            Assert.IsNotNull(last);
        }
        [TestMethod]
        public void IntCanStoreLastCommand()
        {
            Lastq last = new Lastq();
            string TestMessage = "hello there";
            last.lastq = TestMessage;
            Assert.AreEqual(TestMessage, last.lastq);
        }
    }
}
