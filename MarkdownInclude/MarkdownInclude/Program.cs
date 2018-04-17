using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace MarkdownInclude
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Usage: MarkdownInclude [inputFile] [outputFile]");
                return;
            }

            string input;

            try
            {
                input = File.ReadAllText(args[0]);
            }
            catch (FileNotFoundException)
            {
                Console.WriteLine("The input file doesn't seem to exist. Perhaps you misspelled the name?");
                return;
            }

            var output = input;
            
            var occurences = Regex.Matches(input, @"!\[(I|i)nclude\]\(.*\)").Select(x => x.Value).ToList();
            if (occurences.Count > 0)
            {
                foreach (var occurence in occurences)
                {
                    var include = occurence.Split('(', ')');
                    try
                    {
                        output = output.Replace(occurence, File.ReadAllText(include[1]));
                    }
                    catch (FileNotFoundException)
                    {
                        Console.WriteLine($"The file {include[1]} doestn't exist!");
                        return;
                    }
                }
            }

            try
            {
                File.WriteAllText(args[1], output);
            }
            catch (Exception)
            {
                Console.WriteLine("Could not create new file. Something went wrong, it's probably your fault");
            }
        }
    }
}
