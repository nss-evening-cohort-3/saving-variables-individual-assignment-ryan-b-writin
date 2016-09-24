using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SavingVariables
{
    class Program
    {

        static void Main(string[] args)
        {
            Lastq prev = new Lastq();
            bool _continue = true;

            Console.WriteLine("Incorrect input!");
            Console.WriteLine("Set a variable using this format: [variable] = [value]. The variable must be one letter long.");
            Console.WriteLine("Input a set variable to check its value.");
            Console.WriteLine("Input Show All to see all stored variables.");
            Console.WriteLine("Input Clear [variable] to clear a variable");
            Console.WriteLine("Input Clear All to clear all variables.");
            Console.WriteLine("Input lastq to see your last command.");
            Console.WriteLine("Input Exit or Quit to quit");

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
                        //clear all
                        Console.WriteLine("All variables cleared!");
                        break;
                    case "show all":
                        Console.WriteLine("Variable -> Value");
                        //show all
                        break;
                    default:
                        
                        prev.lastq = command;
                        Evaluation eval = new Evaluation(command);
                        if (eval.InvalidInput)
                        {
                            Console.WriteLine("Incorrect input!");
                            Console.WriteLine("Set a variable using this format: [variable] = [value]. The variable must be one letter long.");
                            Console.WriteLine("Input a set variable to check its value.");
                            Console.WriteLine("Input Clear [variable] to clear a variable");
                            Console.WriteLine("Input Clear All to clear all variables.");
                            Console.WriteLine("Input lastq to see your last command.");
                            Console.WriteLine("Input Exit or Quit to quit");
                            break;
                        }
                        if (eval.ClearStatement)
                        {
                            //clear [second term]
                            break;
                        }
                        if (eval.IsItAnEquals)
                        {
                            //set variable
                            break;
                        }
                        if (eval.SecondTerm == null)
                        {
                            //get single variable
                            break;
                        }
                        Console.WriteLine("Error!");
                        break;
                }
            }
        }
    }
}
