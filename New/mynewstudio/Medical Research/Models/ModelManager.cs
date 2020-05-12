using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EntityLayer;
using BusinessLayer;


namespace Medical_Research.Models
{
    public class ModelManager
    {
        public void addDiseaseDetails(DiseaseModel diseaseModel)

        {
            Disease disease = new Disease();
            disease.DiseaseName = diseaseModel.DiseaseName;
            disease.DiseaseSeverity = new Severity();
            disease.DiseaseSeverity.SeverityId = diseaseModel.DiseaseSeverity.SeverityId;
            disease.DiseaseCause = new Cause();
            disease.DiseaseCause.CauseId = diseaseModel.DiseaseCause.CauseId;
            disease.DiseaseDescription = diseaseModel.DiseaseDescription;
            Business business = new Business();
            business.addDiseaseDetails(disease);
        }

        public List<Severity> displaySeverity()
        {
            List<Severity> severities = new List<Severity>();
            Business business = new Business();
            severities = business.displaySeverity();
            return severities;


        }

        public List<Cause> displayCause()
        {
            List<Cause> causes = new List<Cause>();
            Business business = new Business();
            causes = business.displayCause();
            return causes;


        }

        public List<SymptomModel> DisplaySymptom()
        {
            List<Symptom> symptoms = new List<Symptom>();
            
            Business business = new Business();
            symptoms = business.displaySymptom();
            List<SymptomModel> symptomModels = new List<SymptomModel>();
            foreach (var symptom in symptoms)
            {
                SymptomModel symptomModel = new SymptomModel();
                symptomModel.SymptomId = symptom.SymptomId;
                symptomModel.SymptomName = symptom.SymptomName;
                symptomModels.Add(symptomModel);
            }
            return symptomModels;
        }

        public List<DiseaseModel> displayDisease()
        {
            List<Disease> diseases = new List<Disease>();
            Business business = new Business();
            diseases = business.displayDisease();
            List<DiseaseModel> diseaseModels = new List<DiseaseModel>();
            foreach (var disease in diseases)
            {
                DiseaseModel diseaseModel = new DiseaseModel();
                diseaseModel.DiseaseId = disease.DiseaseId;
                diseaseModel.DiseaseName = disease.DiseaseName;
                diseaseModels.Add(diseaseModel);

            }
            
            return diseaseModels;


        }


        public void addSymptomsDisease(DiseaseWithSymptomModel diseaseWithSymptomModel)
        {
            DiseaseWithSymptom diseaseWithSymptom = new DiseaseWithSymptom();
            diseaseWithSymptom.DsDisease = new Disease();
            diseaseWithSymptom.DsDisease.DiseaseId = diseaseWithSymptomModel.DsDisease.DiseaseId;
            diseaseWithSymptom.DsSymptom = new Symptom();
            diseaseWithSymptom.DsSymptom.SymptomId = diseaseWithSymptomModel.DsSymptom.SymptomId;
           diseaseWithSymptom.SymptomDescription = diseaseWithSymptomModel.SymptomDescription;
            Business business = new Business();
            business.addSymptomsDisease(diseaseWithSymptom);
        }

        public List<DiseaseWithSymptomModel> showdiagnoses(string patientName,int id1, int id2)
        {
            List<DiseaseWithSymptom> diseaseWithSymptoms = new List<DiseaseWithSymptom>();
            Business business = new Business();
            diseaseWithSymptoms = business.showdiagnoses(patientName,id1,id2);
            List<DiseaseWithSymptomModel> models = new List<DiseaseWithSymptomModel>();
            foreach (var diseaseWithSymp in diseaseWithSymptoms)
            {
                DiseaseWithSymptomModel symptomModel = new DiseaseWithSymptomModel();
                symptomModel.DsDisease = new DiseaseModel();
                symptomModel.DsDisease.DiseaseName = diseaseWithSymp.DsDisease.DiseaseName;
                symptomModel.DsDisease.DiseaseSeverity = new SeverityModel();
                symptomModel.DsDisease.DiseaseSeverity.SeverityName = diseaseWithSymp.DsDisease.DiseaseSeverity.SeverityName;
                symptomModel.DsSymptom = new SymptomModel();
                symptomModel.DsSymptom.SymptomName = diseaseWithSymp.DsSymptom.SymptomName;
                models.Add(symptomModel);


            }
            return models;
        }
    }
}