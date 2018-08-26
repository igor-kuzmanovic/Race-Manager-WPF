﻿using RaceManager.Client.Core.Converters;
using RaceManager.Client.VehicleService;

namespace RaceManager.Client.Models.Converters
{
    class VehicleConverter : Converter<Vehicle, VehicleDTO>, IVehicleConverter
    {
        public static VehicleConverter Instance { get; } = new VehicleConverter();

        static VehicleConverter() { }

        private VehicleConverter() { }

        public override Vehicle Convert(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle();

            vehicle.Id = vehicleDTO.Id;
            vehicle.Manufacturer = vehicleDTO.Manufacturer;
            vehicle.Model = vehicleDTO.Model;
            vehicle.Type = vehicleDTO.Type;
            vehicle.EngineHorsepower = vehicleDTO.EngineHorsepower;
            vehicle.EngineDisplacement = vehicleDTO.EngineDisplacement;

            return vehicle;
        }

        public override VehicleDTO Convert(Vehicle vehicle)
        {
            var vehicleDTO = new VehicleDTO();

            vehicleDTO.Id = vehicle.Id;
            vehicleDTO.Manufacturer = vehicle.Manufacturer;
            vehicleDTO.Model = vehicle.Model;
            vehicleDTO.Type = vehicle.Type;
            vehicleDTO.EngineHorsepower = vehicle.EngineHorsepower;
            vehicleDTO.EngineDisplacement = vehicle.EngineDisplacement;

            return vehicleDTO;
        }
    }
}