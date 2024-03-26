namespace ContainerProject;
public class GasContainer : Container, IHazardNotifier
{
    private double pressure;
    public GasContainer(double height, double tareWeight, double depth, double maxPayload,double pressure) :
        base(height, tareWeight, depth, maxPayload)
    {
        this.pressure = pressure;
    }
    public override string GetContainerInfo()
    {
        string info = base.GetContainerInfo(); // Call base class method to get common info
        // Add specific info for LiquidContainer
        info += $"Type: Gas Container\n";
        info += $"Pressure: {pressure} atm\n";
        info += $"\n";

        // Add any other specific information for LiquidContainer
        return info;
    }
    public void NotifyHazard(string containerNumber)
    {
        Console.WriteLine($"Hazardous situation detected in container {containerNumber}. Immediate action required.");
    }
    public override void EmptyingCargo(double emptyweight)
    {
        double minLevel = 0.05 * MaxPayload;
        if (Mass - emptyweight < minLevel) NotifyHazard(SerNum);
        else Mass=Mass-emptyweight;
    }
    protected string GetType()
    {
        return "G";
    }
}