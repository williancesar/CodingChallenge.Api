using CodingChallenge.Api.Data;
using CodingChallenge.Api.Entities;
using CodingChallenge.Api.Repositories.Interfaces;

namespace CodingChallenge.Api.Repositories.Implementations
{
    public class MedicationRepository : BaseRepository<Medication>, IMedicationRespository
    {
        public MedicationRepository(ChallengeDbContext context) 
            : base(context)
        {
            this.context = context;
        }
    }
}
