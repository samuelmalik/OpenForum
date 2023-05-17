using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{


    public partial class UserDetailsViewModel : BaseViewModel
    {
        public UserDetailsViewModel() 
        {
            Id = User.currentViewedUser.Id;
            Name = User.currentViewedUser.Name;
            Xp = User.currentViewedUser.Xp.ToString();
            Status = User.currentViewedUser.Status;
            Note = User.currentViewedUser.Note;

            loadAchievements();
        }

        [ObservableProperty]
        string id;
        [ObservableProperty]
        string name;
        [ObservableProperty]
        string note;
        [ObservableProperty]
        string xp;
        [ObservableProperty]
        string status;




        [ObservableProperty]
        string addXp;
        [ObservableProperty]
        string setXp;

        [RelayCommand]
            async Task OnAddXp()
            {
                if (AddXp != "") {

                int newXp = Convert.ToInt32(AddXp) + Convert.ToInt32(Xp);
                Xp = newXp.ToString();
                User.currentViewedUser.Xp = newXp;
                User.currentUser.Xp = newXp;

                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        User.All[i].Xp = Convert.ToInt32(Xp);
                        break;
                    }
                }

                AddXp = "";
                await UserService.UpdateXp(Id, Convert.ToInt32(Xp));
                }
            
            }

        [RelayCommand]
        async Task OnSetXp()
        {
            if (SetXp != "") {
            Xp = Convert.ToInt32(SetXp).ToString();
            User.currentViewedUser.Xp = Convert.ToInt32(Xp);
            User.currentUser.Xp = Convert.ToInt32(Xp);


                if (User.All[0].Id == Id)
                {
                    User.All[0].Xp = Convert.ToInt32(Xp);
                }


                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        User.All[i].Xp = Convert.ToInt32(Xp);
                        break;
                    }
                }

                SetXp = "";
            await UserService.UpdateXp(Id, Convert.ToInt32(Xp));
            }
        }


        [RelayCommand]
        async Task OnSave()
        {
            IsBusy = true;
            await UserService.UpdateAdminNote(Id, Note);
            User.currentUser.Note = Note;

            for (int i = 0; i < User.All.Count; i++)
            {
                if (User.All[i].Id == Id)
                {
                    User.All[i].Note = Note;
                    break;
                }
            }
            IsBusy = false;
        }


        [RelayCommand]
        void NavigateToUsersPage()
        {
            Shell.Current.GoToAsync($"../{nameof(UsersPage)}", false);
        }


        // Achievements
        [NotifyPropertyChangedFor(nameof(nSlack))]
        [ObservableProperty]
        bool slack;

        public bool nSlack => !Slack;

        [NotifyPropertyChangedFor(nameof(nDiscord))]
        [ObservableProperty]
        bool discord;

        public bool nDiscord => !Discord;

        [NotifyPropertyChangedFor(nameof(nAktivita))]
        [ObservableProperty]
        bool aktivita;

        public bool nAktivita => !Aktivita;

        [NotifyPropertyChangedFor(nameof(nRychlost))]
        [ObservableProperty]
        bool rychlost;

        public bool nRychlost => !Rychlost;

        [NotifyPropertyChangedFor(nameof(nPomocnik))]
        [ObservableProperty]
        bool pomocnik;

        public bool nPomocnik => !Pomocnik;

        [NotifyPropertyChangedFor(nameof(nNacas))]
        [ObservableProperty]
        bool nacas;

        public bool nNacas => !Nacas;

        [NotifyPropertyChangedFor(nameof(nDobryNapad))]
        [ObservableProperty]
        bool dobryNapad;

        public bool nDobryNapad => !DobryNapad;

        [NotifyPropertyChangedFor(nameof(nChristmassCoder))]
        [ObservableProperty]
        bool christmassCoder;

        public bool nChristmassCoder => !ChristmassCoder;

        [NotifyPropertyChangedFor(nameof(nPresenter))]
        [ObservableProperty]
        bool presenter;

        public bool nPresenter => !Presenter;

        [NotifyPropertyChangedFor(nameof(nQuizzMaster))]
        [ObservableProperty]
        bool quizzMaster;

        public bool nQuizzMaster => !QuizzMaster;

        [NotifyPropertyChangedFor(nameof(nGitHub))]
        [ObservableProperty]
        bool gitHub;

        public bool nGitHub => !GitHub;

        [NotifyPropertyChangedFor(nameof(nCvicenia10))]
        [ObservableProperty]
        bool cvicenia10;

        public bool nCvicenia10 => !Cvicenia10;

        [NotifyPropertyChangedFor(nameof(nCvicenia20))]
        [ObservableProperty]
        bool cvicenia20;

        public bool nCvicenia20 => !Cvicenia20;

        [NotifyPropertyChangedFor(nameof(nCvicenia30))]
        [ObservableProperty]
        bool cvicenia30;

        public bool nCvicenia30 => !Cvicenia30;

        [NotifyPropertyChangedFor(nameof(nCvicenia40))]
        [ObservableProperty]
        bool cvicenia40;

        public bool nCvicenia40 => !Cvicenia40;

        [NotifyPropertyChangedFor(nameof(nCvicenia50))]
        [ObservableProperty]
        bool cvicenia50;

        public bool nCvicenia50 => !Cvicenia50;

        [NotifyPropertyChangedFor(nameof(nGildedRose))]
        [ObservableProperty]
        bool gildedRose;

        public bool nGildedRose => !GildedRose;

        [NotifyPropertyChangedFor(nameof(nOOPBasics))]
        [ObservableProperty]
        bool oopBasics;

        public bool nOOPBasics => !OopBasics;

        [NotifyPropertyChangedFor(nameof(nHousingEstate))]
        [ObservableProperty]
        bool housingEstate;

        public bool nHousingEstate => !HousingEstate;

        [NotifyPropertyChangedFor(nameof(nCodingGame))]
        [ObservableProperty]
        bool codingGame;

        public bool nCodingGame => !CodingGame;

        [NotifyPropertyChangedFor(nameof(nCGHorseRacing))]
        [ObservableProperty]
        bool cgHorseRacing;

        public bool nCGHorseRacing => !CgHorseRacing;

        [NotifyPropertyChangedFor(nameof(nCGTemperatures))]
        [ObservableProperty]
        bool cgTemperatures;

        public bool nCGTemperatures => !CgTemperatures;

        [NotifyPropertyChangedFor(nameof(nCGCircuitResistance))]
        [ObservableProperty]
        bool cgCircuitResistance;

        public bool nCGCircuitResistance => !CgCircuitResistance;

        [NotifyPropertyChangedFor(nameof(nHelloXamarin))]
        [ObservableProperty]
        bool helloXamarin;

        public bool nHelloXamarin => !HelloXamarin;

        [NotifyPropertyChangedFor(nameof(nBeatsPerMinute))]
        [ObservableProperty]
        bool beatsPerMinute;

        public bool nBeatsPerMinute => !BeatsPerMinute;

        [NotifyPropertyChangedFor(nameof(nMvvm))]
        [ObservableProperty]
        bool mvvm;

        public bool nMvvm => !Mvvm;

        [NotifyPropertyChangedFor(nameof(nStopwatch))]
        [ObservableProperty]
        bool stopwatch;

        public bool nStopwatch => !Stopwatch;

        [NotifyPropertyChangedFor(nameof(nPuzzle))]
        [ObservableProperty]
        bool puzzle;

        public bool nPuzzle => !Puzzle;


        void loadAchievements()
        {
            Slack = User.currentViewedUser.Slack;
            Discord = User.currentViewedUser.Discord;
            Aktivita = User.currentViewedUser.Aktivita;
            Rychlost = User.currentViewedUser.Rychlost;
            Pomocnik = User.currentViewedUser.Pomocnik;
            Nacas = User.currentViewedUser.Nacas;
            DobryNapad = User.currentViewedUser.DobryNapad;
            ChristmassCoder = User.currentViewedUser.ChristmassCoder;
            Presenter = User.currentViewedUser.Presenter;
            QuizzMaster = User.currentViewedUser.QuizzMaster;
            GitHub = User.currentViewedUser.GitHub;
            Cvicenia10 = User.currentViewedUser.Cvicenia10;
            Cvicenia20 = User.currentViewedUser.Cvicenia20;
            Cvicenia30 = User.currentViewedUser.Cvicenia30;
            Cvicenia40 = User.currentViewedUser.Cvicenia40;
            Cvicenia50 = User.currentViewedUser.Cvicenia50;
            GildedRose = User.currentViewedUser.GildedRose;
            OopBasics = User.currentViewedUser.OOPBasics;
            HousingEstate = User.currentViewedUser.HousingEstate;
            CodingGame = User.currentViewedUser.CodingGame;
            CgHorseRacing = User.currentViewedUser.CGHorseRacing;
            CgTemperatures = User.currentViewedUser.CGTemperatures;
            CgCircuitResistance = User.currentViewedUser.CGCircuitResistance;
            HelloXamarin = User.currentViewedUser.HelloXamarin;
            BeatsPerMinute = User.currentViewedUser.BeatsPerMinute;
            Mvvm = User.currentViewedUser.Mvvm;
            Stopwatch = User.currentViewedUser.Stopwatch;
            Puzzle = User.currentViewedUser.Puzzle;
        }


    }


    
}
