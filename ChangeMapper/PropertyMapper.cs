using System;
using System.Collections.Generic;

namespace ChangeMapper
{
    public class PropertyMapper : IPropertyMapper
    {
        Dictionary<string, string> _propertyMapping = new Dictionary<string, string>();

        public string GetMappedProperty(string sourcePropertyName)
        {
            if (_propertyMapping.ContainsKey(sourcePropertyName)) return _propertyMapping[sourcePropertyName];
            return string.Empty;
        }

        public void MapProperty(string sourcePropertyName, string destinationPropertyName)
        {
            if (!_propertyMapping.ContainsKey(sourcePropertyName))
            {
                _propertyMapping.Add(sourcePropertyName, destinationPropertyName);
            }
        }
    }

    public interface IPropertyMapper
    {
        void MapProperty(string sourcePropertyName, string destinationPropertyName);

        string GetMappedProperty(string sourcePropertyName);
    }
}
