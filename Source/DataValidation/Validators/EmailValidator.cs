using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public class EmailValidator : Validator
    {
        private readonly string Pattern;
        public EmailValidator(bool isEnabled, string pattern) : base(isEnabled, pattern)
        {
            Pattern = pattern;
        }

        public override bool IsValid(string value)
        {
          return Regex.IsMatch(value, Pattern, RegexOptions.IgnoreCase);
        }

    }
}
