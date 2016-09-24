using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.Models;
using System.Data.Entity;

namespace SavingVariables.DAL
{
    public class VariableContext : DbContext
    {
        public virtual DbSet<Variable> Variables { get; set; }
    }
}
