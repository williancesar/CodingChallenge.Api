using System;
using System.ComponentModel.DataAnnotations;

namespace CodingChallenge.Api.Validation
{
    public class RequiredGreaterThanZero : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            int validationValue;
            
            Int32.TryParse(value.ToString(), out validationValue);

            return validationValue > 0;
        }
    }
}
