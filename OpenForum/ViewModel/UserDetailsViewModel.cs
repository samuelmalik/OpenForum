using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    [QueryProperty("User", "User")]

    public partial class UserDetailsViewModel : BaseViewModel
    {
        public UserDetailsViewModel() { }

        [ObservableProperty]
        User user;

    }


    
}
