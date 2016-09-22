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
            throw new NotImplementedException();
        }

        public void AddVariable(Variable newVariable)
        {
            throw new NotImplementedException();
        }

        public Variable Find(string variableName)
        {
            throw new NotImplementedException();
        }

        public Variable ClearVariable(string variableName)
        {
            throw new NotImplementedException();
        }

        public void ClearAll()
        {
            throw new NotImplementedException();
        }
    }
}
