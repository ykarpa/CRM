// <copyright file="ProfileViewModel.cs" company="PlaceholderCompany">
// Copyright (c) PlaceholderCompany. All rights reserved.
// </copyright>

namespace Presentation.ViewModels
{
    using System.Threading.Tasks;
    using BLL.Services;
    using DAL.Models;
    using Presentation.Core;

    public class ProfileViewModel : ViewModel
    {
        private readonly UserService userService;
        private int _userId;
        private User? _user;

        public ProfileViewModel(UserService userService)
        {
            this.userService = userService;
        }

        public int UserId
        {
            get => this._userId;
            set
            {
                this._userId = value;
                Task.Run(this.LoadUserDataAsync);
            }
        }

        public User? User
        {
            get => this._user;
            private set
            {
                this._user = value;
                this.OnPropertyChange(nameof(this.User));
            }
        }

        private async Task LoadUserDataAsync()
        {
            this.User = await this.userService.GetById(this._userId);
        }
    }
}
