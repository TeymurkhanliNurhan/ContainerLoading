namespace ContainerProject;
public class Ship(double maxSpeed, int conNumber, double maxWeight)
{
    private List<Container> containers = new List<Container>();
    private double maxSpeed = maxSpeed;
    private int conNumber = conNumber;
    private double maxWeight = maxWeight;
    private static int contNum = 1;
    private string sernum = GenerateSerialNumber();
    private double currentWeight = 0;
    private double currentCons = 0;
    private static string GenerateSerialNumber()
    {
        var serialNumber = $"ship{contNum}";
        contNum++;
        return serialNumber;
    }
    public void AddContainer(Container container)
    {
        if ((container.MaxPayload + container.TareWeight) / 1000 > maxWeight)
        {
            Console.WriteLine(
                "This container can not be add to this ship, because it exceeds the maximum Payload mass");
        }
        else if ((currentCons + 1) > conNumber)
        {
            Console.WriteLine("This container can not be added to this ship, because it exceeds the container limit");
        }
        else
        {
            currentWeight += container.MaxPayload / 1000;
            containers.Add(container);
            this.currentCons++;
        }
    }
    public void RemoveContainer(Container container)
    {
        currentWeight -= container.MaxPayload / 1000;
        containers.Remove(container);
        this.currentCons--;
    }
    public virtual string GetShipInfo()
    {
        string info = "\n";
        info += $"Serial Number: {Sernum}\n";
        info += $"Max speed : {MaxSpeed} knots \n";
        info += $"Maximum container number: {conNumber}\n";
        info += $"Current container number: {currentCons}\n";
        info += $"Maximum payload weight: {maxWeight} ton\n";
        info += $"Current payload weight: {currentWeight} ton\n";
        info += "Containers: ";
        foreach (Container container in containers)
        {
            info += container.SerNum + "|||";
        }
        info += "\n";
        return info;
    }
    //Getters and Setters
    public double MaxSpeed { get; set; }
    public int ConNumber { get; set; }
    public double MaxWeight { get; set; } 
    public string Sernum { get; set; }
    public double CurrentWeight { get; set; }
    public List<Container> GetContainer()
    {
        return containers;
    }
}