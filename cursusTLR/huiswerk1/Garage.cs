using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Huiswerk1
{
    public class Garage
    {
        public delegate void ExtraService

        public void Service(Car car)
        {
            Console.WriteLine("Check Oil");

            ExtraService?.Invoke(car);

            Console.WriteLine("Wassen");
        }

        public Action<Car> ExtraService;
    }
}
