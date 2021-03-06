﻿using RaceManager.Client.Core;
using RaceManager.Client.Models;
using RaceManager.Client.DataMappers;
using RaceManager.Client.Models.Identity;
using RaceManager.Client.UserService;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace RaceManager.Client.ViewModels
{
    class UserViewModel : ObservableObject
    {
        #region Fields

        private readonly UserServiceClient _userServiceClient;
        private ObservableCollection<User> _users;
        private User _selectedUser;
        private int _id;
        private string _username;
        private string _password;
        private string _firstName;
        private string _lastName;
        private string _securityToken;
        private bool _isAdmin;

        #endregion

        public UserViewModel()
        {
            _userServiceClient = new UserServiceClient();
            LoadUsers();
            RefreshCommand = new RelayCommand(OnRefresh);
            NewCommand = new RelayCommand(OnNew, CanNew);
            EditCommand = new RelayCommand(OnEdit, CanEdit);
            CopyCommand = new RelayCommand(OnCopy, CanCopy);
            DeleteCommand = new RelayCommand(OnDelete, CanDelete);
            SaveCommand = new RelayCommand(OnSave, CanSave);
            OnNew();
        }

        #region Commands

        public RelayCommand RefreshCommand { get; }
        public RelayCommand NewCommand { get; }
        public RelayCommand EditCommand { get; }
        public RelayCommand CopyCommand { get; }
        public RelayCommand DeleteCommand { get; }
        public RelayCommand SaveCommand { get; }

        #endregion

        #region Properties

        public ObservableCollection<User> Users
        {
            get => _users; set
            {
                _users = value;
                RaisePropertyChanged();
            }
        }

        public User SelectedUser
        {
            get => _selectedUser; set
            {
                _selectedUser = value;
                RaisePropertyChanged();
                EditCommand.RaiseCanExecuteChanged();
                CopyCommand.RaiseCanExecuteChanged();
                DeleteCommand.RaiseCanExecuteChanged();
            }
        }

        public int Id
        {
            get => _id; set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Username
        {
            get => _username; set
            {
                if (_username != value)
                {
                    _username = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get => _password; set
            {
                if (_password != value)
                {
                    _password = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string FirstName
        {
            get => _firstName; set
            {
                if (_firstName != value)
                {
                    _firstName = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get => _lastName; set
            {
                if (_lastName != value)
                {
                    _lastName = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string SecurityToken
        {
            get => _securityToken; set
            {
                if (_securityToken != value)
                {
                    _securityToken = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public bool IsAdmin
        {
            get => _isAdmin; set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    RaisePropertyChanged();
                    SaveCommand.RaiseCanExecuteChanged();
                }
            }
        }

        #endregion Properties

        #region Helper Methods

        private void LoadUsers()
        {
            if (CurrentUser.Instance.IsAdmin)
            {
                Users = new ObservableCollection<User>(UserMapper.Instance.Map(_userServiceClient.GetAll(CurrentUser.Instance.SecurityToken)));
            }
            else
            {
                Users = new ObservableCollection<User>(UserMapper.Instance.Map(_userServiceClient.GetAll(CurrentUser.Instance.SecurityToken)).Where(u => u.Id == CurrentUser.Instance.Id));
            }
        }

        #endregion

        #region Command Methods

        private void OnRefresh()
        {
            LoadUsers();
        }

        private void OnNew()
        {
            Id = 0;
            Username = string.Empty;
            Password = string.Empty;
            FirstName = string.Empty;
            LastName = string.Empty;
            SecurityToken = string.Empty;
            IsAdmin = false;
        }

        private bool CanNew()
        {
            return CurrentUser.Instance.IsAdmin;
        }

        private void OnEdit()
        {
            Id = SelectedUser.Id;
            Username = SelectedUser.Username;
            Password = SelectedUser.Password;
            FirstName = SelectedUser.FirstName;
            LastName = SelectedUser.LastName;
            SecurityToken = SelectedUser.SecurityToken;
            IsAdmin = SelectedUser.IsAdmin;
        }

        private bool CanEdit()
        {
            if (!CurrentUser.Instance.IsAdmin)
                return SelectedUser != null
                    && SelectedUser.Id == CurrentUser.Instance.Id;
            else
                return SelectedUser != null;
        }

        private void OnCopy()
        {
            Id = 0;
            Username = SelectedUser.Username;
            Password = SelectedUser.Password;
            FirstName = SelectedUser.FirstName;
            LastName = SelectedUser.LastName;
            SecurityToken = SelectedUser.SecurityToken;
            IsAdmin = SelectedUser.IsAdmin;
        }

        private bool CanCopy()
        {
            return CurrentUser.Instance.IsAdmin && SelectedUser != null;
        }

        private void OnDelete()
        {
            _userServiceClient.Remove(CurrentUser.Instance.SecurityToken, SelectedUser.Id);
            LoadUsers();
            OnNew();
        }

        private bool CanDelete()
        {
            return CurrentUser.Instance.IsAdmin && SelectedUser != null && SelectedUser.Id != CurrentUser.Instance.Id;
        }

        private void OnSave()
        {
            var user = new User();
            user.Id = Id > 0 ? Id : 0;
            user.Username = Username;
            user.Password = Password;
            user.FirstName = FirstName;
            user.LastName = LastName;
            user.SecurityToken = SecurityToken;
            user.IsAdmin = IsAdmin;

            if (Id > 0)
                _userServiceClient.Update(CurrentUser.Instance.SecurityToken, UserMapper.Instance.Map(user));
            else
                _userServiceClient.Add(CurrentUser.Instance.SecurityToken, UserMapper.Instance.Map(user));

            LoadUsers();
            OnNew();
        }

        private bool CanSave()
        {
            if (!CurrentUser.Instance.IsAdmin)
                return Id == CurrentUser.Instance.Id
                    && Username == CurrentUser.Instance.Username
                    && Password == CurrentUser.Instance.Password
                    && !string.IsNullOrWhiteSpace(FirstName)
                    && !string.IsNullOrWhiteSpace(LastName)
                    && IsAdmin == false;
            else
                return !string.IsNullOrWhiteSpace(Username)
                    && !Users.Any(u => u.Username.ToLower() == Username.ToLower())
                    && !string.IsNullOrWhiteSpace(Password)
                    && !string.IsNullOrWhiteSpace(FirstName)
                    && !string.IsNullOrWhiteSpace(LastName);
        }

        #endregion
    }
}