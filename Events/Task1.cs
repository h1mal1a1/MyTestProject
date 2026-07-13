namespace MyTestProject.Events;

public class Task1
{
    public class TemperatureSensor
    {
        public event Action<int>? TemperatureChanged;
        public void SetTemperature(int temperature)
        {
            TemperatureChanged?.Invoke(temperature);
        }
    }
}