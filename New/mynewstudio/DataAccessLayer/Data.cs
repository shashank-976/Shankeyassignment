using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer;
using ExceptionLayer;

namespace DataAccessLayer
{
    public class Data
    {
       
        public void addDiseaseDetails(Disease disease)
        {
            int rowsEffected = 0;
            try
            {


                SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
                con.Open();
                SqlCommand sc = new SqlCommand($"insert into Disease values('{disease.DiseaseName}','{disease.DiseaseSeverity.SeverityId}','{disease.DiseaseCause.CauseId}','{disease.DiseaseDescription}')", con);
                if (chDiseaseName(disease.DiseaseName) == 1)
                {
                    throw new MedicalException("The value Provided is incorrect/incomplete");
                }
                else
                {
                    rowsEffected= sc.ExecuteNonQuery();
                    con.Close();

                }
         
               
            }
            catch(SqlException)
            {
                throw new MedicalException("The value Provided is incorrect/incomplete");
            }
           

        }

        private int chDiseaseName(string diseaseName)
        {
            List<Disease> diseases = new List<Disease>();
            int r = 0;
            foreach(Disease disease in diseases)
            {
                if(diseaseName==disease.DiseaseName)
                {
                    r = 1;
                    break;
                }
                else
                {
                    r = -1;
                }

            }
            return r;
        }

        public List<Severity> displaySeverity()
        {
            try
            {
                List<Severity> severities = new List<Severity>();
                SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
                con.Open();
                SqlCommand sc = new SqlCommand("select * from Severity", con);
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    Severity severity = new Severity();
                    severity.SeverityId = (int)sdr["SeverityID"];
                    severity.SeverityName = (string)sdr["Severity"];
                    severities.Add(severity);

                }

                con.Close();
                return severities;
            }
            catch (Exception)
            {
                throw new MedicalException("The value Provided is incorrect/incomplete");
            }

        }

        public void addSymptomsDisease(DiseaseWithSymptom diseaseWithSymptom)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
            con.Open();
            SqlCommand sc = new SqlCommand($"insert into DiseasewithSymptom values('{diseaseWithSymptom.DsDisease.DiseaseId}','{diseaseWithSymptom.DsSymptom.SymptomId}','{diseaseWithSymptom.SymptomDescription}')", con);
            sc.ExecuteNonQuery();
            con.Close();
        }
        public List<Symptom> displaySymptom()
        {
            List<Symptom> symptoms = new List<Symptom>();
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
            con.Open();
            SqlCommand sc = new SqlCommand("select * from Symptom", con);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Symptom symptom = new Symptom();
                symptom.SymptomId = (int)sdr["SymptomID"];
                symptom.SymptomName= (string)sdr["Symptom"];
                symptoms.Add(symptom);

            }
            con.Close();
            return symptoms ;
        }
        public List<DiseaseWithSymptom> showdiagnoses(string patientName,int id1,int id2)
        {

            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
            //con.Open();
            List<DiseaseWithSymptom> diseaseWithSymptoms = new List<DiseaseWithSymptom>();
            SqlCommand sc = new SqlCommand("Diagnose1", con);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ID1", id1);
            sc.Parameters.AddWithValue("@ID2", id2);
            con.Open();
            SqlDataReader sdr = sc.ExecuteReader();
            while(sdr.Read())
            {
                DiseaseWithSymptom diseaseWithSymptom = new DiseaseWithSymptom();
                diseaseWithSymptom.DsDisease = new Disease();
                diseaseWithSymptom.DsDisease.DiseaseName = (string)sdr["DiseaseName"];
                diseaseWithSymptom.DsDisease.DiseaseSeverity.SeverityName = (string)sdr["Severity"];
                diseaseWithSymptom.DsSymptom = new Symptom();
                diseaseWithSymptom.DsSymptom.SymptomName= (string)sdr["Symptom"];
                diseaseWithSymptoms.Add(diseaseWithSymptom);
            }
            con.Close();
            return diseaseWithSymptoms;
        }

        public List<DiseaseWithSymptom> diagnoses(string patientName, int id1)
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
            //con.Open();
            List<DiseaseWithSymptom> diseaseWithSymptoms = new List<DiseaseWithSymptom>();
            SqlCommand sc = new SqlCommand("Diagnose2", con);
            sc.CommandType = CommandType.StoredProcedure;
            sc.Parameters.AddWithValue("@ID1", id1);
            con.Open();
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                DiseaseWithSymptom diseaseWithSymptom = new DiseaseWithSymptom();
                diseaseWithSymptom.DsDisease = new Disease();
                diseaseWithSymptom.DsDisease.DiseaseName = (string)sdr["DiseaseName"];
                diseaseWithSymptom.DsDisease.DiseaseSeverity.SeverityName = (string)sdr["Severity"];
                diseaseWithSymptom.DsSymptom = new Symptom();
                diseaseWithSymptom.DsSymptom.SymptomName = (string)sdr["Symptom"];
                diseaseWithSymptoms.Add(diseaseWithSymptom);
            }
            con.Close();
            return diseaseWithSymptoms;
        }

        public List<Disease> displayDisease()
        {
            List<Disease> diseases = new List<Disease>();
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
            con.Open();
            SqlCommand sc = new SqlCommand("select * from Disease", con);
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Disease disease = new Disease();
               disease.DiseaseId = (int)sdr["DiseaseID"];
               disease.DiseaseName = (string)sdr["DiseaseName"];
               diseases.Add(disease);
               




            }
            con.Close();
            return diseases;
        }

        public List<Cause> displayCause()
        {
            try
            {
                List<Cause> causes = new List<Cause>();
                SqlConnection con = new SqlConnection(@"Data Source=.;Database=Medical_Research; integrated security= SSPI");
                con.Open();
                SqlCommand sc = new SqlCommand("select * from Cause", con);
                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    Cause cause = new Cause();
                    cause.CauseId = (int)sdr["CauseID"];
                    cause.CauseName = (string)sdr["Cause"];
                    causes.Add(cause);

                }
                con.Close();
                return causes;
            }
            catch (Exception)
            {
                throw new MedicalException("The value Provided is incorrect/incomplete");
            }
            
        }
    }
}
