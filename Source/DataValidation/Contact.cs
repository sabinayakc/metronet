using Newtonsoft.Json;
using System;

namespace DataValidation
{
    public class Contact
    {
        [JsonProperty("fullName")]
        public string FullName { get; set; }

        [JsonProperty("cityName")]
        public string CityName { get; set; }

        [JsonProperty("phoneNumber")]
        public string PhoneNumber { get; set; }

        [JsonProperty("emailAddress")]
        public string EmailAddress { get; set; }
    }
}
