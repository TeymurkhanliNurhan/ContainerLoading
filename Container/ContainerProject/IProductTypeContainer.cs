namespace ContainerProject;

public interface IProductTypeContainer
{
    bool CanLoadProductType(string productType);
    string TypeName { get; } // Add this if you need outside access
}
