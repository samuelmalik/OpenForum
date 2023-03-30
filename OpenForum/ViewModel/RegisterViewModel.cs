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
    public partial class RegisterViewModel : ObservableObject
    {
        [ObservableProperty]
        string username;

        [ObservableProperty]
        string password = "";

        [ObservableProperty]
        string password2;

        [ObservableProperty]
        bool usernameExist = false;

        [ObservableProperty]
        bool passwordsDontMatch = false;

        [ObservableProperty]
        bool passwordIsShort = false;


        [RelayCommand]
        void Register()
        {
            // check if password is long enough
            if (Password.Length < 6)
            {
                PasswordIsShort = true;
                return;
            }
            PasswordIsShort = false;

            // check if passwords match
            if (Password != Password2)
            {
                PasswordsDontMatch = true;
                return;
            }
            PasswordsDontMatch = false;

            // check if username exist
            foreach (var user in User.All)
            {
                if (user.Name == Username)
                {
                    UsernameExist = true;
                    return;
                }
            }
            UsernameExist = false;

            // check if username isn't null
            if (Username is null)
            {
                UsernameExist = true;
                return;
            }
            UsernameExist = false;

            Shell.Current.GoToAsync("..");
        }
    }
}
