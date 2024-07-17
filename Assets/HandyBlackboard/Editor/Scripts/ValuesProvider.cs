// using System;
// using System.Collections.Generic;
// using System.Linq;
// using UnityEngine;

// namespace IndieGabo.HandyBlackboard.Editor
// {
//     public class ValuesProvider
//     {
//         private Dictionary<string, Type> _types = new();
//         private List<string> _typeNames = new();

//         public List<string> TypeNames => _typeNames;

//         public ValuesProvider()
//         {
//             Type baseType = typeof(BlackboardEntryValueBase);

//             // Get all the classes that derive from the base type and are not abstract
//             IEnumerable<Type> childrenTypes = baseType.Assembly.GetTypes()
//                 .Where(
//                     t => t.IsClass
//                     && baseType.IsAssignableFrom(t)
//                     && !t.IsAbstract
//                     && t != baseType
//                 );

//             foreach (var type in childrenTypes)
//             {
//                 var instance = Activator.CreateInstance(type);
//                 var nameProperty = instance.GetType().GetProperty("ValueTypeDisplayName");
//                 if (nameProperty != null)
//                 {
//                     string name = (string)nameProperty.GetValue(instance);
//                     _types.Add(name, type);
//                 }
//             }

//             _typeNames = _types.Keys.ToList();
//         }

//         public bool TryCreatingValue<T>(string name, out T value)
//         {
//             Type entryType = _types[name];
//             value = (T)Activator.CreateInstance(entryType);
//             return true;
//         }
//     }
// }