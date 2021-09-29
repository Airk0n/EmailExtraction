using System;
using System.IO;
using System.Text.RegularExpressions;

namespace Email_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            string rawFile = File.ReadAllText("../../../sample.txt");
            string pattern = @"\S+@softwire.com";
            string pattern2 = @"\w+";
            Regex regex = new Regex(pattern);
            MatchCollection matchCollection = regex.Matches(rawFile);
            int counter = 0;
            Console.WriteLine(matchCollection.Count.ToString());
            foreach (Match match in matchCollection)
            {
                Console.WriteLine("match contents: " + match.Value);
                counter++;
            }
           

            Console.WriteLine($"There are {counter} emails that contain '@softwire.com'");
        }
    }
}