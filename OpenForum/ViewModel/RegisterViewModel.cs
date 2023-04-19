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
        async void Register()
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
                UsernameExist = await UserService.UsernameExist(Username);
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

            // create new User and add to database
            User user = new User(Username, Password, 0,0);
            await UserService.AddUser(user);

            // navigate back to log in
            await Shell.Current.GoToAsync("..");
        }
    }
}
