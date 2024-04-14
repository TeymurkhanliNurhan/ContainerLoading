// See https://aka.ms/new-console-template for more information

using System.Runtime.InteropServices;
using System.Threading.Channels;
using ContainerProject;
 
class Program {
    private static List<Ship> Ships = new List<Ship>();
    private static List<RefrigeratedContainer> RefrigeratedContainers = new List<RefrigeratedContainer>();
    private static List<GasContainer> GasContainers = new List<GasContainer>();
    private static List<LiquidContainer> LiquidContainers = new List<LiquidContainer>();
    private static List<Container> Containers = new List<Container>();
    public static List<Ship> GetShips() { return Ships;} 
    public static List<LiquidContainer> GetLiquidContainers() {return LiquidContainers;}
    public static List<RefrigeratedContainer> GetRefrigeratedContainers() { return RefrigeratedContainers;}
    public static List<GasContainer> GetGasContainers() { return GasContainers;}
    public static List<Container> GetContainer() { return Containers;}
    public static void AddLiquidContainer(LiquidContainer liquidContainer)
    {
        LiquidContainers.Add(liquidContainer);
        Containers.Add(liquidContainer); // Also add to the general list of containers
    }
    public static void AddGasContainer(GasContainer gasContainer)
    {
        GasContainers.Add(gasContainer);
        Containers.Add(gasContainer); // Also add to the general list of containers
    }
    public static void AddrRefrigeratedContainer(RefrigeratedContainer refrigeratedContainer)
    {
        RefrigeratedContainers.Add(refrigeratedContainer);
        Containers.Add(refrigeratedContainer); // Also add to the general list of containers
    }
    static Ship FindShipByContainerSerialNumber(string containerSerialNumber)
    {
        // Iterate through each ship in the Ships list
        foreach (var ship in Ships)
        {
            // Check if the current ship contains the container with the given serial number
            if (ship.getContainer().Any(c => c.getSerNum() == containerSerialNumber))
            {
                // If found, return the ship
                return ship;
            }
        }
        // If no ship is found with the container, return null
        return null;
    }

