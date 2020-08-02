using System;

namespace _01._Nikulden_s_Charity
{
    class Program
    {
        static void Main(string[] args)
        {
            string codedWord = Console.ReadLine();
            while (true)
            {
                string input = Console.ReadLine();
                if (input.Equals("Finish"))
                {
                    break;
                }
                string[] tokens = input.Split(' ','\t', StringSplitOptions.RemoveEmptyEntries);
                string command = tokens[0];
                if (command.Equals("Replace"))
                {
                    char currentChar = Convert.ToChar(tokens[1]);
                    char newChar = Convert.ToChar(tokens[2]);
                    codedWord= codedWord.Replace(currentChar, newChar);
                    Console.WriteLine(codedWord);
                    continue;
                }
                if (command.Equals("Cut"))
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if(startIndex>0 && endIndex < codedWord.Length)
                    {
                        int lenght = endIndex - startIndex;
                        
                        codedWord= codedWord.Remove(startIndex, lenght+1);
                        Console.WriteLine(codedWord);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    continue;
                }
                if (command.Equals("Make"))
                {
                    string type = tokens[1];
                    if (type.Equals("Upper"))
                    {
                        codedWord= codedWord.ToUpper();
                        Console.WriteLine(codedWord);
                    }
                    else
                    {
                        codedWord = codedWord.ToLower();
                        Console.WriteLine(codedWord);
                    }
                    continue;
                }
                if (command.Equals("Check"))
                {
                    string subString = tokens[1];
                    if (codedWord.Contains(subString))
                    {
                        Console.WriteLine($"Message contains {subString}");
                    }
                    else
                    {
                        Console.WriteLine($"Message doesn't contain {subString}");
                    }
                    continue;
                }
                if (command.Equals("Sum"))
                {
                    int startIndex = int.Parse(tokens[1]);
                    int endIndex = int.Parse(tokens[2]);
                    if (startIndex > 0 && endIndex < codedWord.Length)
                    {
                        int sum = 0;
                        for (int i = startIndex; i <= endIndex; i++)
                        {
                            char current = codedWord[i];
                            sum += (int)current;
                        }
                        Console.WriteLine(sum);
                    }
                    else
                    {
                        Console.WriteLine("Invalid indexes!");
                    }
                    continue;
                }

            }
        }
    }
}
