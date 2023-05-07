using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.Model
{
    public class User
    {
        public static List<User> All = new List<User>();
        public static int currentUserID;
        public static User currentUser;

        public User() { }


        public User(string n, string p, int admin, int exp) 
        {
            this.Name = n;
            this.Pass = p;
            this.IsAdmin = admin;
            this.Xp = exp;
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Pass { get; set; }
        public int IsAdmin { get; set; }
        public string Note { get; set; }
        public int Xp { get; set; }
        public string Status { get; set; }

    }
}
