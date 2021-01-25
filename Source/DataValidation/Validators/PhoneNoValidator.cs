using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public class PhoneNoValidator : Validator
    {
        public PhoneNoValidator(bool isEnabled, string pattern) : base(isEnabled, pattern)
        {
        }

    }
}
