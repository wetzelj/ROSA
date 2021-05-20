using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;
using FHIRService.Application.Helpers;
using FHIRService.Application.Models;

namespace FHIRService.Application.Services.FHIR
{
    public class FHIRDataService
    {
        private FhirClient client;
        public FHIRDataService()
        {
            var messagehandler = new HttpClientEventHandler();
            messagehandler.OnBeforeRequest += (object sender, BeforeHttpRequestEventArgs e) =>
            {
                e.RawRequest.Headers
                    .Add("apikey", Application.Helpers.Constants.FHIR_API_KEY);
            };

            client = new FhirClient(new Uri(Application.Helpers.Constants.FHIR_API_BASE_URL), null, messagehandler)
            {
                PreferredFormat = ResourceFormat.Json,

            };
        }
 

        /// <summary>
        /// Returns a patient record for the specified ID.
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public Patient GetPatientByID(string ID)
        {
    
            var patient = client.SearchById<Patient>(ID);
            var pat = patient.Entry
                .Select(p => p.Resource as Patient)
                .SingleOrDefault();

            //return Mapper.Map<SIIMPatient>(pat);
            return pat;
        }
        public ImagingStudy GetImagingStudiesByID(string studyId)
        {
            //

            var incl = new string[] { "Subject" };
            var imagingstudy = client.SearchById<ImagingStudy>(studyId, incl, null);

            
            var study = imagingstudy.Entry
               .Select(s => s.Resource as ImagingStudy)
               .SingleOrDefault();


            //return Mapper.Map<ImgStudy>(study);
            return study;
        }
        public List<ImagingStudy> GetImagingStudiesByPatientID(string patientID)
        {
            //

            var incl = new string[] { "Subject" };
            var studies = client.Search<ImagingStudy>(
                new string[] { String.Format("patient={0}", patientID) });

            var StudyList = studies.Entry.Select(s => s.Resource as ImagingStudy)
                .ToList();

            //return Mapper.Map<ImgStudy>(firstStudy);
           return StudyList;
        }

    }
}
