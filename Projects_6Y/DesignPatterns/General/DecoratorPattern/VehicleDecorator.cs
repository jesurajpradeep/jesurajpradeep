using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DecoratorPattern
{
    abstract class VehicleDecorator : IVehicle
    {
        public IVehicle _vehicle;

        public VehicleDecorator(IVehicle obj)
        {
            _vehicle = obj;
        }

        public string Make
        {
            get
            {
                return _vehicle.Make;
            }
        }

        public string Model
        {
            get
            {
                return _vehicle.Model;
            }
        }

        public double Price
        {
            get
            {
                return _vehicle.Price;
            }
        }
    }
}
