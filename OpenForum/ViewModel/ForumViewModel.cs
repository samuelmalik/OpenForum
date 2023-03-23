using CommunityToolkit.Mvvm.ComponentModel;
using OpenForum.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    [QueryProperty("Pouzivatel", "CurrentUser")]
    public partial class ForumViewModel : ObservableObject
    {


        public ForumViewModel() 
        {
         
        }

        [ObservableProperty]
        User pouzivatel;
    }
}
