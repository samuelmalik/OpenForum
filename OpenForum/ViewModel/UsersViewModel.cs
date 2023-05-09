using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace OpenForum.ViewModel
{
    public partial class UsersViewModel : BaseViewModel
    {
        public UsersViewModel()
        {
            foreach (var user in User.All)
            {
                Users.Add(user);
            }
            
            if (User.currentUser.IsAdmin == 1) 
            {
                isCurrentUserAdmin = true;
            } else { isCurrentUserAdmin = false; }
        }

        public ObservableCollection<User> Users { get; set; } = new();


        [ObservableProperty]
        bool isCurrentUserAdmin;

        [RelayCommand]
        void NavigateToForum()
        {
            Shell.Current.GoToAsync("..", false);
        }

        [RelayCommand]
        void NavigateToQuiz()
        {
            Shell.Current.GoToAsync($"../{nameof(QuizPage)}", false);
        }

        [RelayCommand]
        void NavigateToMaterials()
        {
            Shell.Current.GoToAsync($"../{nameof(MaterialsPage)}", false);
        }

        [RelayCommand]
        void NavigateToUserInfo()
        {
            Shell.Current.GoToAsync($"../{nameof(UserInfoPage)}", false);
        }
    }
}
