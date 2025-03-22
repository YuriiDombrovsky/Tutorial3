namespace Tut3;

public class GasContainer : Container, IHazardNotifier
{
    
    public double Pressure { get; }

    protected override string ContainerType => "G";

    public GasContainer(double maxPayload, double tareWeight, double pressure) : base(maxPayload, tareWeight)
    {
        Pressure = pressure;
    }

    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[Hazard] {message}");
    }

    public override void LoadCargo(double mass)
    {
        if (mass + Mass > MaxPayload)
        {
            //Or just call super, but this method seems lonely
            NotifyHazard($"Attempted to overload container {SerialNumber}.");
            throw new OverfillException($"Cannot load {mass}kg. Cargo limit is {MaxPayload}kg.");
        }
        
        base.LoadCargo(mass);
    }

    public override void UnloadCargo()
    {
        Mass *= 0.05;
    }
}