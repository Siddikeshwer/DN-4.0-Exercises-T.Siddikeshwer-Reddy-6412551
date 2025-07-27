using System;

// Computer.cs
public class Computer
{
    private readonly string _cpu;
    private readonly string _ram;
    private readonly string _storage;
    private readonly string _gpu;

    private Computer(Builder builder)
    {
        _cpu = builder.Cpu;
        _ram = builder.Ram;
        _storage = builder.Storage;
        _gpu = builder.Gpu;
    }

    public class Builder
    {
        private string Cpu;
        private string Ram;
        private string Storage;
        private string Gpu;

        public Builder SetCpu(string cpu)
        {
            Cpu = cpu;
            return this;
        }

        public Builder SetRam(string ram)
        {
            Ram = ram;
            return this;
        }

        public Builder SetStorage(string storage)
        {
            Storage = storage;
            return this;
        }

        public Builder SetGpu(string gpu)
        {
            Gpu = gpu;
            return this;
        }

        public Computer Build()
        {
            return new Computer(this);
        }
    }

    public override string ToString()
    {
        return $"Computer [CPU={_cpu}, RAM={_ram}, Storage={_storage}, GPU={_gpu}]";
    }
}

// Program.cs
public class Program
{
    public static void Main(string[] args)
    {
        Computer computer = new Computer.Builder()
            .SetCpu("Intel i7")
            .SetRam("16GB")
            .SetStorage("1TB SSD")
            .SetGpu("NVIDIA GTX 3080")
            .Build();

        Console.WriteLine(computer);
    }
}
