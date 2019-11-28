using CodingChallenge.Api.Entities;
using CodingChallenge.Api.Repositories.Interfaces;
using CodingChallenge.Api.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace CodingChallenge.Api.Controllers
{
    [Route("api/[controller]")]
    public class MedicationController : Controller
    {
        private readonly IMedicationRespository medicationRepository;
        private readonly ILogger<MedicationController> logger;

        public MedicationController(IMedicationRespository medicationRepository,
                                    ILogger<MedicationController> logger)
        {
            Guard.IsNotNull(medicationRepository, nameof(medicationRepository));
            Guard.IsNotNull(logger, nameof(logger));

            this.medicationRepository = medicationRepository;
            this.logger = logger;
        }

        [HttpGet]
        public IEnumerable<Medication> Get()
        {
            return this.medicationRepository.Get();
        }

        [HttpPost]
        public IActionResult Post([FromBody]Medication medication)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var medicationToInsert = this.medicationRepository.GetById(medication.Id);

            if (medicationToInsert != null)
            {
                return Conflict("Medication already exists.");
            }

            this.medicationRepository.Insert(medication);

            return Ok(medication);
        }

        [HttpDelete("{guid}")]
        public IActionResult Delete(string guid)
        {
            Guid guidToRemove;

            Guid.TryParse(guid, out guidToRemove);

            var medicationToRemove = this.medicationRepository.GetById(guidToRemove);

            if (medicationToRemove == null)
            {
                return NotFound();
            }

            this.medicationRepository.Delete(guidToRemove);

            return NoContent();
        }
    }
}