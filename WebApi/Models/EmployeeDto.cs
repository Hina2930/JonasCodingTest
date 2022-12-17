using System;
using Newtonsoft.Json;

namespace WebApi.Models
{
    public class EmployeeDto : BaseDto
    {
        public string EmployeeCode { get; set; }
        public string EmployeeName { get; set; }
        public string CompanyName { get; set; }

        [JsonProperty("OccupationName")]
        public string Occupation { get; set; }
        public string EmployeeStatus { get; set; }
        public string EmailAddress { get; set; }
        [JsonProperty("PhoneNumber")]
        public string Phone { get; set; }
        [JsonProperty("LastModifiedDateTime")]
        public DateTime LastModified { get; set; }
    }

}