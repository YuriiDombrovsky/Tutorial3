namespace Tut3;

public class RefrigeratedContainer : Container
{
    public string ProductType { get; }
    public double Temperature { get; }
    
    public double RequiredTemperature { get; }
    
    protected override string ContainerType => "C";

    //This temperature thing is very confusing, in text
    //it doesnt specify how it should interact with user
    private static Dictionary<string, double> ProductTemperatures = new Dictionary<string, double>()
    {
        { "Bananas", 13.3 },
        { "Meat", -15.0 },
        { "Fish", 2.0 }
    };
    
    
    public RefrigeratedContainer(double maxPayload, double tareWeight, string productType, double temperature) : base(maxPayload, tareWeight)
    {
        if (!ProductTemperatures.ContainsKey(productType))
        {
            throw new Exception($"Product type {productType} is not supported");
        }
        ProductType = productType;
        RequiredTemperature = ProductTemperatures[ProductType];
        if (Temperature > RequiredTemperature)
        {
            throw new Exception($"Temperature {temperature} is too high");
        }
        
        Temperature = temperature;
    }


    public override void LoadCargo(double mass)
    {
        base.LoadCargo(mass);
    }
}