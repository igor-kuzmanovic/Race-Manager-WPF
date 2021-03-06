﻿using RaceManager.Client.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class Driver : ObservableObject
    {
        private int _id;
        private string _firstName;
        private string _lastName;
        private string _umcn;

        public Driver() { }

        public int Id
        {
            get => _id; set
            {
                if (_id != value)
                {
                    _id = value;
                    RaisePropertyChanged();
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
                }
            }
        }

        public string UMCN
        {
            get => _umcn; set
            {
                if (_umcn != value)
                {
                    _umcn = value;
                    RaisePropertyChanged();
                }
            }
        }

        public override string ToString()
        {
            return $"{FirstName} {LastName}";
        }
    }
}
