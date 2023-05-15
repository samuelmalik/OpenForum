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
        public static User currentViewedUser;

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
        
        
        // achievements
        public bool Slack { get; set; }
        public bool Discord { get; set; }
        public bool Aktivita { get; set; }
        public bool Rychlost { get; set; }
        public bool Pomocnik { get; set; }
        public bool Nacas { get; set; }
        public bool DobryNapad { get; set; }
        public bool ChristmassCoder { get; set; }
        public bool Presenter { get; set; }
        public bool QuizzMaster { get; set; }
        public bool GitHub { get; set; }
        public bool Cvicenia10 { get; set; }
        public bool Cvicenia20 { get; set; }
        public bool Cvicenia30 { get; set; }
        public bool Cvicenia40 { get; set; }
        public bool Cvicenia50 { get; set; }
        public bool GildedRose { get; set; }
        public bool OOPBasics { get; set; }
        public bool HousingEstate { get; set; }
        public bool CodingGame { get; set; }
        public bool CGHorseRacing { get; set; }
        public bool CGTemperatures { get; set; }
        public bool CGCircuitResistance { get; set; }
        public bool HelloXamarin { get; set; }
        public bool BeatsPerMinute { get; set; }
        public bool Mvvm { get; set; }
        public bool Stopwatch { get; set; }
        public bool Puzzle { get; set; }

    }
}
