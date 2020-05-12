using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProKabbadiEntityLayer
{
  public  class Matches: IComparer<Matches>
    {
        public int Match_Id { get; set; }
        public string Match_Date { get; set; }
        public Teams First_Team_Id { get; set; }
        public Teams Second_Team_Id { get; set; }
        public int First_Team_Score { get; set; }
        public int Second_Team_Score { get; set; }

        public int Compare(Matches x, Matches y)
        {
            if (x.First_Team_Score - x.Second_Team_Score < y.First_Team_Score - y.Second_Team_Score)
                return -1;
            /* else if (x.First_Team_Score - x.Second_Team_Score == y.First_Team_Score - y.Second_Team_Score)
             {
                 int status = CompareTo(x);
                 if (status == 1)
                     return 1;
                 else if (status == 0)
                     return 0;
                 else
                     return -1;
             }
             else
                 return -1;
                 */
            else if(x.First_Team_Score - x.Second_Team_Score < y.First_Team_Score - y.Second_Team_Score)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

       /* public int CompareTo(Matches other)
        {
            //string date1 = Match_Date.ToString();
            //string date2 =other.Match_Date.ToString();
          //  Matches matches = new Matches();
            return Match_Date.CompareTo(other.Match_Date);
            //return date2.CompareTo(date1);
        }
        */
    }
}
