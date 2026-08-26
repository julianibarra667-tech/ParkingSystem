public class ParkingService
    {
        private readonly List<Vehicle> _vehicles;
        public int Capacity { get; private set; }
        public decimal HourlyRate { get; private set; }

        public ParkingService(int capacity, decimal hourlyRate)
        {
            if (capacity <= 0)
                throw new ArgumentException("La capacidad debe ser mayor que cero.");

            if (hourlyRate < 0)
                throw new ArgumentException("La tarifa por hora no puede ser negativa.");

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
                throw new ArgumentException("Se requiere el número de matrícula.");

            if (!HasAvailableSpace())
                throw new InvalidOperationException("El estacionamiento está lleno..");

            string formattedPlate = licensePlate.ToUpper().Trim();

            if (_vehicles.Any(v => v.LicensePlate == formattedPlate && v.IsParked))
                throw new InvalidOperationException("Ya hay un vehículo con esta matrícula estacionado.");

            _vehicles.Add(new Vehicle(formattedPlate, entryTime));
        }

        public decimal RegisterExit(string licensePlate, DateTime exitTime)
        {
            if (string.IsNullOrWhiteSpace(licensePlate))
                throw new ArgumentException("Se requiere el número de matrícula.");

            string formattedPlate = licensePlate.ToUpper().Trim();
            var vehicle = _vehicles.FirstOrDefault(v => v.LicensePlate == formattedPlate && v.IsParked);

            if (vehicle == null)
                throw new KeyNotFoundException("El vehículo no está estacionado en este momento.");

            if (exitTime < vehicle.EntryTime)
                throw new InvalidOperationException("La hora de salida no puede ser anterior a la hora de entrada.");

            vehicle.ExitTime = exitTime;
            return vehicle.CalculateFee(HourlyRate, exitTime);
        }

        public List<Vehicle> GetCurrentlyParkedVehicles()
        {
            return _vehicles.Where(v => v.IsParked).ToList();
        }
    }
