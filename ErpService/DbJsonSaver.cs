using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ErpService
{
    public class DbJsonSaver
    {

        public static void SaveData(string data, string fileName)
        {
            Directory.CreateDirectory(DirectoryPath);
            var filePath = FilePath(fileName);
            File.WriteAllText(filePath, data);
        }

        public static string GetData(string fileName)
        {
            var filePath = FilePath(fileName);
            if (!File.Exists(filePath))
                return "";
            var data = File.ReadAllText(filePath);
            return data;
        }

        private static string DirectoryPath
        {
            get
            {
                var dir = Environment.CurrentDirectory;
                var folder = @"LocalDb\";
                return Path.Combine(dir, folder);
            }
        }

        private static string FilePath(string fileName)
        {
            return Path.Combine(DirectoryPath, fileName);
        }
    }
}
