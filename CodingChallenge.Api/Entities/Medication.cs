using CodingChallenge.Api.Validation;

namespace CodingChallenge.Api.Entities
{
    public class Medication : BaseEntity
    {
        public int Code { get; set; }

        public string Name { get; set; }
        
        [RequiredGreaterThanZero(ErrorMessage = "Quantity must be greater tha 0.")]
        public int Quantity { get; set; }
    }
}
