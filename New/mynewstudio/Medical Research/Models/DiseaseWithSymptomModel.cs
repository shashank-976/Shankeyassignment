using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Medical_Research.Models
{
    public class DiseaseWithSymptomModel
    {
        public int DSID { get; set; }
        public DiseaseModel DsDisease { get; set; }
        public SymptomModel DsSymptom { get; set; }
        public string SymptomDescription { get; set; }
    }
}