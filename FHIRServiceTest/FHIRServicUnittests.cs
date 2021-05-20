using Microsoft.VisualStudio.TestTools.UnitTesting;
using FHIRService.Application.Helpers;
using FHIRService.Application.Services.FHIR;
using System.Linq;

using System;
namespace FHIRService.Tests
{
    [TestClass]
    public class FHIRServicUnitTests
    {
        private FHIRService.Application.Services.FHIR.FHIRDataService  FHIR;

        public FHIRServicUnitTests()
        {
            FHIR = new FHIRService.Application.Services.FHIR.FHIRDataService();
            //AutoMapperConfig.Initialize();
        }
        [TestMethod]
        public void Test01_GetPatientByID()
        {
            var id = "siimravi";
            var patient = FHIR.GetPatientByID(id);

            Assert.IsNotNull(patient);
            Assert.AreEqual(id, patient.Id);
            Assert.AreEqual("1941-03-31", patient.BirthDate.ToString());
            Assert.AreEqual("Ravi SIIM", patient.Name[0].ToString());
            Assert.AreEqual("Ravi", patient.Name[0].Given.FirstOrDefault());
            Assert.AreEqual("Male", patient.Gender.ToString());
        }
        [TestMethod]
        public void Test02_GetStudyByID()
        {
            var id = "a819497684894126";
            var study = FHIR.GetImagingStudiesByID(id);

            Assert.IsNotNull(study);
            Assert.AreEqual(id, study.Id);
            Assert.AreEqual("a819497684894126", study.Id);
            Assert.AreEqual("CT Chest", study.Description.ToString());
        }
        [TestMethod]
        public void Test03_GetImagingStudiesByPatientID()

        {
            var id = "siimravi";
            var studies = FHIR.GetImagingStudiesByPatientID(id);
            foreach (var study in studies)
            {

                Assert.IsNotNull(study);
            }
        }

    }
}
