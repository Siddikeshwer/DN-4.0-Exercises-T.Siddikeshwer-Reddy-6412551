interface Command {
    void execute();
}
class Light {
    public void on() {using System;

// Command.cs
public interface ICommand
{
    void Execute();
}

// Light.cs
public class Light
{
    public void On()
    {
        Console.WriteLine("Light is ON");
    }

    public void Off()
    {
        Console.WriteLine("Light is OFF");
    }
}

// LightOnCommand.cs
public class LightOnCommand : ICommand
{
    private readonly Light _light;

    public LightOnCommand(Light light)
    {
        _light = light ?? throw new ArgumentNullException(nameof(light));
    }

    public void Execute()
    {
        _light.On();
    }
}

// LightOffCommand.cs
public class LightOffCommand : ICommand
{
    private readonly Light _light;

    public LightOffCommand(Light light)
    {
        _light = light ?? throw new ArgumentNullException(nameof(light));
    }

    public void Execute()
    {
        _light.Off();
    }
}

// RemoteControl.cs
public class RemoteControl
{
    private ICommand _command;

    public void SetCommand(ICommand command)
    {
        _command = command ?? throw new ArgumentNullException(nameof(command));
    }

    public void PressButton()
    {
        _command.Execute();
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        Light light = new Light();

        ICommand lightOn = new LightOnCommand(light);
        ICommand lightOff = new LightOffCommand(light);

        RemoteControl remote = new RemoteControl();

        remote.SetCommand(lightOn);
        remote.PressButton();

        remote.SetCommand(lightOff);
        remote.PressButton();
    }
}
        System.out.println("Light is ON");
    }
    
    public void off() {
        System.out.println("Light is OFF");
    }
}

class LightOnCommand implements Command {
    private Light light;
    
    public LightOnCommand(Light light) {
        this.light = light;
    }
    
    @Override
    public void execute() {
        light.on();
    }
}

class LightOffCommand implements Command {
    private Light light;
    
    public LightOffCommand(Light light) {
        this.light = light;
    }
    
    @Override
    public void execute() {
        light.off();
    }
}

class RemoteControl {
    private Command command;
    
    public void setCommand(Command command) {
        this.command = command;
    }
    
    public void pressButton() {
        command.execute();
    }
}

class CommandTest {
    public static void main(String[] args) {
        Light light = new Light();
        
        Command lightOn = new LightOnCommand(light);
        Command lightOff = new LightOffCommand(light);
        
        RemoteControl remote = new RemoteControl();
        
        remote.setCommand(lightOn);
        remote.pressButton();
        
        remote.setCommand(lightOff);
        remote.pressButton();
    }
}
