using System.IO;
using System.Xml.Serialization;

// ReSharper disable once CheckNamespace

namespace NuGet.Modules
{
    public static class XmlHelper
    {
        public static void Serialize<T>(string path, T obj)
        {
            var serializer = new XmlSerializer(typeof (T));
            var directory = Path.GetDirectoryName(path);
            if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            using (var file = File.Create(path))
            {
                serializer.Serialize(file, obj);
            }
        }

        public static T Deserialize<T>(string path)
        {
            var serializer = new XmlSerializer(typeof (T));
            using (var file = File.OpenRead(path))
            {
                return (T) serializer.Deserialize(file);
            }
        }
    }
}