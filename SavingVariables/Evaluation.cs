using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace SavingVariables
{
    public class Evaluation
    {
        public bool InvalidInput { get; set; }
        public bool ClearStatement { get; set; }
        public bool IsItAnEquals { get; set; }

        public string FirstTerm { get; set; }
        public int SecondTerm { get; set; }

        string CheckForClear = @"^[c][l][e][a][r][ ]*([a-z])$";
        string CheckForEquals = @"^([a-z])[ ]*[=][ ]*([0-9])*$";
        string SingleVariable = @"^([a-z])$";

        public Evaluation(string command)
        {
            Match mClear = Regex.Match(command, CheckForClear);
            Match mEquals = Regex.Match(command, CheckForEquals);
            Match mSingle = Regex.Match(command, SingleVariable);

            if (mClear.Success)
            {
                ClearStatement = true;
                FirstTerm = mClear.Groups[1].Value;
            }
            else if (mEquals.Success)
            {
                IsItAnEquals = true;
                FirstTerm = mEquals.Groups[1].Value;
                SecondTerm = Int32.Parse(mEquals.Groups[2].Value);
            }
            else if (mSingle.Success)
            {
                FirstTerm = mSingle.Groups[1].Value;
            }
            else
            {
                InvalidInput = true;
            }
        }
    }
}
