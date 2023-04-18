
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
    public partial class LoginViewModel : ObservableObject
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

        [ObservableProperty]
        string test = UserService.GetPassword();




        [RelayCommand]
        void OnLogin()
        {
            
            
                for (int i = 0; i < User.All.Count; i++)
                {
                    if (User.All[i].Name == Username && User.All[i].Pass == Password)
                    {
                        ShowErrorMessage = false;
                        User.currentUserID = i;
                        // navigate to ForumPage
                        Username = "";
                        Password = "";
                        Shell.Current.GoToAsync($"{nameof(ForumPage)}");
                        return;
                    }
                }
                ShowErrorMessage = true;

            




        }



        [RelayCommand]
        void OnRegister()
        {
            ShowErrorMessage = false;
            Shell.Current.GoToAsync($"{nameof(RegisterPage)}");
        }
        

    }
}
