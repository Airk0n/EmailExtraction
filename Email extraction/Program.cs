using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace Email_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> toSort = CountDomains().OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
            foreach (var domain in toSort)
            {
                Console.WriteLine("key: " + domain.Key.ToString() + " value: "+ domain.Value);
            }

        }
        
        
        
        
        private static Dictionary<string, int> CountDomains()
        {
            /*
 Regex for email addresses
 Check domain
 If it exsists in dictionary add to counter
 sort by highest counter and print
 */
            Dictionary<String, int> dict = new Dictionary<string, int>();
            string rawFile = File.ReadAllText("../../../sample.txt");
            string wholeEmailPattern = @"(\w+[._-]?\w*){1,2}@(\w+).\w{2,3}([.]\w{2,3})?[ |\n]";
            Regex regex = new Regex(wholeEmailPattern);
            MatchCollection matchCollection = regex.Matches(rawFile);
            Console.WriteLine(matchCollection.First().Groups[2].Value);
            
            foreach (Match match in matchCollection)
            {
                string domain = match.Groups[2].Value;
                
                if (dict.ContainsKey(domain))
                {
                    dict[domain]++;
                    continue;
                }
                dict.Add(domain,1);
            }

            return dict;
        }
        


    }
}