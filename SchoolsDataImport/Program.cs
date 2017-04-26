using System;
using System.IO;
using CsvHelper;
using Newtonsoft;
using System.Collections.ObjectModel;

namespace SchoolsDataImport
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            string dataDirectory = Path.Combine(currentDirectory, "Data");
            string dataFile = Path.Combine(dataDirectory, "data.json");

            if (!Directory.Exists(dataDirectory))
            {
                Console.WriteLine("Data directory does not exist.");
            }

            // Now check if any data files exist there.
            if (!File.Exists(dataFile))
            {
                Console.WriteLine("Data file does not exist.");
            }

            string dataFileContents = File.ReadAllText(dataFile);

            Collection<DataFileItem> file = Newtonsoft.Json.JsonConvert.DeserializeObject<Collection<DataFileItem>>(dataFileContents);

            foreach (var f in file)
            {
                string dataItemDir = Path.Combine(dataDirectory, f.Name);
                Console.WriteLine(dataItemDir);

                foreach (var y in f.YearData)
                {
                    string yearDataItemDir = Path.Combine(dataItemDir, y.Year.ToString());
                    Console.WriteLine(yearDataItemDir);

                    using (StreamReader sr = new StreamReader(File.OpenRead(Path.Combine(yearDataItemDir, "reference.csv"))))
                    {
                        sr.BaseStream.Seek(0, SeekOrigin.Begin);
                        var csv = new CsvReader(sr);

                        csv.Configuration.RegisterClassMap<ReferenceDataMap>();

                        var refData = csv.GetRecords<ReferenceData>();

                        foreach (var r in refData)
                        {
                            Console.WriteLine($"{r.SchoolName} - {r.ReferenceNumber}");
                        }
                    }
                }
            }

            Console.ReadLine();
        }
    }
}
