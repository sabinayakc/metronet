using DataValidation.Validators;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace DataValidation.Tests
{
    public class ValidateContactTest
    {
        private string URL => "https://www.metronetinc.com/wp-content/uploads/app/MetroNetDeveloperDataFile-2020-08-31";

        [Fact]
        public void Should_Be_Able_To_Validate_Contact()
        {
            var contacts = new List<Contact>();
            using (var webClient = new System.Net.WebClient())
            {
                var json = webClient.DownloadString(URL);
                contacts = JsonConvert.DeserializeObject<List<Contact>>(json);
            }
            var factory = new ValidatorFactory();
            var validators = new Validator[typeof(Contact).GetProperties().Length];

            var index = 0;
            foreach(var property  in  typeof(Contact).GetProperties())
            {
                validators[index]=factory.GetValidator(property.Name);
                index++;
            }

            var result = contacts.Select(s => ValidatorMap.RunValidation(validators, s));

            var output1 = result.Select(s => s.Item1).OrderBy(s => s.FullName);
            var output2 = result.Select(s => s.Item2).OrderBy(s => s.ValidationCount);

            Assert.NotEmpty(output1);
            Assert.NotEmpty(output2);
        }

    }
}
