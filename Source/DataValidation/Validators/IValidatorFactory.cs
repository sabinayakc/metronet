using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.Validators
{
    public interface IValidatorFactory<T>
    {
        Validator GetValidator(T key);
    }
}
