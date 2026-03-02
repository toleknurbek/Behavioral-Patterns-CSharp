public interface ICommand {
    void Execute();
    void Undo();
}

public class Light {
    public void On() => Console.WriteLine("Light is On");
    public void Off() => Console.WriteLine("Light is Off");
}

public class Thermostat {
    public int Temperature { get; set; } = 20;
    public void SetTemperature(int temp) {
        Temperature = temp;
        Console.WriteLine($"Temperature: {Temperature}°C");
    }
}

public class LightOnCommand : ICommand {
    private Light _light;
    public LightOnCommand(Light light) => _light = light;
    public void Execute() => _light.On();
    public void Undo() => _light.Off();
}

public class LightOffCommand : ICommand {
    private Light _light;
    public LightOffCommand(Light light) => _light = light;
    public void Execute() => _light.Off();
    public void Undo() => _light.On();
}

public class TempChangeCommand : ICommand {
    private Thermostat _thermostat;
    private int _prevTemp;
    private int _newTemp;
    public TempChangeCommand(Thermostat t, int temp) {
        _thermostat = t;
        _newTemp = temp;
    }
    public void Execute() {
        _prevTemp = _thermostat.Temperature;
        _thermostat.SetTemperature(_newTemp);
    }
    public void Undo() => _thermostat.SetTemperature(_prevTemp);
}

public class RemoteControl {
    private Stack<ICommand> _history = new Stack<ICommand>();
    public void ExecuteCommand(ICommand command) {
        command.Execute();
        _history.Push(command);
    }
    public void Undo() {
        if (_history.Count > 0) _history.Pop().Undo();
    }
}