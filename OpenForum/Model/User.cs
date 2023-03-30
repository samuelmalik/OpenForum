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

       public static void AddUser(string name, string pass)
        {
            All.Add(new User(name, pass));
        }

        public User(string n, string p) 
        {
            this.Name = n;
            this.Pass = p;
        }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}
