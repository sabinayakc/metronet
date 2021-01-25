using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public abstract class Validator : IValidator<string>
    {
        private readonly string Pattern;
        private readonly bool IsEnabled;
        public Validator(bool isEnabled,string pattern)
        {
            Pattern = pattern;
            IsEnabled = isEnabled;
        }

        public virtual bool IsValid(string value)
        {
            return !IsEnabled || Regex.IsMatch(value, Pattern);
        }
    }
}
