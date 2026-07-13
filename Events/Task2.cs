namespace MyTestProject.Events;

public class Task2
{
    public class TemperatureSensor
    {
        private int? currentTemperature;
        public event Action<int>? TemperatureChanged;
        public void SetTemperature(int temperature)
        {
            if (currentTemperature != temperature)
            {
                currentTemperature = temperature;
                TemperatureChanged?.Invoke(temperature);
            }
        }
    }
}