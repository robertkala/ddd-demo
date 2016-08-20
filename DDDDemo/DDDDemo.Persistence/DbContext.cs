using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Persistence
{
    public class DbContext
    {
        public List<DbUser> Users = new List<DbUser>
        {
            new DbUser(1, "Robert", "Kowalski", "pass1", "Katowice", "40-000", "Katowicka", "15A"),
            new DbUser(2, "Adam", "Nowak", "pass2", "Katowice", "40-123", "Chrzowska", "125A")
        };

    }

}
