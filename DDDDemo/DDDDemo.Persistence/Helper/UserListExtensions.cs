using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDDDemo.Persistence.Helper
{
    public static class UserListExtensions
    {
        public static int GetNewId(this List<DbUser> list)
        {
            var lastUser = list?.LastOrDefault();
            if (lastUser != null)
            {
                return lastUser.Id + 1;
            }
            return 1;
        }
    }
}
