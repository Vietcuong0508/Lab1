namespace Lap6
{
    public class Cooler
    {
        public float Temperature
        {
            get { return _Temperature; }
            set { _Temperature = value; }
        }

        private float _Temperature;

        public Cooler(float temperature)
        {
            Temperature = temperature;
        }

        public void OnTemperatureChanged(float newTemperature)
        {
            if (newTemperature > Temperature)
            {
                System.Console.WriteLine("Cooler: On");
            }
            else
            {
                System.Console.WriteLine("Cooler: Off");
            }
        }
    }
}