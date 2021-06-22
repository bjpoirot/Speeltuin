using System;

namespace Huiswerk1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Huiswerkopdracht 1");

            var petrolCar = new PetrolCar();
            petrolCar.Start();

            var dieselCar = new DieselCar();
            dieselCar.Start();
            
            var electricCar = new ElectricCar();
            electricCar.Start();

            var garage = new Garage();
            var carglass = new Carglass();
            garage.ExtraService += carglass.RepairWindow(petrolCar);
            garage.Service(petrolCar);

        }
    }
}
