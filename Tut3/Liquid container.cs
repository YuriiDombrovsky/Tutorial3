namespace Tut3;

public class Liquid_container : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    protected override string ContainerType => "L";

    public Liquid_container(double maxPayload, double tareWeight, bool isHazardous) : base(maxPayload, tareWeight)
    {
        IsHazardous = isHazardous;
    }

    public override void LoadCargo(double mass)
    {
        double limit;
        if (IsHazardous)
        {
            limit = MaxPayload * 0.5;
        }
        else
        {
            limit = MaxPayload * 0.9;
        }
        if (mass + Mass > limit)
        {
            NotifyHazard($"Attempted to overload hazardous container {SerialNumber}.");
            throw new OverfillException($"Cannot load {mass}kg. Hazardous cargo limit is {limit}kg.");
        }
        
        base.LoadCargo(mass);
        
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[Hazard] {message}");
    }
}