using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    [QueryProperty("User", "User")]

    public partial class UserDetailsViewModel : BaseViewModel
    {
        public UserDetailsViewModel() 
        {
        }

        [ObservableProperty]
        User user;






        [RelayCommand]
        async Task OnSave()
        {
            IsBusy = true;
            await UserService.UpdateAdminNote(User.Id, User.Note);
            User.currentUser.Note = User.Note;
            int index;

            for (int i = 0; i < User.All.Count; i++)
            {
                if (User.All[i].Id == User.Id)
                {
                    index = i;
                    User.All[index].Note = User.Note;
                    break;
                }
            }
            IsBusy = false;
        }

    }


    
}
