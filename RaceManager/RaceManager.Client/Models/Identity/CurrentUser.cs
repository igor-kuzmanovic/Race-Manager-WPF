﻿using RaceManager.Client.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models.Identity
{
    class CurrentUser : User
    {
        private static CurrentUser _instance = null;

        private static readonly object _padlock = new object();

        private CurrentUser() { }

        public static CurrentUser Instance
        {
            get
            {
                lock (_padlock)
                    if (_instance == null)
                        _instance = new CurrentUser();
                return _instance;
            }
        }

        public static void LoadUser(User user)
        {
            Instance.Id = user.Id;
            Instance.Username = user.Username;
            Instance.Password = user.Password;
            Instance.FirstName = user.FirstName;
            Instance.LastName = user.LastName;
            Instance.SecurityToken = user.SecurityToken;
            Instance.IsAdmin = user.IsAdmin;
        }

        public static void UnloadUser()
        {
            Instance.Id = 0;
            Instance.Username = string.Empty;
            Instance.Password = string.Empty;
            Instance.FirstName = string.Empty;
            Instance.LastName = string.Empty;
            Instance.SecurityToken = string.Empty;
            Instance.IsAdmin = false;
        }
    }
}
