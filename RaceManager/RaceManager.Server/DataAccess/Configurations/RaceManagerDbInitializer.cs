﻿using RaceManager.Server.DataAccess.Core.DataAccessObjects;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Web;

namespace RaceManager.Server.DataAccess.Persistence.Configurations
{
    class RaceManagerDbInitializer : DropCreateDatabaseAlways<RaceManagerDbContext>
    {
        public RaceManagerDbInitializer() { }

        protected override void Seed(RaceManagerDbContext context)
        {
            var races = new List<RaceDAO>()
            {
                new RaceDAO()
                {
                    EventDate = new DateTime(2018, 8, 8),
                    EventLocation = "Race Location 1",
                },
                new RaceDAO()
                {
                    EventDate = new DateTime(2017, 7, 7),
                    EventLocation = "Race Location 2",
                },
                new RaceDAO()
                {
                    EventDate = new DateTime(2016, 6, 6),
                    EventLocation = "Race Location 3",
                }
            };

            foreach (var race in races)
                context.Races.AddOrUpdate(race);

            var drivers = new List<DriverDAO>()
            {
                new DriverDAO()
                {
                    FirstName = "John 1",
                    LastName = "Doe 1",
                    UMCN = "1111111111111"
                },
                new DriverDAO()
                {
                    FirstName = "John 2",
                    LastName = "Doe 2",
                    UMCN = "2222222222222"
                },
                new DriverDAO()
                {
                    FirstName = "John 3",
                    LastName = "Doe 3",
                    UMCN = "3333333333333"
                }
            };

            foreach (var driver in drivers)
                context.Drivers.AddOrUpdate(driver);

            var vehicles = new List<VehicleDAO>()
            {
                new VehicleDAO()
                {
                    Manufacturer = "Manufacturer 1",
                    Model = "Model 1",
                    Type = "Type 1",
                    EngineHorsepower = 111,
                    EngineDisplacement = 1,
                    DriverId = 1
                },
                new VehicleDAO()
                {
                    Manufacturer = "Manufacturer 2",
                    Model = "Model 2",
                    Type = "Type 2",
                    EngineHorsepower = 222,
                    EngineDisplacement = 2,
                    DriverId = 2
                },
                new VehicleDAO()
                {
                    Manufacturer = "Manufacturer 3",
                    Model = "Model 3",
                    Type = "Type 3",
                    EngineHorsepower = 333,
                    EngineDisplacement = 3,
                    DriverId = 3
                },
            };

            foreach (var vehicle in vehicles)
                context.Vehicles.AddOrUpdate(vehicle);

            var users = new List<UserDAO>()
            {
                new UserDAO()
                {
                    Username = "admin",
                    Password = "admin",
                    FirstName = "John",
                    LastName = "Doe",
                    SecurityToken = string.Empty,
                    IsAdmin = true
                },
                new UserDAO()
                {
                    Username = "user",
                    Password = "user",
                    FirstName = "Mary",
                    LastName = "Doe",
                    SecurityToken = string.Empty,
                    IsAdmin = false
                }
            };

            foreach (var user in users)
                context.Users.AddOrUpdate(user);

            var raceDrivers = new List<RaceDriverDAO>()
            {
                new RaceDriverDAO()
                {
                    RaceId = 1,
                    DriverId = 1
                },
                new RaceDriverDAO()
                {
                    RaceId = 1,
                    DriverId = 2
                },
                new RaceDriverDAO()
                {
                    RaceId = 2,
                    DriverId = 2
                },
                new RaceDriverDAO()
                {
                    RaceId = 2,
                    DriverId = 3
                },
                new RaceDriverDAO()
                {
                    RaceId = 3,
                    DriverId = 3
                },
                new RaceDriverDAO()
                {
                    RaceId = 3,
                    DriverId = 1
                }
            };

            foreach (var raceDriver in raceDrivers)
                context.RaceDrivers.AddOrUpdate(raceDriver);

            context.SaveChanges();
        }
    }
}