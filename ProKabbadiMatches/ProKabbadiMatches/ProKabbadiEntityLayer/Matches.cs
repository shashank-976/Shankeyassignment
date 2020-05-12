using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKabbadiEntityLayer
{
  public  class Matches
    {
        public int Match_Id { get; set; }
        public string Match_Date { get; set; }
        public Teams First_Team_Id { get; set; }
        public Teams Second_Team_Id { get; set; }
        public int First_Team_Score { get; set; }
        public int Second_Team_Score { get; set; }


    }
}
