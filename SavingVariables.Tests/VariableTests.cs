using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavingVariables.DAL;
using Moq;
using SavingVariables.Models;
using System.Collections.Generic;

namespace SavingVariables.Tests
{
    [TestClass]
    public class VariableTests
    {
        Mock<VariableContext> mock_context { get; set; }
        Mock<DbSet<Variable>> mock_variable_table { get; set; }
        List<Variable> VariableList { get; set; }
        VariableRepository repo { get; set; }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<VariableContext>();
            mock_variable_table = new Mock<DbSet<Variable>>();
            VariableList = new List<Variable>();
            repo = new VariableRepository(mock_context.Object);
        }
        [TestCleanup]
        public void Teardown()
        {
            repo = null;
        }

        [TestMethod]
        public void CreateInstanceOfVariableRepo()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoHasContext()
        {
            Assert.IsNotNull(repo.Context);
        }
    }
}
