namespace MyTestProject.Events;

public class Task3
{
    public class TemperatureSensor
    {
        private int? currentTemperature;
        public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;
        public void SetTemperature(int temperature)
        {
            if (currentTemperature == null)
            {
                TemperatureChangedEventArgs temperatureChangedEventArgs = new(temperature, temperature);
                currentTemperature = temperature;
                TemperatureChanged?.Invoke(this, temperatureChangedEventArgs);
            }
            else if (currentTemperature != temperature)
            {
                TemperatureChangedEventArgs temperatureChangedEventArgs = new(currentTemperature.Value, temperature);
                currentTemperature = temperature;
                TemperatureChanged?.Invoke(this, temperatureChangedEventArgs);
            }
        }
    }
    public class TemperatureChangedEventArgs(int oldTemperature, int newTemperature) : EventArgs
    {
        public int OldTemperature { get; } = oldTemperature;
        public int NewTemperature { get; } = newTemperature;
    }
    public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;

}