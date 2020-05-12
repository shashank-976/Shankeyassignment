using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer
{
     public class DiseaseWithSymptom
    {
        public int DSID { get; set; }
        public Disease DsDisease { get; set; }
        public Symptom DsSymptom { get; set; }
        public string SymptomDescription { get; set; }
    }
}