using System;
using System.IO;
using System.IO.Compression;

namespace _6._Zip_and_Extract
{
    class Program
    {
        static void Main(string[] args)
        {
            ZipFile.CreateFromDirectory("../../", "../../../created.zip");
            Directory.CreateDirectory("../../../extract");
            ZipFile.ExtractToDirectory("../../../created.zip", "../../../extract");
        }
    }
}
