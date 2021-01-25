using Newtonsoft.Json;
using System;

namespace DataValidation
{
    public class Step1Output
    {
        public string FullName { get; set; }

        public string Message { get; set; }
    }

    public class Step2Output
    {
        public string City { get; set; }
        public int ValidationCount { get; set; }

    }
}
