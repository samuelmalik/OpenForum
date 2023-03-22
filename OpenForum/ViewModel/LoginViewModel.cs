using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
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
        }

        [ObservableProperty]
        int count;


        // navigation command

        /*[RelayCommand]
        void Navigate()
        {
        }*/
    }
}
