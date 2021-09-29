using System;
using System.IO;

namespace Email_extraction
{
    class Program
    {
        static void Main(string[] args)
        {
            /*
             Create our list of accepted domains
             // Create a Regex  
            string pattern = @"\b[M]\w+";
            String testString = "hey";
            Regex rg = new Regex(pattern);
            Match match = rg.Match(testString);
            
             */
            
            
            // Reading from a textfile
            string rawFile = File.ReadAllText("../../../sample.txt");
            string[] potentialEmails = rawFile.Split(" ");
            int counter = 0;
            foreach (var potentialEmail in potentialEmails)
            {
                int indexOfAt = potentialEmail.IndexOf("@");
                if (indexOfAt != -1)
                {
                    try
                    {
                        string potentialSubEmail = potentialEmail.Substring(indexOfAt, 13);
                        if (potentialSubEmail == "@softwire.com")
                        {
                            Console.WriteLine(potentialSubEmail);
                            counter++;
                        }
                    }
                    catch (Exception e)
                    {
                    }
                }
            }
            Console.WriteLine($"There are {counter} emails that contain '@softwire.com'");
        }
    }
}