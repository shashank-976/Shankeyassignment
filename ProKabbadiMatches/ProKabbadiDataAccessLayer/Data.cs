using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProKabbadiEntityLayer;
using ProKabbadiExceptionLayer;

namespace ProKabbadiDataAccessLayer
{
    public class Data
    {
        public bool addTeams(List<Matches> matcheslist)
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Database=Prokabbadi; integrated security= SSPI");
                int result = 0;
                con.Open();
                foreach (Matches i in matcheslist)
                {
                    SqlCommand sc = new SqlCommand("addMatches", con);
                    sc.CommandType = CommandType.StoredProcedure;
                    sc.Parameters.Add(new SqlParameter("@Match_Date", i.Match_Date));
                    sc.Parameters.Add(new SqlParameter("@First_Team_Id", i.First_Team_Id.Team_Id));
                    sc.Parameters.Add(new SqlParameter("@Second_Team_Id", i.Second_Team_Id.Team_Id));
                    sc.Parameters.Add(new SqlParameter("@First_Team_Score", i.First_Team_Score));
                    sc.Parameters.Add(new SqlParameter("@Second_Team_Score", i.Second_Team_Score));
                    result = result + sc.ExecuteNonQuery();
                }
                if (result > 0)
                {
                    return true;
                }

                con.Close();
                return false;
            }
            catch(Exception)
            {
                throw new InvalidDetails ("problem in data layer!!!");
            }

        }
        public List<Teams> DisplayTeams()
        {
            try
            {
                SqlConnection con = new SqlConnection(@"Data Source=.;Database=Prokabbadi; integrated security= SSPI");
                con.Open();
                List<Teams> teams = new List<Teams>();
                SqlCommand sc = new SqlCommand("TeamDetails", con);
                sc.CommandType = CommandType.StoredProcedure;

                SqlDataReader sdr = sc.ExecuteReader();
                while (sdr.Read())
                {
                    Teams teams1 = new Teams();
                    teams1.Team_Id = (int)sdr["Team_Id"];
                    teams1.Team_Name = (string)sdr["Team_Name"];
                    teams1.Team_City = (string)sdr["Team_City"];
                    teams.Add(teams1);

                }


                con.Close();
                return teams;
            }
            catch(Exception)
            {
                throw new InvalidDetails("problem in data layer!!!");
            }

        }

        public List<Matches> DisplayMatches()
        {
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Prokabbadi; integrated security= SSPI");
            con.Open();
            List<Matches> matches = new List<Matches>();
            SqlCommand sc = new SqlCommand("MatchesDetails", con);
            sc.CommandType = CommandType.StoredProcedure;
            SqlDataReader sdr = sc.ExecuteReader();
            while (sdr.Read())
            {
                Matches matches1 = new Matches();
                matches1.Match_Id = (int)sdr["Match_Id"];
                matches1.Match_Date = (string)sdr["Match_Date"];
                matches1.First_Team_Id = new Teams();
                matches1.First_Team_Id.Team_Id= (int)sdr["First_Team_Id"];
                matches1.Second_Team_Id = new Teams();
                matches1.Second_Team_Id.Team_Id = (int)sdr["Second_Team_Id"];
                matches1.First_Team_Score= (int)sdr["First_Team_Score"];
                matches1.Second_Team_Score = (int)sdr["Second_Team_Score"];
                matches.Add(matches1);



            }
            return matches;
        }

        public static void exportExcelData()
        {
            OleDbConnection connection;
            OleDbCommand cmd = new OleDbCommand();
            string querry = null;
            Data data = new Data();
            try
            {

                foreach (Matches matches in data.DisplayMatches())
                {
                    connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=D:\\PROKABADDI.xls;Extended Properties=Excel 12.0");
                    connection.Open();
                    cmd.Connection = connection;
                    //querry = "insert into [Sheet1$]([Match_Id],[Match_Date],[First_Team_Id],[Second_Team_Id],[First_Team_Score],[Second_Team_Score] values(" + matches.Match_Id + "," + matches.Match_Date + "," + matches.First_Team_Id.Team_Id + "," + matches.Second_Team_Id.Team_Id + "," + matches.First_Team_Score + "," + matches.Second_Team_Score + ")";
                    querry = "Insert into [Sheet1$] ([Match_Id],[Match_Date],[First_Team_Id],[Second_Team_Id],[First_Team_Score],[Second_Team_Score]) values('" + matches.Match_Id + "','" + matches.Match_Date + "','" + matches.First_Team_Id.Team_Id + "','" + matches.Second_Team_Id.Team_Id + "','" + matches.First_Team_Score + "','" + matches.Second_Team_Score + "')";
                    cmd.CommandText = querry;
                    cmd.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch(Exception e)
            {

            }
        }

        public List<Matches> FetchMatches(string Team_Name)
        {
            List<Matches> matches = new List<Matches>();
            SqlConnection con = new SqlConnection(@"Data Source=.;Database=Prokabbadi; integrated security= SSPI");
            con.Open();
            int Team_Id =0;

            using (SqlCommand sc = new SqlCommand("select  * from Teams where Team_Name='" + Team_Name + "'", con))
            {
                using (SqlDataReader sdr = sc.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Team_Id = (int)sdr["Team_Id"];
                    }
                }
            }

                    using (SqlCommand sc = new SqlCommand ("select * from Matches where First_Team_Id ='" + Team_Id + "'or Second_Team_Id='"+ Team_Id+"'", con))
            {
                using (SqlDataReader sdr = sc.ExecuteReader())
                {
                    while (sdr.Read())
                    {
                        Matches matches1 = new Matches();
                        matches1.First_Team_Id = new Teams();
                        matches1.First_Team_Id.Team_Id= (int)sdr["First_Team_Id"];
                        matches1.Second_Team_Id = new Teams();
                        matches1.Second_Team_Id.Team_Id= (int)sdr["Second_Team_Id"];
                        matches1.Match_Date = (string)sdr["Match_Date"];
                        matches1.First_Team_Score = (int)sdr["First_Team_Score"];
                        matches1.Second_Team_Score = (int)sdr["Second_Team_Score"];
                        matches.Add(matches1);
                    }
                }
                return matches;

            }
        }
    }
}
