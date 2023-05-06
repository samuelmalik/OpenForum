using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    public partial class UserInfoViewModel : BaseViewModel
    {
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
        void NavigateToUsers()
        {
            Shell.Current.GoToAsync($"../{nameof(UsersPage)}", false);
        }
    }
}
