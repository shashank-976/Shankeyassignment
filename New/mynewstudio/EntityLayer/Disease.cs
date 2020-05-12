using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
   public class Disease
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public Severity DiseaseSeverity { get; set; }
        public Cause DiseaseCause { get; set; }
        public string DiseaseDescription { get; set; }
        public List<Symptom> DiseaseSymptom { get; set; }
    }
}
