using System;
using System.Collections.Generic;
using System.IO;

namespace CurrencyConverterProjectDAL
{
    public class WriteMng
    {
        public static bool WriteToFile(List<string> charts)
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

                // Write the string List to a new file named "Charts.txt".
                TextWriter twWaitingToBeFetched;
                twWaitingToBeFetched = TextWriter.Synchronized(new StreamWriter(Path.Combine(docPath, "Charts.txt")));
                foreach (string line in charts)
                {
                    twWaitingToBeFetched.WriteLine(line);
                }

                twWaitingToBeFetched.Flush();

                return true;
            }

            catch (IOException e)
            {
                Console.WriteLine("The file could not be write:");
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public static bool WriteToDB(List<string> charts)
        {

            return false;
        }
    }
}
