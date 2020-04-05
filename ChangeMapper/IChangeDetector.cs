namespace ChangeMapper
{
    public interface IChangeDetector
    {
        bool HasChanges<T, U>(T sourceObject, U destinationObject, IPropertyMapper propertyMapper);
    }
}