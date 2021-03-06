﻿using RaceManager.Client.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RaceManager.Client.Models
{
    class Vehicle : ObservableObject
    {
        private int _id;
        private string _manufacturer;
        private string _model;
        private string _type;
        private double _engineHorsepower;
        private double _engineDisplacement;
        private Driver _driver;

        public Vehicle() { }

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

        public string Manufacturer
        {
            get => _manufacturer; set
            {
                if (_manufacturer != value)
                {
                    _manufacturer = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Model
        {
            get => _model; set
            {
                if (_model != value)
                {
                    _model = value;
                    RaisePropertyChanged();
                }
            }
        }

        public string Type
        {
            get => _type; set
            {
                if (_type != value)
                {
                    _type = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double EngineHorsepower
        {
            get => _engineHorsepower; set
            {
                if (_engineHorsepower != value)
                {
                    _engineHorsepower = value;
                    RaisePropertyChanged();
                }
            }
        }

        public double EngineDisplacement
        {
            get => _engineDisplacement; set
            {
                if (_engineDisplacement != value)
                {
                    _engineDisplacement = value;
                    RaisePropertyChanged();
                }
            }
        }

        public Driver Driver
        {
            get => _driver; set
            {
                if (_driver != value)
                {
                    _driver = value;
                    RaisePropertyChanged();
                }
            }
        }
    }
}
