
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenForum.Model;
using OpenForum.Service;
using OpenForum.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    public partial class LoginViewModel : BaseViewModel
    {
       
        public LoginViewModel() 
        {
            ShowErrorMessage = false;
        }

        [ObservableProperty]
        bool showErrorMessage;

        [ObservableProperty]
        string username = "";

        [ObservableProperty]
        string password = "";



        [RelayCommand]
        async Task OnLogin()
        {
            IsBusy = true;

            try
            {
                IsBusy = true;
                var userPassword = await UserService.GetPassword(Username);

                if (userPassword == Password)
                {
                    ShowErrorMessage = false;
                    //User.currentUserID = i;
                    // navigate to ForumPage
                    Username = "";
                    Password = "";
                    await Shell.Current.GoToAsync($"{nameof(ForumPage)}");
                    return;
                }

                ShowErrorMessage = true;
            }
            finally
            {
                IsBusy = false;
            }

            








        }



        [RelayCommand]
        void OnRegister()
        {
            ShowErrorMessage = false;
            Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
        

    }
}
