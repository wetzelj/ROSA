using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FHIRService.Application.Models
{
    public class ImgPatient
    {
            public string id { get; set; }
            public string name { get; set; }
            public DateTime birthdate { get; set; }
            public string gender { get; set; }
      
    }
}
