﻿using Microsoft.AspNetCore.Authentication;
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
            foreach (char letters in input)
            {
                if (!char.IsLetter(letters))
                    return false;
            }
            return true;
        }

        public bool NumbersOnly(string input)
        {
            foreach (char digit in input)
            {
                if (!char.IsDigit(digit))
                    return false;
            }
            return true;
        }

        public bool IsEmailValid(string input)
        {
            string pattern = @"^(?!\.)(""([^""\r\\]|\\[""\r\\])*""|" + @"([-a-z0-9!#$%&'*+/=?^_`{|}~]|(?<!\.)\.)*)(?<!\.)" + @"@[a-z0-9][\w\.-]*[a-z0-9]\.[a-z][a-z\.]*[a-z]$";

            //check first string
            if (Regex.IsMatch(input, pattern))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string GTINValidation(string input)
        {
            List<char> GTIN = new List<char>();
            string ValidatedGTIN = "";

            if(input.Length < 14)
            {
                foreach(char num in input)
                {
                    GTIN.Add(num);
                }
                
                int zeroCount = 14 - input.Length;

                for(int i = 0; i < zeroCount; i++)
                {
                    GTIN.Insert(0,'0');
                }
                ValidatedGTIN = string.Join("",GTIN);
            }

            return ValidatedGTIN;
        }
    }
}
