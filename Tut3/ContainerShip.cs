namespace Tut3;

public class ContainerShip
{
    

    public string Name { get; }
    public double MaxSpeed { get; }
    public int MaxContainers { get; }
    //In tons
    public double MaxWeight { get; }
    public List<Container> Containers { get; }
    
    public ContainerShip(string name, double maxSpeed, int maxContainers, double maxWeight)
    {
        Name = name;
        MaxSpeed = maxSpeed;
        MaxContainers = maxContainers;
        MaxWeight = maxWeight;
        Containers = new List<Container>();
    }

    public double getCurrentWeight()
    {
        double totalWeight = 0;
        for (int i = 0; i < Containers.Count; i++)
        {
            //In kg
            totalWeight += Containers[i].TareWeight + Containers[i].Mass;
        }
        return totalWeight / 1000;
    }

    public void LoadContainer(Container container)
    {
        double totalWeight = getCurrentWeight();
        

        if (Containers.Count == MaxContainers || totalWeight + (container.TareWeight + container.Mass) / 1000 > MaxWeight)
        {
            Console.WriteLine($"Cannot load container {container.SerialNumber}. Ship is full.");
            return;
        }
        Containers.Add(container);
        Console.WriteLine($"Container {container.SerialNumber} loaded onto ship.");
    }

    //Task: Load a list of containers onto a ship,
    //but how we are gonna handle if only part of the list fits into ship?
    //I guess I will add only that one that fits

    public void LoadContainers(List<Container> containers)
    {
        foreach (var container in Containers)
        {
            LoadContainer(container);
        }
    }

    //Since we have(or supposed to have object for old container, method accepts serial number for convenience 
    public void ReplaceContainer(string serialNumber, Container newContainer)
    {
        //Sweet
        var oldContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (oldContainer == null)
        {
            Console.WriteLine($"Container {serialNumber} not found on the ship.");
            return;
        }
        double curTotalWeight = getCurrentWeight();
        double newTotalWeight = curTotalWeight - oldContainer.TareWeight - oldContainer.Mass 
                                + newContainer.TareWeight + newContainer.Mass;
        if (newTotalWeight > MaxWeight)
        {
            Console.WriteLine($"Cannot replace {serialNumber} with {newContainer.SerialNumber}. Ship weight limit exceeded.");
            return;
        }
        Containers.Remove(oldContainer);
        Containers.Add(newContainer);
        Console.WriteLine($"Replaced container {serialNumber} with {newContainer.SerialNumber}.");
        
    }
    public void UnloadContainer(Container container)
    {
        if (Containers.Remove(container))
        {
            Console.WriteLine($"Container {container.SerialNumber} unloaded from ship.");
        }
        else
        {
            Console.WriteLine($"Container {container.SerialNumber} not found in ship.");
        }
    }

    public void TransferContainer(ContainerShip newShip, string serialNumber)
    {
        var oldContainer = Containers.FirstOrDefault(c => c.SerialNumber == serialNumber);
        if (oldContainer == null)
        {
            Console.WriteLine($"Container {serialNumber} not found on the ship.");
            return;
        }
        double newShipTotalWeight = newShip.getCurrentWeight();
        if (newShip.Containers.Count == MaxContainers || newShipTotalWeight + (oldContainer.TareWeight + oldContainer.Mass) / 1000 > MaxWeight)
        {
            Console.WriteLine($"Cannot load container {serialNumber}. Ship is full.");
            return;
        }
        Containers.Remove(oldContainer);
        newShip.LoadContainer(oldContainer);
        Console.WriteLine($"Successfully transferred {serialNumber} from {Name} to {newShip.Name}.");

    }

    public override string ToString()
    {
        //Print information about a given ship and its cargo.
        //Cargo of the ship is containers, but printing info about all of them feels redundant
        return $"Ship {Name}: Speed: {MaxSpeed} knots, MaxContainers: {MaxContainers}, MaxWeight: {MaxWeight} tons, CContainers loaded: {Containers.Count}, TotalWeight: {getCurrentWeight()}";

    }
}