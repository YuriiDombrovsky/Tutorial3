namespace Tut3;

public class RefrigeratedContainer : Container
{
    //You can add only registered types, you can have only one type per container,
    //each container has its temperature that cannot be higher than required
    
    //Since fridge is only container that has stated that we need to store information about what is inside,
    //I assume that in other containers this information is not important
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

    //Load cargo is just base one

    public override string ToString()
    {
        return base.ToString() + $", Temperature: {Temperature}, ProductType: {ProductType}, RequiredTemperature: {RequiredTemperature}";
    }
}