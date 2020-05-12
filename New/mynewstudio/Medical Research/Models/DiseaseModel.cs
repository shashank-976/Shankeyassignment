using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Research.Models
{
    public class DiseaseModel
    {
        public int DiseaseId { get; set; }
        public string DiseaseName { get; set; }
        public SeverityModel DiseaseSeverity { get; set; }
        public CauseModel DiseaseCause { get; set; }
        public string DiseaseDescription { get; set; }
        public List<SymptomModel> DiseaseSymptom { get; set; }
    }
}