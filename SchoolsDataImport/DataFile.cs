using System.Collections.ObjectModel;

namespace SchoolsDataImport
{
    public class DataFileItem
    {
        public string Name { get; set; }

        public Collection<DataFileYearData> YearData { get; set; }
    }

    public class DataFileYearData
    {
        public int Year { get; set; }
    }
}