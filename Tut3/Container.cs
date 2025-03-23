namespace Tut3;

public abstract class Container
{
    private static int _serialCounter = 1;
    
    public string SerialNumber { get; }
    public double Mass { get; set; }
    public double MaxPayload { get; }
    public double TareWeight { get; }

    protected virtual string ContainerType => "";

    public Container(double maxPayload, double tareWeight)
    {
        SerialNumber = GenerateSerialNumber();
        MaxPayload = maxPayload;
        TareWeight = tareWeight;
    }

    private string GenerateSerialNumber()
    {
        return $"KON-{ContainerType}-{_serialCounter++}";
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
        return $"{SerialNumber}: Mass: {Mass}kg, MaxPayload: {MaxPayload}kg, TareWeight: {TareWeight}kg";
    }
}

public class OverfillException : Exception
{
    public OverfillException(string message) : base(message) { }
}