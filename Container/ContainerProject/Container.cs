namespace ContainerProject;
public class Container
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private String sernum;
    private Double maxPayload;
    private static int contNum = 1;
    
    public Container(double height,double tareWeight,double depth,double maxPayload)
    {
        this.height = height;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.mass = 0;
        this.maxPayload = maxPayload;
        this.sernum = GenerateSerialNumber();
        

    }

    protected virtual string GetType()
    {
        return "default"; // Default type prefix for Container
    }
    private string GenerateSerialNumber()
    {
        string typePrefix = GetType();
        string serialNumber = $"KON-{typePrefix}-{contNum}";
        contNum++; 
        return serialNumber;
    }

    public double getMass()
    {
        return this.mass;
    }

    public void setMass(double mass)
    {
        this.mass = mass;
    }
    public double getHeight()
    {
        return this.height;
    }

    public void setHeight(double height)
    {
        this.height = height;
    }
    public double getTareWeight()
    {
        return this.tareWeight;
    }

    public void setTareWeight(double tare_weight)
    {
        this.tareWeight = tare_weight;
    }
    public double getDepth()
    {
        return this.depth;
    }

    public void setDepth(double depth)
    {
        this.depth = depth;
    }

    public String getSerNum()
    {
        return sernum;
    }

    public void setSerNum(String sernum)
    {
        this.sernum = sernum;
    }

    public double getMaxPayload()
    {
        return maxPayload;
    }

    public void setMaxPayload(double maxPayload)
    {
        this.maxPayload = maxPayload;
    }

    public void emptyingCargo()
    {
        mass = 0;
    }

    public class OverfillException : Exception
    {
        public OverfillException(string message) : base(message)
        {
        }
    }
    public virtual void loadingCargo(double weight)
    {
        if (weight + mass <= maxPayload)
        {
         mass += weight; 
        }
        
        else   throw new OverfillException("No place");
    }
    
    public virtual string GetContainerInfo()
    {
        string info = "\n"; 
        info += $"Serial Number: {getSerNum()}\n";
        info += $"Height: {getHeight()} units\n";
        info += $"Tare Weight: {getTareWeight()} units\n";
        info += $"Depth: {getDepth()} units\n";
        info += $"Maximum Payload: {getMaxPayload()} units\n";
        info += $"Current Cargo Mass: {getMass()} units\n";
        return info;
    }
    
    
}