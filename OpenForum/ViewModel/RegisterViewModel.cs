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
        string username = "";

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
            PasswordsDontMatch = false;
            PasswordIsShort = false;
            UsernameExist = false;
            // check if username isn't null
            if (Username == "")
            {
                UsernameExist = true;
                return;
            } else
            {
                UsernameExist = false;
                // check if username exist
                foreach (var user in User.All)
                {

                    if (user.Name == Username)
                    {
                        UsernameExist = true;
                        return;

                    }
                }
            }



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

            // create new User and append to User.All
            User.AddUser(Username, Password);

            // navigate back to log in
            Shell.Current.GoToAsync("..");
        }
    }
}
