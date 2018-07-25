using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Factory.Cars;

namespace Factory.First
{
    public class CarFactory
    {
        private Dictionary<string, Type> _cars;

        public CarFactory()
        {
            LoadTypes();
        }

        private void LoadTypes()
        {
            var typesInAssembly = Assembly.GetExecutingAssembly().GetTypes().Where(t => t.GetInterface(typeof(ICar).ToString()) != null);
            _cars = new Dictionary<string, Type>();
            foreach (var type in typesInAssembly)
            {
                _cars.Add(type.Name.ToLower(), type);
            }
        }

        private Type GetTypeToCreate(string name)
        {
            _cars.TryGetValue(name, out var result);
            return result;
        }

        public ICar CreateInstance(string name)  
        {
            var type = GetTypeToCreate(name);
            if (type == null)
            {
                return NullCar.Instance;
            }

            return Activator.CreateInstance(type) as ICar;
        }
    }
}