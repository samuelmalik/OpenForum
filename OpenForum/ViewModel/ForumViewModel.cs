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
    public partial class ForumViewModel : ObservableObject
    {


        public ForumViewModel() 
        {
        }

        [ObservableProperty]
        int test = User.currentUserID;

        [RelayCommand]
        void NavigateToMaterials()
        {
            Shell.Current.GoToAsync($"{nameof(MaterialsPage)}", false);
        }

    }
}
