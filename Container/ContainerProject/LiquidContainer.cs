namespace ContainerProject;

public class LiquidContainer : Container
{
    private bool isHazardous;
    private string cargo;
    public LiquidContainer(double height, double tareWeight, double depth, double maxPayload, bool isHazardous) :
        base(height, tareWeight, depth, maxPayload)
    {
        this.isHazardous = isHazardous;
    }
    public override string GetContainerInfo()
    {
        string info = base.GetContainerInfo(); // Call base class method to get common info
        // Add specific info for LiquidContainer
        info += $"Type: Liquid Container\n";
        info += $"Cargo Type: {(isHazardous ? "Hazardous" : "Ordinary")}\n";
        info += $"\n";
        return info;
    }
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in container {containerNumber}. Immediate action required.");
    }
    public override void loadingCargo(double weight)
    {
        double allowedCapacity = isHazardous ? getMaxPayload() * 0.5 : getMaxPayload() * 0.9;
        if (getMass() + weight> allowedCapacity)
        {
            NotifyHazard(getSerNum());
        }
        else setMass(getMass()+weight);
    }
    protected override string GetType()
    {
        return "L";
    }
}