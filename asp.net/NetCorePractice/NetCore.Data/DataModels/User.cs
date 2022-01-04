using System;
using System.Collections.Generic;
using System.Text;

namespace NetCore.Data.DataModels
{
    public class User
    {
        public string UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPW { get; set; }

        public DateTime JoinedUTCDate { get; set; }
    }
}
