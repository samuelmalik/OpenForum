
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenForum.Model;
using OpenForum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    public partial class LoginViewModel : ObservableObject
    {
       
        public LoginViewModel() 
        {
            ShowErrorMessage = false;
        }

        [ObservableProperty]
        bool showErrorMessage;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password;

        [RelayCommand]
        void OnLogin()
        {
            if (Username == null || Password == null)
            {
                ShowErrorMessage = true; return;    
            }
            ShowErrorMessage = false;



            // create currentUser and pass to ForumPage
            User usr = new User(Username, Password);
            Shell.Current.GoToAsync($"{nameof(ForumPage)}", new Dictionary<string, object>
            {
                {"CurrentUser", usr }
            });

        }
        

    }
}
