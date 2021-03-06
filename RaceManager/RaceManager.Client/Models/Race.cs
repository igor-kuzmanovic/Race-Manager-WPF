﻿using RaceManager.Client.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class Race : ObservableObject
    {
        private int _id;
        private DateTime _eventDate;
        private string _eventLocation;
        private ObservableCollection<Driver> _drivers;

        public Race()
        {
            Drivers = new ObservableCollection<Driver>();
        }

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

        public DateTime EventDate
        {
            get => _eventDate; set
            {
                if (_eventDate != value)
                {
                    _eventDate = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string EventLocation
        {
            get => _eventLocation; set
            {
                if (_eventLocation != value)
                {
                    _eventLocation = value;
                    RaisePropertyChanged();
                }
            }
        }

        public ObservableCollection<Driver> Drivers
        {
            get => _drivers; set
            {
                _drivers = value;
                RaisePropertyChanged();
            }
        }
    }
}
