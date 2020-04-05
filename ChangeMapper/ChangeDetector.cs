using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;

namespace ChangeMapper
{
    public class ChangeDetector : IChangeDetector
    {
        public bool HasChanges<T, U>(T sourceObject, U destinationObject, IPropertyMapper propertyMapper)
        {
            var sourcePropInfo = sourceObject.GetType().GetProperties();
            var destinationTypeInfo = destinationObject.GetType();

            foreach (var prop in sourcePropInfo)
            {
               var destinationPropName = propertyMapper.GetMappedProperty(prop.Name);
                if (string.IsNullOrWhiteSpace(destinationPropName)) continue;

                var destProp = destinationTypeInfo.GetProperty(destinationPropName);

                if (destProp.GetValue(destinationObject).ToString() != prop.GetValue(sourceObject).ToString())
                    return true;
            }

            return false;
        }
    }
}
