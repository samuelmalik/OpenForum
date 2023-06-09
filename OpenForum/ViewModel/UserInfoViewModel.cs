﻿using CommunityToolkit.Mvvm.Input;
using OpenForum.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OpenForum.ViewModel
{
    public partial class UserInfoViewModel : BaseViewModel
    {
        public UserInfoViewModel() 
        {
            id = User.currentUser.Id;
            username = User.currentUser.Name;
            xp = User.currentUser.Xp;
            status = User.currentUser.Status;
        }

        [ObservableProperty]
        string id;

        [ObservableProperty]
        string username;

        [ObservableProperty]
        int xp;

        [ObservableProperty]
        string status;


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

        [RelayCommand]
        void NavigateToLogin()
        {
            Shell.Current.GoToAsync($"../..");
        }

        [RelayCommand]
        async Task OnSave()
        {
            IsBusy = true;
            await UserService.UpdateStatus(Id, Status);
            User.currentUser.Status = Status;
            int index;

            for (int i = 0; i < User.All.Count; i++)
            {
                if (User.All[i].Id == Id)
                {
                    index = i;
                    User.All[index].Status = Status;
                    break;
                }
            }
            IsBusy = false;
        }
    }
}
