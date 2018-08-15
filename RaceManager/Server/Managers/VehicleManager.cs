﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace Server
{
    class VehicleManager
    {
        public static VehicleManager Instance { get; } = new VehicleManager();

        static VehicleManager() { }

        private VehicleManager() { }

        public Vehicle GetVehicleById(int id)
        {
            using (var context = new Context())
            {
                return context.Vehicles.FirstOrDefault(v => v.Id == id);
            }
        }

        public IEnumerable<Vehicle> GetAllVehicles()
        {
            using (var context = new Context())
            {
                return context.Vehicles.ToList();
            }
        }

        public int InsertVehicle(Vehicle vehicle)
        {
            using (var context = new Context())
            {
                context.Vehicles.Add(vehicle);
                context.SaveChanges();
                return vehicle.Id;
            }
        }

        public bool UpdateVehicle(Vehicle vehicle)
        {
            using (var context = new Context())
            {
                var oldVehicle = GetVehicleById(vehicle.Id);

                if (oldVehicle == null)
                    return false;

                oldVehicle.Manufacturer = vehicle.Manufacturer;
                oldVehicle.Model = vehicle.Model;
                oldVehicle.Type = vehicle.Type;
                oldVehicle.EngineHorsepower = vehicle.EngineHorsepower;
                oldVehicle.EngineDisplacement = vehicle.EngineDisplacement;
                oldVehicle.DriverId = vehicle.DriverId;
                oldVehicle.Driver = vehicle.Driver;
                context.SaveChanges();
                return true;
            }
        }

        public bool DeleteVehicle(int id)
        {
            using (var context = new Context())
            {
                var vehicle = GetVehicleById(id);

                if (vehicle == null)
                    return false;

                context.Vehicles.Remove(vehicle);
                context.SaveChanges();
                return true;
            }
        }
    }
}