using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace _1._Even_Lines
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var reader = new StreamReader("../../../text.txt"))
            {
                StringBuilder sb = new StringBuilder();
                var count = 0; ;
                while (reader.EndOfStream==false)
                {
                    var line = reader.ReadLine();

                    if (count % 2 == 0)
                    {
                        // Console.WriteLine(line);
                        //line = line.Replace('-', '@');
                        //line = line.Replace(',', '@');
                        //line = line.Replace('.', '@');
                        //line = line.Replace('!', '@');
                        //line = line.Replace('?', '@');
                        var pattern = new Regex("[-,.?!]");
                        line= pattern.Replace(line, "@");
                        Stack<string> temp = new Stack<string>();
                        var token = line.Split();
                        foreach (var item in token)
                        {
                            temp.Push(item);
                        }
                        Console.WriteLine(string.Join(" ",temp));

                    }
                    count++;
                }
            }
        }
    }
}
