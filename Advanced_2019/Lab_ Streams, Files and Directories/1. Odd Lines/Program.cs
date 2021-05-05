using System;
using System.IO;

namespace _1._Odd_Lines
{
    class Program
    {
        static void Main(string[] args)
        {

            using (StreamReader reader = new StreamReader("fileToOpen.txt"))
            {
                using (StreamWriter sw = new StreamWriter("../../../output.txt"))
                {
                    int count = 1;
                    while (reader.EndOfStream == false)
                    {

                        var line = reader.ReadLine();
                        if (count % 2 == 0)
                        {
                            sw.WriteLine(line);
                        }

                        count++;
                    }
                }
            }
        }
    }
}
