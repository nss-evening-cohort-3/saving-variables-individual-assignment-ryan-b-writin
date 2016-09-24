using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SavingVariables.DAL;
using SavingVariables.Models;

namespace SavingVariables
{
    class Program
    {

        static void Main(string[] args)
        {
            VariableContext context = new VariableContext();
            VariableRepository repo = new VariableRepository(context);
            Lastq prev = new Lastq();
            bool _continue = true;

            Console.WriteLine("Set a variable using this format: [variable] = [value].");
            Console.WriteLine("Variables must be one letter long.");
            Console.WriteLine("Values must be less than 2,147,483,648.");
            Console.WriteLine("Input a set variable to check its value.");
            Console.WriteLine("Input Show All to see all stored variables.");
            Console.WriteLine("Input Clear [variable] to clear a variable.");
            Console.WriteLine("Input Clear All to clear all variables.");
            Console.WriteLine("Input lastq to see your last command.");
            Console.WriteLine("Input Exit or Quit to quit.");

            while (_continue)
            {
                string prompt = ">>";
                Console.Write(prompt);

                string command = Console.ReadLine().ToLower();
                switch (command)
                {
                    case "quit":
                        _continue = false;
                        break;
                    case "exit":
                        _continue = false;
                        break;
                    case "lastq":
                        Console.WriteLine(prev.lastq);
                        break;
                    case "clear all":
                        repo.ClearAll();
                        Console.WriteLine("All variables cleared!");
                        break;
                    case "show all":
                        List<Variable> ListOfVariables = repo.GetVariables();
                        Console.WriteLine("Variable -> Value");
                        foreach (Variable variable in ListOfVariables)
                        {
                            Console.WriteLine(variable.VariableName + " -> " + variable.VariableValue);
                        }
                        break;
                    default:
                        
                        prev.lastq = command;
                        Evaluation eval = new Evaluation(command);
                        if (eval.InvalidInput)
                        {
                            Console.WriteLine("Incorrect input!");
                            Console.WriteLine("Set a variable using this format: [variable] = [value].");
                            Console.WriteLine("Variables must be one letter long.");
                            Console.WriteLine("Values must be less than 2,147,483,648.");
                            Console.WriteLine("Input a set variable to check its value.");
                            Console.WriteLine("Input Clear [variable] to clear a variable.");
                            Console.WriteLine("Input Clear All to clear all variables.");
                            Console.WriteLine("Input lastq to see your last command.");
                            Console.WriteLine("Input Exit or Quit to quit.");
                            break;
                        }
                        if (eval.ClearStatement)
                        {
                            repo.ClearVariable(eval.FirstTerm);
                            Console.WriteLine("  = " + eval.FirstTerm + " cleared!");
                            break;
                        }
                        else if (eval.IsItAnEquals)
                        {
                            Variable DoesItExist = repo.Find(eval.FirstTerm);
                            if (DoesItExist == null)
                            {
                                repo.AddVariable(eval.SecondTerm, eval.FirstTerm);
                                Console.WriteLine("  = Saved " + eval.FirstTerm + " as " + eval.SecondTerm + ".");
                            }
                            else
                            {
                                Console.WriteLine("Variable already set!");
                            }
                            DoesItExist = null;
                            break;
                        }
                        else if (eval.SingleVariableEvaluation)
                        {
                            Variable DoesItExist = repo.Find(eval.FirstTerm);
                            if (DoesItExist != null)
                            {
                                Console.WriteLine("  = " + DoesItExist.VariableValue);
                            }
                            else
                            {
                                Console.WriteLine("Variable not set!");
                            }
                            break;
                        }
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
    }
}
