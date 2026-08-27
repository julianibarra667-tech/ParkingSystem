 using ParkingSystem.core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.core.Services
{
    public class ParkingService
    {

        private readonly List<Vehicle> _vehicles;
        public int Capacity { get; private set; }
        public decimal HourlyRate { get; private set; }

        public ParkingService(int capacity, decimal hourlyRate)
        {
            if (capacity <= 0)
                throw new ArgumentException("capacidad no puede ser menos a cero.");

            if (hourlyRate < 0)
                throw new ArgumentException("La hora de salida no puede ser menor a la entrada.");

            Capacity = capacity;
            HourlyRate = hourlyRate;
            _vehicles = new List<Vehicle>();
        }

        public bool HasAvailableSpace()
        {
            int currentParked = _vehicles.Count(v => v.IsParked);
            return currentParked < Capacity;
        }

        public void RegisterEntry(string licensePlate, DateTime entryTime)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("El numero de matricula es necesario.");

            if (!HasAvailableSpace())
                throw new InvalidOperationException("Parqueadero lleno.");

            string formattedPlate = licensePlate.ToUpper().Trim();

            if (_vehicles.Any(v => v.LicensePlate == formattedPlate && v.IsParked))
                throw new InvalidOperationException("Este vehiculo se encuentra estacionado");

            _vehicles.Add(new Vehicle(formattedPlate, entryTime));
        }

        public decimal RegisterExit(string licensePlate, DateTime exitTime)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("El numero de matricula es necesario.");

            string formattedPlate = licensePlate.ToUpper().Trim();
            var vehicle = _vehicles.FirstOrDefault(v => v.LicensePlate == formattedPlate && v.IsParked);

            if (vehicle == null)
                throw new KeyNotFoundException("vehiculo no se encuentra actualmente estacionado.");

            if (exitTime < vehicle.EntryTime)
                throw new InvalidOperationException("La hora de salida no puede ser menor a la entrada.");

            vehicle.ExitTime = exitTime;
            return vehicle.CalculateFee(HourlyRate, exitTime);
        }

        public List<Vehicle> GetCurrentlyParkedVehicles()
        {
            return _vehicles.Where(v => v.IsParked).ToList();
        }

        public bool IsVehicleParked(string licensePlate)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                return false;

            string formattedPlate = licensePlate.ToUpper().Trim();
            return _vehicles.Any(v => v.LicensePlate == formattedPlate && v.IsParked);
        }

    }
}
