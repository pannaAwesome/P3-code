using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace HAVI_app.Classes
{
    public class Validation : ComponentBase
    {
        public bool LettersOnly(string input)
        {
            if(input != null)
            {
                foreach (char letters in input)
                {
                    if (!char.IsLetter(letters) && !char.IsWhiteSpace(letters))
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool DoubleOnly(double? input)
        {
            if(input.GetType() == typeof(double))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool IntOnly(int? input)
        {
            if (input.GetType() == typeof(int))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool NumbersLettersDashOnly(string input)
        {
            if(input != null){

                foreach (char digit in input)
                {
                    if (!char.IsLetterOrDigit(digit) && digit != '-')
                        return false;
                }
                return true;
            }
            return false;
        }

        public bool IsEmailValid(string input)
        {
            string pattern = @"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$";

            if(input != null)
            {
                if (Regex.IsMatch(input, pattern))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        public bool GTINValidation(string input)
        {
            if(input == null)
            {
                return false;
            }else if(input.ToCharArray().Length == 14)
            {
                return true;
            }else
            {
                return false;
            }
        }

        public bool MustNotBeZeroOrNegativeNumbere(double input)
        {
            if (input > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
