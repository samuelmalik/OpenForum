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
            Shell.Current.GoToAsync($"../../{nameof(UsersPage)}", false);
        }


    }


    
}
