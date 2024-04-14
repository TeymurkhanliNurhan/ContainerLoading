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
     public virtual void emptyingCargo(double emptyweight)
        {
            if(getMass()-emptyweight<0) Console.WriteLine("Not enough amount of cargo");
            mass -= emptyweight;
        }
        public class OverfillException : Exception
        {
            public OverfillException(string message) : base(message)
            {
            }
        }
        public virtual void loadingCargo(double weight)
        {
            if (weight  <= maxPayload)
            {
             mass += weight; 
            }
            else   throw new OverfillException("No place");
        }
        public virtual string GetContainerInfo()
        {
            string info = "\n"; 
            info += $"Serial Number: {getSerNum()}\n";
            info += $"Height: {getHeight()} cm\n";
            info += $"Tare Weight: {getTareWeight()} kg\n";
            info += $"Depth: {getDepth()} cm\n";
            info += $"Maximum Payload: {getMaxPayload()} kg\n";
            info += $"Current Cargo Mass: {getMass()} kg\n";
            return info;
        }
    private string GenerateSerialNumber()
    {
        string typePrefix = GetType();
        string serialNumber = $"KON-{typePrefix}-{contNum}";
        contNum++; 
        return serialNumber;
    }
    //Getters and setters
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
  protected virtual string GetType()
    {
        return "default"; // Default type prefix for Container
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
}