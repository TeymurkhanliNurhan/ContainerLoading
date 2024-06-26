using System.Diagnostics;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;

namespace ContainerProject;

public class RefrigeratedContainer : Container, IProductTypeContainer

{
    public string TypeName { get; private set; }
    private double temperature;
    private string type;
    
    public RefrigeratedContainer(double height, double tareWeight, double depth, double maxPayload) :
        base(height, tareWeight, depth, maxPayload)
    {
        //this.TypeName = typeProduct;
       /* switch (this.TypeName)
        {
            case "Bananas": temperature = 13.3;
                break;
            case "Chocolate": temperature =18 ;
                break;
            case "Fish": temperature =2 ;
                break;
            case "Meat": temperature =-15 ;
                break;
            case "Ice cream": temperature =-18 ;
                break;
            case "Frozen pizza": temperature =-30 ;
                break;
            case "Cheese": temperature =7.2 ;
                break;
            case "Sausages": temperature =5 ;
                break;
            case "Butter": temperature =20.5 ;
                break;
            case "Eggs": temperature =19 ;
                break;
            default: Console.WriteLine("Not a correct type");
                break;
        }*/
    }
    public override string GetContainerInfo()
    {
        string info = base.GetContainerInfo();
        info += $"Type: Refrigerated Container\n";
        info += $"Load type: {getType()}\n";
        return info;
    }
    public bool CanLoadProductType(string productType)
    {
        return productType.Equals(TypeName, StringComparison.OrdinalIgnoreCase);
    }
    protected override string GetType()
    {
        return "C";
    }
 
}