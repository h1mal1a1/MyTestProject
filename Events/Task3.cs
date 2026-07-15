namespace MyTestProject.Events;

public class Task3
{
    public class TemperatureSensor
    {
        private int? currentTemperature;
        public event EventHandler<TemperatureChangedEventArgs>? TemperatureChanged;
        public void SetTemperature(int temperature)
        {
            TemperatureChangedEventArgs temperatureChangedEventArgs;
            if (currentTemperature == null)
                temperatureChangedEventArgs = new(null, temperature);
            else if (currentTemperature != temperature)
                temperatureChangedEventArgs = new(currentTemperature, temperature);
            else
                return;
            currentTemperature = temperature;
            TemperatureChanged?.Invoke(this, temperatureChangedEventArgs);
        }
    }
    public class TemperatureChangedEventArgs(int? oldTemperature, int newTemperature) : EventArgs
    {
        public int? OldTemperature { get; } = oldTemperature;
        public int NewTemperature { get; } = newTemperature;
    }
}