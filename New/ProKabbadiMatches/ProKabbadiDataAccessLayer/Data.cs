using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProKabbadiEntityLayer;

namespace ProKabbadiDataAccessLayer
{
    public class Data
    {
        public bool addTeams(List<Matches> matcheslist)
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
        public List<Teams> DisplayTeams()
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
    }
}
