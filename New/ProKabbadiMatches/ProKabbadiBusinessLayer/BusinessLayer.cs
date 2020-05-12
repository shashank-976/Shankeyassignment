using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProKabbadiEntityLayer;
using ProKabbadiDataAccessLayer;

namespace ProKabbadiBusinessLayer
{
 
    public class BusinessLayer
    {
        Data data = new Data();
        public bool addTeams(List<Matches> matcheslist)
        {
            return data.addTeams(matcheslist);
        }
        public List<Teams> DisplayTeams()
        {
            Data data = new Data();
            return (data.DisplayTeams());
        }
    }
   
}
