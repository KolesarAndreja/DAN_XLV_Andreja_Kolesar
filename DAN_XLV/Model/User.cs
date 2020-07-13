using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAN_XLV.Model
{
    public class User
    {
        #region PROPERTY
        public string username { get; set; }
        public string password { get; set; }
        public string role
        {
            get
            {
                if (username == "Mag2019" && password == "Mag2019")
                {
                    return "storekeeper";
                }
                else if (password == "Man2019" && username == "Man2019")
                {
                    return "manager";
                }
                else return null;
            }
        }
        #endregion
    }
}
