using Tut3;

ContainerShip Titanic = new ContainerShip("Titanic", 100, 5, 10);

Container c1 = new LiquidContainer(1000, 100, 200, 300, true);
Container c2 = new GasContainer(2000, 100, 300, 400, 5);
Container c3 = new RefrigeratedContainer(3000, 200, "Bananas", -5, 100, 100 );
//Overloading them
try
{
    //c1.LoadCargo(900);
    c1.LoadCargo(400);
    //c2.LoadCargo(2100);
    c2.LoadCargo(2000);
    //c3.LoadCargo(3100);
    c3.LoadCargo(3000);
}
catch (OverfillException e)
{
    Console.WriteLine(e);
}
Titanic.LoadContainer(c1);
Titanic.LoadContainers(new List<Container>(){ c2, c3 });

Container c4 = new GasContainer(2000, 100, 300, 400, 5);
Console.WriteLine(c4);
c4.LoadCargo(1000);
Console.WriteLine(c4);
c4.LoadCargo(1000);

Titanic.LoadContainer(c4);

Titanic.PrintInfo();
Console.WriteLine(c4);

Titanic.UnloadContainer(c4);
Titanic.PrintInfo();
//Should left 5%
c4.UnloadCargo();
Console.WriteLine(c4);

Titanic.ReplaceContainer("KON-G-1", c4);

ContainerShip notTitanic = new ContainerShip("NotTitanic", 100, 5, 10);
notTitanic.LoadContainer(c2);

notTitanic.TransferContainer(Titanic, "KON-G-1");


notTitanic.PrintInfo();
Titanic.PrintInfo();

GasContainer c5 = new GasContainer(10000, 0, 300, 400, 5);
c5.LoadCargo(10000);
//But it is 100% full
notTitanic.PrintInfo();
notTitanic.LoadContainer(c5);

notTitanic.TransferContainer(Titanic, "KON-G-3");

notTitanic.PrintInfo();