    public static void CountConsByType()
    {
        var g = 0;
        foreach (var gasContainer in GasContainers)
        {
            g++;
        }
        var l = 0;
        foreach (var VARIABLEliquidContainer in LiquidContainers)
        {
            l++;
        }
        var r = 0;
        foreach (var variableRefrigeratedContainer  in RefrigeratedContainers)
        {
            r++;
        }
        Console.WriteLine($"Number of Gas Containers: {g}");
        Console.WriteLine($"Number of Liquid Containers: {l}");
        Console.WriteLine($"Number of Refrigerated Containers: {r}");
    }
    static void Main(string[] args)
    {
        static Ship FindShipBySerialNumber(string sernum)
        {
            foreach (Ship ship in Ships)
            {
                if (ship.GetSernum()==sernum)
                {
                    return ship;
                }
            }
            return null;
        }
        static Container FindContainerBySerialNumber(string serialNumber)
        {
            foreach (Container container in Containers)
            {
                if (container.getSerNum() == serialNumber)
                {
                    return container;
                }
            }
            return null; // Return null if the container is not found
        }
        static Container FindContainerBySerialNumberRef(string serialNumber)
        {
            foreach (RefrigeratedContainer refrigeratedContainer in RefrigeratedContainers)
            {
                if (refrigeratedContainer.getSerNum() == serialNumber)
                {
                    return refrigeratedContainer;
                }
            }
            return null; // Return null if the container is not found
        }
        var exit = false;
        while (!false)
        {
            Console.WriteLine("\n0.Exit ");
            Console.WriteLine("1.Add a container ");
            Console.WriteLine("2.Empty a container ");
            Console.WriteLine("3.Load container ");
            Console.WriteLine("4.Info about a container");
            Console.WriteLine("5.Create a ship");
            Console.WriteLine("6.Info about a ship");
            Console.WriteLine("7.Load a container onto a ship");
            Console.WriteLine("8.Load a list of containers onto a ship");
            Console.WriteLine("9.Remove a container from the ship");
            Console.WriteLine("10.Replacing container with another ");
            Console.WriteLine("11.Transferring container to other ship \n");
            var input = Convert.ToInt32(Console.ReadLine());
            switch (input)
            {
                case 0:
                    exit = true;
                    break;
                case 1:
                    Console.WriteLine("Enter the type of container: ");
                    Console.WriteLine("1.Liquid ");
                    Console.WriteLine("2.Gas ");
                    Console.WriteLine("3.Refrigerated ");
                    var ConType = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter height: ");
                    var height = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter depth: ");
                    var depth = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter tare weight: ");
                    var tareWeight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter maximum payload: ");
                    var maxPayLoad = Convert.ToDouble(Console.ReadLine());
                    if (ConType == 1)
                    {
                        Console.WriteLine("Enter the type of container: hazardous(true)/ ordinary(false): ");
                        var cargo = Convert.ToBoolean(Console.ReadLine());
                        var liquidContainer = new LiquidContainer(height, tareWeight, depth, maxPayLoad, cargo);
                        AddLiquidContainer(liquidContainer);
                        break;
                    }
                    else if (ConType == 2)
                    {
                        Console.WriteLine("Enter the pressure");
                        var pressure = Convert.ToDouble(Console.ReadLine());
                        var gasContainer = new GasContainer(height, tareWeight, depth, maxPayLoad, pressure);
                        AddGasContainer(gasContainer);
                        break;
                    }
                    else if (ConType == 3)
                    {
                        Console.WriteLine("Enter the type of product");
                        Console.WriteLine(
                            "Types: Bananas/ Chocolate/ Fish/ Meat/ Ice cream/ Frozen pizza/ Cheese/ Sausage/ Butter/ Eggs ");
                        var type = Convert.ToString(Console.ReadLine());
                        var refrigeratedContainer = new RefrigeratedContainer(height, tareWeight, depth, maxPayLoad, type);
                        AddrRefrigeratedContainer(refrigeratedContainer);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Wrong input");
                        break;
                    }
                    break;
                case 2:
                    Console.WriteLine("Enter the serial number of container");
                    var sernum1 = Console.ReadLine();
                    if (FindContainerBySerialNumber(sernum1) == null)
                    {
                        Console.WriteLine("Not such a container ");
                        break;
                    }
                    else
                    {
                        foreach (var gasContainer in GasContainers)
                        {
                            if (FindContainerBySerialNumber(sernum1)==gasContainer)
                            {
                                FindContainerBySerialNumber(sernum1).emptyingCargo(0);
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Enter the mass of cargo you want to empty");
                                var emptyCargo = Convert.ToDouble(Console.ReadLine());
                                if (emptyCargo <= 0)
                                {
                                    Console.WriteLine("Wrong input");
                                }
                                else FindContainerBySerialNumber(sernum1).emptyingCargo(emptyCargo);
                                break;
                            }
                        }
                    }
                    break;
                case 3:
                    Console.WriteLine("Enter the serial number of container");
                    var sernum = Console.ReadLine();
                    if (FindContainerBySerialNumber(sernum) == null)
                    {
                        Console.WriteLine("Not such a container ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter mass of load: ");
                        double mass = Convert.ToDouble(Console.ReadLine());
                        if (mass <= 0)
                        {
                            Console.WriteLine("Wrong input");
                            break;
                        }
                        if (FindContainerBySerialNumber(sernum) is IProductTypeContainer productTypeContainer)
                        {
                            Console.WriteLine("Enter the type of product you want to upload:");
                            var productType = Console.ReadLine();
                            if (!productTypeContainer.CanLoadProductType(productType))
                            {
                                Console.WriteLine(
                                    "This container can only store " + productTypeContainer.GetType() + ".");
                                break;
                            }
                            FindContainerBySerialNumber(sernum).loadingCargo(mass);
                        }
                        else FindContainerBySerialNumber(sernum).loadingCargo(mass);
                        break;
                    }
                case 4:
                    Console.WriteLine("Do you want to get info about all containers (1) or special one(2)");
                    int concase4 = Convert.ToInt32(Console.ReadLine());
                    if (concase4 == 1)
                    {
                        foreach (Container container in Containers)
                        {
                            Console.WriteLine(
                                container.GetContainerInfo());
                        }
                        break;
                    }
                    else if (concase4 == 2)
                    {
                        Console.WriteLine("Write the serial number of container");
                        var sernum2 = Console.ReadLine();
                        Console.WriteLine(
                            FindContainerBySerialNumber(sernum2).GetContainerInfo());
                        break;
                    }
                    else
                    {
                        break;
                    }
                case 5:
                    Console.WriteLine("Enter the maximum speed in knots: ");
                    var maxSpeed = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter the maximum container number: ");
                    var maxCons = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter the maximum payload weight: ");
                    var maxWeight = Convert.ToDouble(Console.ReadLine());
                    var ship = new Ship(maxSpeed, maxCons, maxWeight);
                    Ships.Add(ship);
                    Console.WriteLine(ship.GetSernum());
                    break;
                case 6:
                    Console.WriteLine("Enter the serial number of ship");
                    var sernumShip = Convert.ToString(Console.ReadLine());
                    Console.WriteLine(FindShipBySerialNumber(sernumShip).GetShipInfo());
                    break;
                case 7:
                    Console.WriteLine("Enter the serial number of container");
                    var sernumCon = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter the serial number of ship");
                    var sernumShip2 = Convert.ToString(Console.ReadLine());
                    FindShipBySerialNumber(sernumShip2).addContainer(FindContainerBySerialNumber(sernumCon));
                    break;
                case 8:
                    Console.WriteLine(
                        "Enter the list of serial number of container in this format: number1,number2,...numbern");
                    var sernumconlist = Convert.ToString(Console.ReadLine());
                    var serNums = sernumconlist.Split(",");
                    Console.WriteLine("Enter the serial number of ship");
                    var sernumShip3 = Convert.ToString(Console.ReadLine());
                    foreach (string serNum in serNums)
                    {
                        FindShipBySerialNumber(sernumShip3).addContainer(FindContainerBySerialNumber(serNum));
                    }
                    break;
                case 9:
                    Console.WriteLine("Enter serial number of the container");
                    var sernum9 = Convert.ToString(Console.ReadLine());
                    FindShipByContainerSerialNumber(sernum9).removeContainer(FindContainerBySerialNumber(sernum9));
                    break;
                case 10:
                    Console.WriteLine("Enter serial number of the container which you want to sub off: ");
                    string sernum101 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter serial number of the container which you want to sub in: ");
                    string sernum102 = Convert.ToString(Console.ReadLine());
                    Ship a = FindShipByContainerSerialNumber(sernum101);
                    a.removeContainer(FindContainerBySerialNumber(sernum101));
                    a.addContainer(FindContainerBySerialNumber(sernum102));
                    break;
                case 11:
                    Console.WriteLine("Enter serial number of the container: ");
                    string sernum11 = Convert.ToString(Console.ReadLine());
                    Console.WriteLine("Enter serial number of the ship you want transfer this container to: ");
                    string sernumship11 = Convert.ToString(Console.ReadLine());
                    Ship b = FindShipByContainerSerialNumber(sernum11);
                    b.removeContainer(FindContainerBySerialNumber(sernum11));
                    FindShipBySerialNumber(sernumship11).addContainer(FindContainerBySerialNumber(sernum11));
                    break;
                case 12:
                    CountConsByType();
                    break;
                default: break;
            }

        }
    }
}