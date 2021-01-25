using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public class DefaultValidator : Validator
    {
        public DefaultValidator(bool isEnabled, string pattern) : base(isEnabled, pattern)
        {
          
        }


    }
}
