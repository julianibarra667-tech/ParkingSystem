using System;
using System.Collections.Generic;
using System.Text;

namespace ParkingSystem.core.Entities
{
    public class Vehicle
    {

        public string LicensePlate { get; set; }
        public DateTime EntryTime { get; set; }
        public DateTime? ExitTime { get; set; }

        public bool IsParked => !ExitTime.HasValue;

        public Vehicle(string licensePlate, DateTime entryTime)
        {
            LicensePlate = licensePlate.ToUpper().Trim();
            EntryTime = entryTime;
            ExitTime = null;
        }

        public double CalculateStayHours(DateTime currentTime)
        {
            DateTime endTime = ExitTime ?? currentTime;
            TimeSpan duration = endTime - EntryTime;
            return Math.Max(1, Math.Ceiling(duration.TotalHours));
        }

        public decimal CalculateFee(decimal hourlyRate, DateTime currentTime)
        {
            double hours = CalculateStayHours(currentTime);
            return (decimal)hours * hourlyRate;
        }
    }
}
