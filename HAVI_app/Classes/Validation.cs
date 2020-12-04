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

            /*
            double number;
            if(input != null)
            {
                if (Double.TryParse(input, out number))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false; */
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

        public int GTINValidation(int? input)
        {
            string temp = input.ToString();
            List<char> GTIN = new List<char>();
            string ValidatedGTIN = "";

            if(temp.Length < 14)
            {
                foreach(char num in temp)
                {
                    GTIN.Add(num);
                }
                
                int zeroCount = 14 - temp.Length;

                for(int i = 0; i < zeroCount; i++)
                {
                    GTIN.Insert(0,'0');
                }
                ValidatedGTIN = string.Join("",GTIN);
            }

            return Convert.ToInt32(ValidatedGTIN);
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
