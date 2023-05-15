using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
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
            int index;

            for (int i = 0; i < User.All.Count; i++)
            {
                if (User.All[i].Id == Id)
                {
                    index = i;
                    User.All[index].Note = Note;
                    break;
                }
            }
            IsBusy = false;
        }

       
  
    }


    
}
