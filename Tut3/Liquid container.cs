namespace Tut3;

public class LiquidContainer : Container, IHazardNotifier
{
    public bool IsHazardous { get; }

    protected override string ContainerType => "L";

    public LiquidContainer(double maxPayload, double tareWeight, bool isHazardous) : base(maxPayload, tareWeight)
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
            NotifyHazard($"Attempted to overload container {SerialNumber}.");
            throw new OverfillException($"Cannot load {mass}kg. Cargo limit is {limit}kg.");
        }
        
        base.LoadCargo(mass);
        
    }
    public void NotifyHazard(string message)
    {
        Console.WriteLine($"[Hazard] {message}");
    }

    public override string ToString()
    {
        return base.ToString() + $", Hazardous: {IsHazardous}";
    }
}