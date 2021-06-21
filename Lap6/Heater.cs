using System;

namespace Lap6.Properties
{
    public class Heater
    {
        private float _Temperature;

        public float Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        public Heater(float temperature)
        {
            Temperature = temperature;
        }


        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature < Temperature)
            {
                Console.WriteLine("Heater: On");
            }
            else
            {
                Console.WriteLine("Heater: Off");
            }
        }
    }
}