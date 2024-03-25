namespace ContainerProject;

public class Ship
{
    private List<Container> containers=new List<Container>(); 
    public List<Container> getContainer() { return containers;}
    
    private double maxSpeed;
    private int conNumber;
    private double maxWeight;
    private static int contNum=1;
    private string sernum;
    private double currentWeight = 0;
    private double currentCons = 0;

    public Ship(double maxSpeed, int conNumber, double maxWeight)
    {
        this.maxSpeed = maxSpeed;
        this.conNumber = conNumber;
        this.maxWeight = maxWeight;
        this.sernum = GenerateSerialNumber();
    }

    private string GenerateSerialNumber()
    {
        string serialNumber = $"ship{contNum}";
        contNum++; 
        return serialNumber;
    }

    public void addContainer(Container container)
    {
        if ((container.getMaxPayload()+container.getTareWeight())/1000>maxWeight)
        {
            Console.WriteLine("This container can not be add to this ship, because it exceeds the maximum Payload mass");
        }
        else if ((currentCons+1)>conNumber)
        {
            Console.WriteLine("This container can not be added to this ship, because it exceeds the container limit");
        }
        else
        {
            currentWeight += container.getMaxPayload()/1000;
            containers.Add(container);
            this.currentCons++;
        }
    }

    public void removeContainer(Container container)
    {
        currentWeight -= container.getMaxPayload()/1000;
        containers.Remove(container);
        this.currentCons--;
    }
    

    public virtual string GetShipInfo()
    {
        string info = "\n";
        info += $"Serial Number: {GetSernum()}\n";
        info += $"Max speed : {GetMaxSpeed()} knots \n";
        info += $"Maximum container number: {conNumber}\n";
        info += $"Current container number: {currentCons}\n";
        info += $"Maximum payload weight: {maxWeight} ton\n";
        info += $"Current payload weight: {currentWeight} ton\n";
        info += "Containers: ";
        foreach (Container container in containers)
        {
            info += container.getSerNum()+"|||";
            
        }
        info += "\n";
        return info;
    }
    
    //Getters and Setters
    public double GetMaxSpeed()
    {
        return maxSpeed;
    }
    
    public void SetMaxSpeed(double value)
    {
        maxSpeed = value;
    }

    public int GetConNumber()
    {
        return conNumber;
    }
    
    public void SetConNumber(int value)
    {
        conNumber = value;
    }
    
    public double GetMaxWeight()
    {
        return maxWeight;
    }
    
    public void SetMaxWeight(double value)
    {
        maxWeight = value;
    }
    
    public static int GetContNum()
    {
        return contNum;
    }
    
    public string GetSernum()
    {
        return sernum;
    }
    
    public void SetSernum(string value)
    {
        sernum = value;
    }
    
    public double GetCurrentWeight()
    {
        return currentWeight;
    }
    
    public void SetCurrentWeight(double value)
    {
        currentWeight = value;
    }
}