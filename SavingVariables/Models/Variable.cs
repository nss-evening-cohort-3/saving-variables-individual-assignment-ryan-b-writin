using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables.Models
{
    public class Variable
    {
        [Key]
        public int VariableID { get; set; }

        [Required]
        [MaxLength(length: 1, ErrorMessage = "Single characters only.")]
        public string VariableName { get; set; }

        [Required]
        public int VariableValue { get; set; }
    }
}
