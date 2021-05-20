using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHIRService.Application.Models
{
    public class ImgStudy
    {
        public string accession { get; set; } //Accession.Value
        public string description { get; set; }
        public string interpreter { get; set; } //Interpreter -- Maybe?  Didn't see any samples, but could be Practitioner.
        public DateTime proceduredate { get; set; } //started

    }
}
