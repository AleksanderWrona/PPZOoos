using System;

namespace cos
{
    class Program
    {
        static void Main(string[] args)
        {
            Car car1 = new Car();
            car1.Detalis();

            Console.WriteLine();

            car1.Brand = "Fiat";
            car1.Model = "126p";
            car1.DoorCount = 2;
            car1.EngineVolume = 0.7;
            car1.AvgConsump = 6.0;
            car1.RegistrationNumber = "PUNU9327";
            car1.Detalis();

            double routeConsumption1 = car1.CalculateConsump(500);
            Console.WriteLine($"car1: Route consumption: {routeConsumption1}L");

            double routeCost1 = car1.CalculateCost(500, 5);
            Console.WriteLine($"car1: RouteCost: {routeCost1}$");

            Console.WriteLine();

            Car car2 = new Car("Syrena", "105", "WE1234", 2, 0.8f, 7.6d);
            car2.Detalis();

            double routeConsumption2 = car2.CalculateConsump(500);
            Console.WriteLine($"car2: Route consumption: {routeConsumption2}L");

            double routeCost2 = car2.CalculateCost(500, 5);
            Console.WriteLine($"car2: RouteCost: {routeCost2}$");

            Console.WriteLine();
            Console.WriteLine();

            ElectricCar electricCar = new ElectricCar("Tesla", "Model S", "TESLA123", 4, 0, 0, 100, 8);
            electricCar.Detalis();

            double routeConsumption = electricCar.CalculateConsump(500);
            Console.WriteLine($"electricCar: Route consumption: {routeConsumption}L");

            double routeCost = electricCar.CalculateCost(500, 5);
            Console.WriteLine($"electricCar: RouteCost: {routeCost}$");

            Console.WriteLine();

            Car.DisplayCarCount();
        }
    }

    class Car
    {
        private static int _carCount = 0;

        public string _brand;
        public string _model;
        public string _registrationNumber;
        public int _doorCount;
        public double _engineVolume;
        public double _avgConsump;

        public string Brand
        {
            get { return _brand; }
            set { _brand = value; }
        }

        public string Model
        {
            get { return _model; }
            set { _model = value; }
        }

        public string RegistrationNumber
        {
            get { return _registrationNumber; }
            set { _registrationNumber = value; }
        }

        public int DoorCount
        {
            get { return _doorCount; }
            set { _doorCount = value; }
        }

        public double EngineVolume
        {
            get { return _engineVolume; }
            set { _engineVolume = value; }
        }

        public double AvgConsump
        {
            get { return _avgConsump; }
            set { _avgConsump = value; }
        }

        public Car()
        {
            _brand = "unknown";
            _model = "unknown";
            _registrationNumber = "unknown";
            _doorCount = 0;
            _engineVolume = 0;
            _avgConsump = 0.0;
            _carCount++;
        }

        public Car(string brand, string model, string registrationNumber, int doorCount, double engineVolume, double avgConsump)
        {
            _brand = brand;
            _model = model;
            _registrationNumber = registrationNumber;
            _doorCount = doorCount;
            _engineVolume = engineVolume;
            _avgConsump = avgConsump;
            _carCount++;
        }

        public override string ToString()
        {
            return $"Car | Brand: {_brand}, Model: {_model}, NumOfDoors: {_doorCount}, EngineVol: {_engineVolume}, " +
                     $"AvgConsump: {_avgConsump}, RegistrationNumber: {_registrationNumber}";
        }

        public void Detalis()
        {
            Console.WriteLine(this.ToString());
        }

        public double CalculateConsump(double roadLength)
        {
            return (_avgConsump * roadLength) / 100.0;
        }

        public double CalculateCost(double roadLength, double petrolCost)
        {
            return CalculateConsump(roadLength) * petrolCost;
        }

        public static void DisplayCarCount()
        {
            Console.WriteLine($"Car count: {_carCount}");
        }
    }

    class ElectricCar : Car
    {
        private int _batteryCapacity;
        private int _chargingTime;

        public int BatteryCapacity
        {
            get { return _batteryCapacity; }
            set { _batteryCapacity = value; }
        }

        public int ChargingTime
        {
            get { return _chargingTime; }
            set { _chargingTime = value; }
        }

        public ElectricCar()
        {
            _batteryCapacity = 0;
            _chargingTime = 0;
        }

        public ElectricCar(string brand, string model, string registrationNumber, int doorCount, double engineVolume, double avgConsump, int batteryCapacity, int chargingTime)
            : base(brand, model, registrationNumber, doorCount, engineVolume, avgConsump)
        {
            _batteryCapacity = batteryCapacity;
            _chargingTime = chargingTime;
        }

        public override string ToString()
        {
            return $"ElectricCar | Brand: {_brand}, Model: {_model}, NumOfDoors: {_doorCount}, EngineVol: {_engineVolume}, " +
                     $"AvgConsump: {_avgConsump}, RegistrationNumber: {_registrationNumber}, BatteryCapacity: {_batteryCapacity}, ChargingTime: {_chargingTime}";
        }
    }
}