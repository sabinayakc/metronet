using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.Validators
{
    public class ValidatorFactory: IValidatorFactory<string>
    {
        public Validator GetValidator(string name) {
            return ValidatorMap.ValidatorMapDictionary.TryGetValue(name, out var validator) ?
                  validator : new DefaultValidator(false, "");
        }
    }
}
