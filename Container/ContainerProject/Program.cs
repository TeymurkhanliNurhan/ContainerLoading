// See https://aka.ms/new-console-template for more information

using System.Threading.Channels;
using ContainerProject;
 
class Program
{
    private static List<LiquidContainer> LiquidContainers = new List<LiquidContainer>();
    private static List<Container> Containers = new List<Container>();

    public static List<LiquidContainer> GetLiquidContainers() {return LiquidContainers;}

    public static List<Container> GetContainer()
    {
        return Containers;}
    
    public static void AddLiquidContainer(LiquidContainer liquidContainer)
    {
        LiquidContainers.Add(liquidContainer);
        Containers.Add(liquidContainer); // Also add to the general list of containers
    }
    public interface IHazardNotifier
    {
        void NotifyHazard(string containerNumber);
    }
    
    
    static void Main(string[] args)
    {
        // Inside your Program class

       

        static LiquidContainer FindContainerBySerialNumber(string serialNumber)
        {
            foreach (LiquidContainer container in LiquidContainers)
            {
                if (container.getSerNum() == serialNumber)
                {
                    return container;
                }
            }
            return null; // Return null if the container is not found
        }
        

        Boolean exit = false;

        while (!false)
        {
            Console.WriteLine("0.Exit ");
            Console.WriteLine("1.Add a container ");
            Console.WriteLine("2.Empty a container ");
            Console.WriteLine("3.Load container ");
            Console.WriteLine("4.Info about a container");
            int input = Convert.ToInt32(Console.ReadLine());
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
                    int ConType = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Enter height: ");
                    double height = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter depth: ");
                    double depth = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter tare weight: ");
                    double tareWeight = Convert.ToDouble(Console.ReadLine());
                    Console.WriteLine("Enter maximum payload: ");
                    double maxPayLoad = Convert.ToDouble(Console.ReadLine());


                    if (ConType == 1)
                    {
                        Console.WriteLine("Enter the type of container: hazardous(true)/ ordinary(false): ");
                        bool cargo = Convert.ToBoolean(Console.ReadLine());

                        LiquidContainer liquidContainer = new LiquidContainer(height, tareWeight, depth, maxPayLoad,cargo);
                        AddLiquidContainer(liquidContainer);
                    }
                    else if (ConType == 2) {break;}
                    else if (ConType == 3)
                    {
                        break;
                    }
                    else
                    {
                        break;
                    }
            break;
                
                    case 2:
                    Console.WriteLine("Enter the serial number of container"); 
                    string sernum1 =Console.ReadLine();
                    if (FindContainerBySerialNumber(sernum1) == null)
                    {
                        Console.WriteLine("Not such a container ");
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Enter the mass of cargo you want to empty");
                        double emptyCargo = Convert.ToDouble(Console.ReadLine());
                        FindContainerBySerialNumber(sernum1).emptyingCargo(emptyCargo);
                        break;
                    }
                    
                    break;
                    
                    case 3:
                    Console.WriteLine("Enter the serial number of container");
                    string sernum =Console.ReadLine();
                    Console.WriteLine("Enter mass of load: ");
                    double mass = Convert.ToDouble(Console.ReadLine());

                    if (FindContainerBySerialNumber(sernum) == null)
                    {
                        Console.WriteLine("Not such a container ");
                        break;
                    }
                    else
                    {
                        FindContainerBySerialNumber(sernum).loadingCargo(mass);
                        break;
                    }

                    case 4:
                    Console.WriteLine("Do you want to get info about all containers (1) or special one(2)");
                        int concase4=Convert.ToInt32(Console.ReadLine());
                        if (concase4==1)
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
                            string sernum2 =Console.ReadLine();
                            Console.WriteLine(
                            FindContainerBySerialNumber(sernum2).GetContainerInfo());
                            break;
                        }
                        else
                        {
                            break;
                        }
                
                
                default: break;
            }
            
            
        }
    }
    
}