using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using OpenForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    public partial class ForumViewModel : BaseViewModel
    {


        public ForumViewModel() 
        {
        }

        [RelayCommand]
        void NavigateToMaterials()
        {
            Shell.Current.GoToAsync($"{nameof(MaterialsPage)}", false);
        }

        [RelayCommand]
        void NavigateToQuiz()
        {
            Shell.Current.GoToAsync($"{nameof(QuizPage)}", false);
        }

        [RelayCommand]
        void NavigateToUsers()
        {
            Shell.Current.GoToAsync($"{nameof(UsersPage)}", false);
        }

        [RelayCommand]
        void NavigateToUserInfo()
        {
            Shell.Current.GoToAsync($"{nameof(UserInfoPage)}", false);
        }

    }
}
