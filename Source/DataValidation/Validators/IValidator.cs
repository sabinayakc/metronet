﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DataValidation.Validators
{
    public interface IValidator<T>
    {
        bool IsValid(T value);
    }
}
