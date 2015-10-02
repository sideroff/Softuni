using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _03.WordCount
{
    class WordCount
    {
        static void Main(string[] args)
        {
            StreamReader reader = new StreamReader("../../words.txt");
            List<string> words = new List<string>();
            List<string> wordsFromText = new List<string>();

            using (reader)                                  //read words from file 1
            {                
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineSplit = line.Split();
                    foreach(string word in lineSplit)
                    {
                        if (!words.Contains(word))
                        {
                            words.Add(word);
                        }
                    }
                    line = reader.ReadLine();
                }
            }
            reader = new StreamReader("../../text.txt");
            using (reader)                                                      //read words from file 2
            {
                string line = reader.ReadLine();
                while (line != null)
                {
                    string[] lineSplit = line.Split();
                    foreach (string word in lineSplit)
                    {
                        wordsFromText.Add(word);
                    }
                    line = reader.ReadLine();
                }
            }
            foreach(string word in words)                                       //compare
            {
                int counter = 0;
                foreach(string element in wordsFromText)
                {
                    if (word == element) counter++;
                }
                if (counter != 0) Console.WriteLine("The word {0} appears {1} times in the text.",word,counter);
            }
        }
    }
}
