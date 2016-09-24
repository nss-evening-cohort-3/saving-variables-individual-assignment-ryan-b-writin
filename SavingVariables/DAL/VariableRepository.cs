using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.Models;

namespace SavingVariables.DAL
{
    public class VariableRepository
    {
        public VariableContext Context { get; set; }
        public VariableRepository(VariableContext context)
        {
            this.Context = context;
        }

        public List<Variable> GetVariables()
        {
            return Context.Variables.ToList();
        }

        public void AddVariable(Variable newVariable)
        {
            Context.Variables.Add(newVariable);
            Context.SaveChanges();
        }
        public void AddVariable(int value, string name)
        {
            Variable variable = new Variable { VariableValue = value, VariableName = name };
            Context.Variables.Add(variable);
            Context.SaveChanges();
        }

        public Variable Find(string variableName)
        {
            Variable foundIt = Context.Variables.FirstOrDefault(v => v.VariableName.ToLower() == variableName.ToLower());
            return foundIt;
        }

        public Variable ClearVariable(string variableName)
        {
            Variable foundIt = Find(variableName);
            if (foundIt != null)
            {
                Context.Variables.Remove(foundIt);
                Context.SaveChanges();
            }
            return foundIt;
        }

        public void ClearAll()
        {
            Context.Variables.RemoveRange(Context.Variables);
            Context.SaveChanges();
        }

        public List<string> ShowAll()
        {
            throw new NotImplementedException();
        }
    }
}
