namespace ContainerProject;
public class Container
{
    private double mass;
    private double height;
    private double tareWeight;
    private double depth;
    private string sernum;
    private double maxPayload;
    private static int contNum = 1;
    public Container(double height, double tareWeight, double depth, double maxPayload)
    {
        this.height = height;
        this.TareWeight = tareWeight;
        this.tareWeight = tareWeight;
        this.depth = depth;
        this.mass = 0;
        this.maxPayload = maxPayload;
        this.sernum = GenerateSerialNumber();
    }
    public virtual void EmptyingCargo(double emptyweight)
    {
        if (Mass - emptyweight < 0)
        {
            Console.WriteLine("Not enough amount of cargo");
            mass -= emptyweight;
        }
    }
    public virtual void LoadingCargo(double weight)
    {
        if (weight <= maxPayload)
        {
            mass += weight;
        }
        else
            throw new OverfillException("No place");
    }
    public virtual string GetContainerInfo()
    {
        var info = "\n";
        info += $"Serial Number: {SerNum}\n";
        info += $"Height: {Height} cm\n";
        info += $"Tare Weight: {TareWeight} kg\n";
        info += $"Depth: {Depth} cm\n";
        info += $"Maximum Payload: {MaxPayload} kg\n";
        info += $"Current Cargo Mass: {Mass} kg\n";
        return info;
    }
    private string GenerateSerialNumber()
    {
        var typePrefix = GetType();
        var serialNumber = $"KON-{typePrefix}-{contNum}";
        contNum++;
        return serialNumber;
    }
    //Getters and setters
    public double Mass { get; set; }
    public double Height { get; set; }
    public double TareWeight { get; set; }
    public double Depth { get; set; }
    public string SerNum { get; set; }
    public double MaxPayload { get; set; }
    protected virtual string Type()
    {
        return "default"; // Default type prefix for Container
    }
}