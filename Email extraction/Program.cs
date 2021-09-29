using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;

namespace Email_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            PrintDictionary(CountDomains(fetchStringFromWeb()));

        }


        private static String fetchStringFromWeb()
        {
            WebClient webClient = new WebClient();
            Stream stream =
                webClient.OpenRead(
                    "https://raw.githubusercontent.com/techswitch-learners/email-extraction-csharp/master/EmailExtraction/Data/sample.txt");
            StreamReader reader = new StreamReader(stream);
            return reader.ReadToEnd();
        }

        private static Dictionary<string, int> CountDomains(string rawFile)
        {
            /*
 Regex for email addresses
 Check domain
 If it exsists in dictionary add to counter
 sort by highest counter and print
 */
            Dictionary<String, int> dict = new Dictionary<string, int>();
            // string rawFile = File.ReadAllText("../../../sample.txt");
            string wholeEmailPattern = @"(\w+[._-]?\w*){1,2}@(\w+).\w{2,3}([.]\w{2,3})?[ |\n]";
            Regex regex = new Regex(wholeEmailPattern);
            MatchCollection matchCollection = regex.Matches(rawFile);
            // Console.WriteLine(matchCollection.First().Groups[2].Value);

            foreach (Match match in matchCollection)
            {
                string domain = match.Groups[2].Value;

                if (dict.ContainsKey(domain))
                {
                    dict[domain]++;
                    continue;
                }

                dict.Add(domain, 1);
            }

            return dict.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
        }

        static void PrintDictionary(Dictionary<string, int> dict)
        {
            foreach (var domain in dict)
            {
                Console.WriteLine($"Domain: {domain.Key} - Value: {domain.Value.ToString()}");
            }
        }
    }
}