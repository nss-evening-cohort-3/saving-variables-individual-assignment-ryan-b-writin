using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using SavingVariables.DAL;
using Moq;
using SavingVariables.Models;
using System.Collections.Generic;
using System.Linq;

namespace SavingVariables.Tests
{
    [TestClass]
    public class VariableTests
    {
        Mock<VariableContext> mock_context { get; set; }
        Mock<DbSet<Variable>> mock_variable_table { get; set; }
        List<Variable> variableList { get; set; }
        VariableRepository repo { get; set; }

        public void ConnectMocksToDatastore()
        {
            var queryable_list = variableList.AsQueryable();

            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.Provider).Returns(queryable_list.Provider);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.Expression).Returns(queryable_list.Expression);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.ElementType).Returns(queryable_list.ElementType);
            mock_variable_table.As<IQueryable<Variable>>().Setup(m => m.GetEnumerator()).Returns(() => queryable_list.GetEnumerator());

            mock_context.Setup(c => c.Variables).Returns(mock_variable_table.Object);

            mock_variable_table.Setup(t => t.Add(It.IsAny<Variable>())).Callback((Variable a) => variableList.Add(a));
            mock_variable_table.Setup(t => t.Remove(It.IsAny<Variable>())).Callback((Variable a) => variableList.Remove(a));
            mock_variable_table.Setup(t => t.RemoveRange(It.IsAny<IEnumerable<Variable>>())).Callback((IEnumerable<Variable> a) => variableList.RemoveRange(0, a.Count<Variable>()));
        }

        [TestInitialize]
        public void Initialize()
        {
            mock_context = new Mock<VariableContext>();
            mock_variable_table = new Mock<DbSet<Variable>>();
            variableList = new List<Variable>();
            repo = new VariableRepository(mock_context.Object);
        }
        [TestCleanup]
        public void Teardown()
        {
            repo = null;
        }

        [TestMethod]
        public void RepoCreateInstanceOfVariableRepo()
        {
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoHasContext()
        {
            Assert.IsNotNull(repo.Context);
        }
        [TestMethod]
        public void RepoHasNoVariables()
        {
            ConnectMocksToDatastore();

            List<Variable> variables = repo.GetVariables();
            int expected_variable_count = 0;
            int actual_variable_count = variables.Count;

            // Assert
            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }
        [TestMethod]
        public void RepoCanAddVariableToDatabase()
        {
            ConnectMocksToDatastore();
            Variable newVariable = new Variable { VariableValue = 1, VariableName = "x" };

            repo.AddVariable(newVariable);

            int actual_variable_count = repo.GetVariables().Count;
            int expected_variable_count = 1;

            // Assert
            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }
        [TestMethod]
        public void RepoCanFindVariable()
        {
            // Arrange
            variableList.Add(new Variable { VariableValue = 1, VariableName = "x" , VariableID = 1});
            variableList.Add(new Variable { VariableValue = 7, VariableName = "y" , VariableID = 2});
            variableList.Add(new Variable { VariableValue = 56, VariableName = "z", VariableID = 3});
            ConnectMocksToDatastore();

            // Act
            string variableName = "y";
            Variable actual_variable = repo.Find(variableName);

            // Assert
            int expected_variable_id = 2;
            int actual_variable_id = actual_variable.VariableID;
            Assert.AreEqual(expected_variable_id, actual_variable_id);

        }
        [TestMethod]
        public void RepoCanClearVariable()
        {

            variableList.Add(new Variable { VariableValue = 1, VariableName = "x", VariableID = 1 });
            variableList.Add(new Variable { VariableValue = 7, VariableName = "y", VariableID = 2 });
            variableList.Add(new Variable { VariableValue = 56, VariableName = "z", VariableID = 3 });
            ConnectMocksToDatastore();

            string variableName = "y";
            Variable removed_variable = repo.ClearVariable(variableName);
            int expected_variable_count = 2;
            int actual_variable_count = repo.GetVariables().Count;
            int expected_variable_id = 2;
            int actual_variable_id = removed_variable.VariableID;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
            Assert.AreEqual(expected_variable_id, actual_variable_id);
        }
        [TestMethod]
        public void RepoCanNotRemoveThingsNotThere()
        {
            variableList.Add(new Variable { VariableValue = 1, VariableName = "x", VariableID = 1 });
            variableList.Add(new Variable { VariableValue = 7, VariableName = "y", VariableID = 2 });
            variableList.Add(new Variable { VariableValue = 56, VariableName = "z", VariableID = 3 });
            ConnectMocksToDatastore();

            string variableName = "w";
            Variable removed_author = repo.ClearVariable(variableName);

            Assert.IsNull(removed_author);

        }
        [TestMethod]
        public void RepoCanAddNewValueAfterClearing()
        {
            variableList.Add(new Variable { VariableValue = 1, VariableName = "x" });
            ConnectMocksToDatastore();

            string variableName = "x";
            repo.ClearVariable(variableName);

            variableList.Add(new Variable { VariableValue = 8, VariableName = "x" });

            int expected_variable_value = 8;
            Variable actual_variable = repo.Find(variableName);

            Assert.AreEqual(expected_variable_value, actual_variable.VariableValue);
        }
        [TestMethod]
        public void RepoCanClearAll()
        {
            variableList.Add(new Variable { VariableValue = 1, VariableName = "x", VariableID = 1 });
            variableList.Add(new Variable { VariableValue = 7, VariableName = "y", VariableID = 2 });
            variableList.Add(new Variable { VariableValue = 56, VariableName = "z", VariableID = 3 });
            ConnectMocksToDatastore();

            repo.ClearAll();
            int expected_variable_count = 0;
            int actual_variable_count = repo.GetVariables().Count;

            Assert.AreEqual(expected_variable_count, actual_variable_count);
        }
    }
}
