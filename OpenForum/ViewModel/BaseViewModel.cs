using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace OpenForum.ViewModel
{
    public partial class BaseViewModel : ObservableObject
    {
        public BaseViewModel() 
        {
            
        }

        [NotifyPropertyChangedFor(nameof(IsNotBusy))]
        [ObservableProperty]
        bool isBusy = false;

        public bool IsNotBusy => !IsBusy;
    }
}
