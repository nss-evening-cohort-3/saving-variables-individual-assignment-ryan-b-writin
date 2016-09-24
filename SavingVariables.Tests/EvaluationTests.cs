using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables.Tests
{
    [TestClass]
    class EvaluationTests
    {
        [TestMethod]
        public void EvalCanCreateInstance()
        {
            Evaluation eval = new Evaluation("x = 4");
            Assert.IsNotNull(eval);
        }
        [TestMethod]
        public void EvalCanEvaluateEquals()
        {
            string command = "x = 4";
            Evaluation eval = new Evaluation(command);

            string expectedFirstTerm = "x";
            string expectedSecondTerm = "4";

            Assert.AreEqual(expectedFirstTerm, eval.FirstTerm);
            Assert.AreEqual(expectedSecondTerm, eval.SecondTerm);
            Assert.IsTrue(eval.IsItAnEquals);
        }
        [TestMethod]
        public void EvalCanEvaluateSingleVariable()
        {
            string command = "x";
            Evaluation eval = new Evaluation(command);

            string expectedFirstTerm = "x";

            Assert.AreEqual(expectedFirstTerm, eval.FirstTerm);
            Assert.IsFalse(eval.IsItAnEquals);
            Assert.IsNull(eval.SecondTerm);
        }
        [TestMethod]
        public void EvalDigitEqualsDigit()
        {
            string command = "4 = 4";
            Evaluation eval = new Evaluation(command);

            Assert.IsTrue(eval.InvalidInput);
        }
    }
}
