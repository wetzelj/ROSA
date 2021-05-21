using System;
using System.Collections.Generic;
using System.Linq;
using Hl7.Fhir.Model;
using Hl7.Fhir.Rest;

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
            Patient pat = new Patient();
            if (ID != null)
            {
                var patient = client.SearchById<Patient>(ID);
                pat = patient.Entry
               .Select(p => p.Resource as Patient)
               .SingleOrDefault();
            }
            return pat;
        }
        public ImagingStudy GetImagingStudiesByID(string studyId)
        {
            ImagingStudy study = new ImagingStudy();
            if (studyId != null)
            {
          
                var incl = new string[] { "Subject" };
                var imagingstudy = client.SearchById<ImagingStudy>(studyId, incl, null);
            
                study = imagingstudy.Entry
                   .Select(s => s.Resource as ImagingStudy)
                   .SingleOrDefault();
            }
            
            return study;
        }
        public List<ImagingStudy> GetImagingStudiesByPatientID(string patientID)
        {
            //
            List<ImagingStudy> StudyList = new List<ImagingStudy>();
            if (patientID != null)
            {
                var incl = new string[] { "Subject" };
                var studies = client.Search<ImagingStudy>(
                new string[] { String.Format("patient={0}", patientID) });

                StudyList = studies.Entry.Select(s => s.Resource as ImagingStudy)
                    .ToList();
            }

            return StudyList;
        }

    }
}
