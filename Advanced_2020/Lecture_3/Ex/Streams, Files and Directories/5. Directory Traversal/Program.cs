using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _5._Directory_Traversal
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> fileInfo = new Dictionary<string, Dictionary<string, long>>();
            DirectoryInfo directoryInfo = new DirectoryInfo("../../../");
            var files= directoryInfo.GetFiles();
            foreach (var item in files)
            {
                string name = item.Name;
                string extention = item.Extension;
                var size = item.Length/1024;
                if (fileInfo.ContainsKey(extention) == false)
                {
                    fileInfo.Add(extention, new Dictionary<string, long>());
                }
                fileInfo[extention].Add(name, size);
            }
            using (StreamWriter writer =
                new StreamWriter($"{Environment.GetFolderPath(Environment.SpecialFolder.Desktop)}\\report.txt"))
            {
                foreach (var item in fileInfo.OrderByDescending(c => c.Value.Count).ThenBy(n => n.Key))
                {
                    writer.WriteLine(item.Key);
                    foreach (var file in item.Value.OrderBy(s=>s.Value))
                    {
                        writer.WriteLine($"--{file.Key} - {file.Value}kb");
                    }
                }
            }

        }
    }
}
