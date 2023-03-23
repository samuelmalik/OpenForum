using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.Model
{
    public class User
    {

        public User(string n, string p) 
        {
            this.Name = n;
            this.Pass = p;
        }
        public string Name { get; set; }
        public string Pass { get; set; }
    }
}
