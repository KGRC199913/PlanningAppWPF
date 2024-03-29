﻿using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace PlanningApp
{
    public static class ExtensionMethods
    {
        // Deep clone
        public static T DeepClone<T>(this T a)
        {
            using (var stream = new MemoryStream())
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(stream, a);
                stream.Position = 0;
                return (T) formatter.Deserialize(stream);
            }
        }
    }
}