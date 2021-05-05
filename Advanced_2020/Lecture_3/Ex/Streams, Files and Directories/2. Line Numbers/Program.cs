using System;
using System.IO;
using System.Linq;

namespace _2._Line_Numbers
{
    class Program
    {
        static void Main(string[] args)
        {
           var lines= File.ReadAllLines("../../../text.txt");
            var outputLines = new string[lines.Length];
            for (int i = 0; i < lines.Length; i++)
            {
                var temp = lines[i];
                int lettersCount = CountLetters(temp);
                int punctuationMarksCount = CountPunctuationMaks(temp);
                var newLine = $"Line {i + 1}: {temp} ({lettersCount})({punctuationMarksCount})";
                outputLines[i] = newLine;
            }

            File.WriteAllLines("../../../output.txt", outputLines);
            
        }

        public static int CountLetters(string text)
        {
            int count = 0;

            foreach (var item in text)
            {
                if (Char.IsLetter(item))
                {
                    count++;
                }
            }

            return count;
        }
        public static int CountPunctuationMaks(string text)
        {
            int count = 0;
            var marks = new char[] { '-', ',', '.', '!', '?','\'', };

            foreach (var item in text)
            {
                if (marks.Contains(item)) count++;
            }

            return count;
        }
    }
}
