using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using DataAccessLayer;
using ExceptionLayer;

namespace BusinessLayer
{
    public class Business
    {
        public void addDiseaseDetails(Disease disease)
        {
            Data data = new Data();
            data.addDiseaseDetails(disease);
        }
        public List<Severity> displaySeverity()
        {
            Data data = new Data();
            return data.displaySeverity();
        }

        public List<Cause> displayCause()
        {
            Data data = new Data();
            return data.displayCause();
        }
        public void addSymptomsDisease(DiseaseWithSymptom diseaseWithSymptom)
        {
            Data data = new Data();
            data.addSymptomsDisease(diseaseWithSymptom);
        }

        public List<Symptom> displaySymptom()
        {
            Data data = new Data();
            return data.displaySymptom();
        }

        public List<Disease> displayDisease()
        {
            Data data = new Data();
            return data.displayDisease();
        }
        public List<DiseaseWithSymptom> showdiagnoses(string patientName,int id1,int id2)
        {
            //List<DiseaseWithSymptom> diseaseWithSymptoms = new List<DiseaseWithSymptom>();
            Data data = new Data();
            //data.showdiagnoses(patientName,id1,id2);
            //return diseaseWithSymptoms;
            if (id1 == id2 && id1 > 0 && id2 > 0)
            {
                throw new sameSymptomException("please select two different id");
            }
            else if (id1 > 0 && id2 > 0)
            {
                return data.showdiagnoses(patientName, id1, id2);
            }
            else if (id1 > 0 && id2 == 0)
            {
                return data.diagnoses(patientName, id1);
            }
            else if (id1 == 0 && id2 > 0)
            {
                return data.diagnoses(patientName, id2);
            }

            throw new selectSymptomException("please select atleast one id");
        }

    }
}
