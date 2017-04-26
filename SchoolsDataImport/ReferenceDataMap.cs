using CsvHelper.Configuration;

namespace SchoolsDataImport
{
    public sealed class ReferenceDataMap : CsvClassMap<ReferenceData>
    {
        public ReferenceDataMap()
        {
            Map(m => m.ReferenceNumber).Name("De ref");
            Map(m => m.Constituency).Name("constituency");
            Map(m => m.Council).Name("council");
            Map(m => m.ManagementType).Name("management type");
            Map(m => m.Postcode).Name("postcode");
            Map(m => m.RuralUrban).Name("rural");
            Map(m => m.SchoolName).Name("school name");
            Map(m => m.SchoolType).Name("school type");
            Map(m => m.Town).Name("town");
            Map(m => m.Address).Name("address 1");
        }
    }
}