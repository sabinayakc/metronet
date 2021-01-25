using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DataValidation.Validators
{
    public static class ValidatorMap 
    {
        public static IDictionary<string, Validator> ValidatorMapDictionary => new Dictionary<string, Validator>
        {
            {"FullName",new FullNameValidator(false,@"^[A-Z][a-z]*(\s[A-Z][a-z]*)+$")},
            {"CityName",new CityValidator(false,@"^([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$")},
            {"PhoneNumber", new PhoneNoValidator(true,@"^(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]\d{3}[\s.-]\d{4}$")},
            {"EmailAddress", new EmailValidator(true, @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z") },
        };

        public static Tuple<Step1Output, Step2Output> RunValidation(Validator[] validators, Contact value)
        {
            int index = 0;
            var dictionary = new Dictionary<string, bool>();
            foreach (var val in value.GetType().GetProperties())
            {
                var param = val.GetValue(value).ToString();
                var isValid = validators[index].IsValid(param);
                index++;
                dictionary.Add(val.Name, isValid);
            }

            var count = dictionary.Where(s => s.Value == false).Count();
            var message = "";
            if (count == 0)
            {
                message = "Valid";
            }
            else if (count == 1)
            {
                message = dictionary.Where(s => s.Value == false).Select(s => s.Key).FirstOrDefault() + " is Invalid";
            }
            else
            {
                message = dictionary.Where(s => s.Value == false).Select(s => s.Key).Aggregate((sum, val) => $"{sum}, {val}") + " are invalid";
            }

            var step1 = new Step1Output()
            {
                FullName = value.FullName,
                Message = message
            };

            var step2 = new Step2Output()
            {
                City = value.CityName,
                ValidationCount = count
            };
            return Tuple.Create(step1, step2);
        }
    }

}
