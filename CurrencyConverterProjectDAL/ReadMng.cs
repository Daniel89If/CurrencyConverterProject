using System;
using System.IO;

namespace CurrencyConverterProjectDAL
{
    public class ReadMng
    {
        public bool ReadFromFile()
        {
            try
            {
                string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                // Open the text file using a stream reader.
                using (FileStream fileStream = new FileStream(docPath + "\\Charts.txt", FileMode.OpenOrCreate, FileAccess.Read, FileShare.ReadWrite))
                {
                    using (var streamReader = new StreamReader(fileStream))
                    {
                        // Read the stream as a string, and write the string to the console.
                        Console.WriteLine(streamReader.ReadToEnd());
                    }
                }

                return true;
            }
            catch (IOException e)
            {
                Console.WriteLine("The file could not be read:");
                Console.WriteLine(e.Message);

                return false;
            }
        }

        public bool ReadFromDB()
        {

            return false;
        }
    }
}
