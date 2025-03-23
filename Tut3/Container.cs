namespace Tut3;

public abstract class Container
{
    private static Dictionary<string, int> _serialCounters = new()
    {
        { "L", 1 }, { "G", 1 }, { "C", 1 }
    };
    
    public string SerialNumber { get; }
    public double Mass { get; set; }
    public double MaxPayload { get; }
    public double TareWeight { get; }
    
    public double Height { get; }
    public double Depth { get; }

    protected virtual string ContainerType => "";

    public Container(double maxPayload, double tareWeight, double height, double depth)
    {
        SerialNumber = GenerateSerialNumber();
        MaxPayload = maxPayload;
        TareWeight = tareWeight;
        Height = height;
        Depth = depth;
    }

    private string GenerateSerialNumber()
    {
        return $"KON-{ContainerType}-{_serialCounters[ContainerType]++}";
    }

    public virtual void LoadCargo(double mass)
    {
        if (mass + Mass > MaxPayload)
            throw new OverfillException($"Cannot load {mass}kg. Exceeds max payload {MaxPayload}kg.");
        Mass += mass;
    }
    
    public virtual void UnloadCargo()
    {
        Mass = 0;
    }

    public override string ToString()
    {
        return $"{SerialNumber}: Mass: {Mass}kg, MaxPayload: {MaxPayload}kg, TareWeight: {TareWeight}kg, Height: {Height}, Depth: {Depth}";
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}