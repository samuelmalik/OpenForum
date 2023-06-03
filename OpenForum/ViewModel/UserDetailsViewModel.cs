using CommunityToolkit.Mvvm.Input;
using Microsoft.Maui.Layouts;
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

        [RelayCommand]
        async Task AddAchievements(string achievement)


        {
            int index = 0;


            if (achievement == "1,") 
            { 
                Slack = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Slack = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            } else if (achievement == "2,")
            {
                Discord = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Discord = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "3,")
            {
                Aktivita = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Aktivita = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "4,")
            {
                Rychlost = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Rychlost = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "5,")
            {
                Pomocnik = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Pomocnik = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "6,")
            {
                Nacas = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Nacas = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "7,")
            {
                DobryNapad = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].DobryNapad = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "8,")
            {
                ChristmassCoder = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].ChristmassCoder = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "9,")
            {
                Presenter = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Presenter = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "10,")
            {
                QuizzMaster = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].QuizzMaster = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "11,")
            {
                GitHub = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].GitHub = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "12,")
            {
                Cvicenia10 = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia10 = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "13,")
            {
                Cvicenia20 = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia20 = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "14,")
            {
                Cvicenia30 = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia30 = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "15,")
            {
                Cvicenia40 = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia40 = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "16,")
            {
                Cvicenia50 = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia50 = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "17,")
            {
                GildedRose = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].GildedRose = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "18,")
            {
                OopBasics = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].OOPBasics = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "19,")
            {
                HousingEstate = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].HousingEstate = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "20,")
            {
                CodingGame = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CodingGame = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "21,")
            {
                CgHorseRacing = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGHorseRacing = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "22,")
            {
                CgTemperatures = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGTemperatures = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "23,")
            {
                CgCircuitResistance = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGCircuitResistance = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "24,")
            {
                HelloXamarin = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].HelloXamarin = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "25,")
            {
                BeatsPerMinute = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].BeatsPerMinute = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "26,")
            {
                Mvvm = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Mvvm = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "27,")
            {
                Stopwatch = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Stopwatch = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            else if (achievement == "28,")
            {
                Puzzle = true;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Puzzle = true;
                        User.All[i].Achievements += achievement;
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, User.All[index].Achievements);
            }
            
        }


        [RelayCommand]
        async Task RemoveAchievements(string achievement)
        {
            int index = 0;
            string newAchievements ="";

            if (achievement == "1,")
            {
                Slack = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Slack = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "2,")
            {
                Discord = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Discord = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "3,")
            {
                Aktivita = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Aktivita = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "4,")
            {
                Rychlost = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Rychlost = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "5,")
            {
                Pomocnik = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Pomocnik = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "6,")
            {
                Nacas = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Nacas = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "7,")
            {
                DobryNapad = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].DobryNapad = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "8,")
            {
                ChristmassCoder = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].ChristmassCoder = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "9,")
            {
                Presenter = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Presenter = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "10,")
            {
                QuizzMaster = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].QuizzMaster = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "11,")
            {
                GitHub = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].GitHub = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "12,")
            {
                Cvicenia10 = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia10 = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "13,")
            {
                Cvicenia20 = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia20 = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "14,")
            {
                Cvicenia30 = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia30   = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "15,")
            {
                Cvicenia40 = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia40 = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "16,")
            {
                Cvicenia50 = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Cvicenia50 = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "17,")
            {
                GildedRose = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].GildedRose = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "18,")
            {
                OopBasics = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].OOPBasics = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "19,")
            {
                HousingEstate = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].HousingEstate = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "20,")
            {
                CodingGame = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CodingGame = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "21,")
            {
                CgHorseRacing = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGHorseRacing = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "22,")
            {
                CgTemperatures = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGTemperatures = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "23,")
            {
                CgCircuitResistance = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].CGCircuitResistance = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "24,")
            {
                HelloXamarin = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].HelloXamarin = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "25,")
            {
                BeatsPerMinute = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].BeatsPerMinute = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "26,")
            {
                Mvvm = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Mvvm = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "27,")
            {
                Stopwatch = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Stopwatch = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
            else if (achievement == "28,")
            {
                Puzzle = false;
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Id == Id)
                    {
                        index = i;
                        User.All[i].Puzzle = false;

                        newAchievements = User.All[i].Achievements.Remove(User.All[i].Achievements.IndexOf("," + achievement), achievement.Length);
                        break;
                    }
                }
                await UserService.UpdateAchievements(Id, newAchievements);
            }
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
