namespace Stock.Companies.Domain.Entities
{
    public class Company : Entity
    {
        public string Name { get; set; }

        public string Exchange { get; set; }

        public string Ticker { get; set; }

        public string ISIN { get; set; }

        public string WebSite { get; set; }
    }
}