namespace ContainerProject;
public class Container
{
    private double mass;
    private double height;
    private double tare_weight;
    private double depth;
    private String sernum;
    private Double maxPayload;

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
        return this.tare_weight;
    }

    public void setTareWeight(double tare_weight)
    {
        this.tare_weight = tare_weight;
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