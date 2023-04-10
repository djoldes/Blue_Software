using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Volo.Abp.Users;

namespace Blue_Software
{
        public static class AppData
        {
            public static User CurrentUser { get; set; }
            public static void UpdateCurrentUser(User currentUser)
                {
                    User.UpdateCredit(currentUser.Credit, currentUser.CreditGained);
                    CurrentUser.Credit = User.GetCreditsForUser(currentUser.Username);
                }
        }
}
