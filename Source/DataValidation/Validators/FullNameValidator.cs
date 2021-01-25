using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public class FullNameValidator : Validator
    {
        public FullNameValidator(bool isEnabled,string pattern) : base(isEnabled, pattern)
        {
        }
    }
}
