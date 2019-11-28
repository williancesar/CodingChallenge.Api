using CodingChallenge.Api.Controllers;
using CodingChallenge.Api.Entities;
using CodingChallenge.Api.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using Xunit;

namespace CodingChallenge.Test
{
    public class MedicationControllerTests
    {
        private readonly Mock<IMedicationRespository> mockMedicationRepository;

        private readonly Mock<ILogger<MedicationController>> mockLogger;
        
        public MedicationControllerTests()
        {
            this.mockMedicationRepository = new Mock<IMedicationRespository>();
            this.mockLogger = new Mock<ILogger<MedicationController>>();
        }
        
        [Fact]
        public void MedicationController_Constructor_Valid_ValidController()
        {
            var controller = new MedicationController(
                this.mockMedicationRepository.Object,
                this.mockLogger.Object);

            Assert.NotNull(controller);
        }

        [Fact]
        public void MedicationController_Constructor_Null_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MedicationController(
                null,
                null));
        }

        [Fact]
        public void MedicationController_Constructor_NullMedicationRepository_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MedicationController(
                null,
                this.mockLogger.Object));
        }

        [Fact]
        public void MedicationController_Constructor_NullLogger_ThrowsArgumentNullException()
        {
            Assert.Throws<ArgumentNullException>(() => new MedicationController(
                this.mockMedicationRepository.Object,
                null));
        }

        [Fact]
        public void MedicationController_Get_ReturnsMedications()
        {
            // Arrange
            mockMedicationRepository.Setup(r => r.Get())
                .Returns(new List<Medication>
                { 
                    new Medication { },
                    new Medication { }
                });
            
            var controller = new MedicationController(
                mockMedicationRepository.Object, 
                mockLogger.Object);

            // Act
            var result = controller.Get();

            // Assert
            var model = Assert.IsType<List<Medication>>(result);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public void MedicationController_Post_InvalidModelState_ReturnsBadRequestResult()
        {
            // Arrange
            var invalidMedicationModel = new Medication 
            { 
                Id = Guid.NewGuid(), 
                Quantity = 0 
            };

            var controller = new MedicationController(
                mockMedicationRepository.Object,
                mockLogger.Object);

            controller.ModelState.AddModelError("Quantity", "Invalid");

            // Act
            var result = controller.Post(invalidMedicationModel);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }
    }
}
