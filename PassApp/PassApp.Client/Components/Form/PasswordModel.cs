﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PassApp.Client.Components.Form
{
    public class PasswordModel
    {
        public string Password { get; set; }
        public bool IncludeLowercase { get; set; } = true;
        public bool IncludeUppercase { get; set; } = true;
        public bool IncludeSpecialChars { get; set; } = true; 
        public bool IncludeNumbers { get; set; } = true;
        public int PasswordLength { get; set; } = 16;

        private static string Lowercase => "abcdefghjkmnpqrstuvwxyz";
        private static string Uppercase => Lowercase.ToUpper();
        private static string SpecialChars => "~!@#$%^&*-_+=?";
        private static string Numbers => "123456789";

        public void GeneratePassword()
        {
            if (!IncludeLowercase && !IncludeUppercase && !IncludeSpecialChars && !IncludeNumbers)
                return;

            var random = RandomNumberGenerator.Create();
            var includedChars = string.Empty;
            includedChars += IncludeLowercase ? Lowercase : string.Empty;
            includedChars += IncludeUppercase ? Uppercase : string.Empty;
            includedChars += IncludeSpecialChars ? SpecialChars : string.Empty;
            includedChars += IncludeNumbers ? Numbers : string.Empty;

            var sb = new StringBuilder();
            for (int i = 0; i < PasswordLength; i++)
                sb = sb.Append(GetChar(includedChars, random));

            Password = sb.ToString();
        }
        private static char GetChar(string includedChars, RandomNumberGenerator random)
        {
            var byteArray = new byte[1];
            char c;
            do
            {
                random.GetBytes(byteArray);
                c = (char)byteArray[0];
            } while (!includedChars.Any(x => x == c));

            return c;
        }
    }
}
