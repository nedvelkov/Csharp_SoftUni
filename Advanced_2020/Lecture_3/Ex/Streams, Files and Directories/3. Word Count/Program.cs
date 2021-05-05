using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace _3._Word_Count
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> kvp = new Dictionary<string, int>();
            List<string> words = new List<string>();
            using (StreamReader reader = new StreamReader("../../../words.txt"))
            {
                using (StreamReader readerText = new StreamReader("../../../text.txt"))
                {
                    using (StreamWriter writerActual = new StreamWriter("../../../actualResults.txt"))
                    {
                        using (StreamWriter writerExpexted = new StreamWriter("../../../expectedResult.txt"))
                        {
                            while (reader.EndOfStream == false)
                            {
                                var word = reader.ReadLine().ToLower();
                                if (kvp.ContainsKey(word) == false)
                                {
                                    kvp.Add(word, 0);
                                    words.Add(word);
                                }
                            }
                            while (readerText.EndOfStream == false)
                            {
                                var line = readerText.ReadLine().Split(new char[] { '-', ',', '.', '!', '?' ,' '});
                                foreach (var word in line)
                                {
                                    foreach (var item in words)
                                    {
                                        var current = word.ToLower();
                                        var looking = item.ToLower();
                                        if (looking.Equals(current))
                                        {
                                            kvp[item]++;
                                        }
                                    }
                                }                              
                            }
                            foreach (var item in kvp)
                            {
                                writerActual.WriteLine($"{item.Key}-{item.Value}");
                            }
                            foreach (var item in kvp.OrderByDescending(v=>v.Value))
                            {
                                writerExpexted.WriteLine($"{item.Key}-{item.Value}");
                            }

                        }
                    }
                }
            }
        }
    }
}
