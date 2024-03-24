namespace ContainerProject;

public class Ship
{
    private List<Container> containers;
    private double maxSpeed;
    private int conNumber;
    private double maxWeight;
    private static int contNum=1;
    private string sernum;

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
}