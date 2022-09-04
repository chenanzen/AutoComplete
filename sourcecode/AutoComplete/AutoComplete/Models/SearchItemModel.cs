namespace AutoComplete.Models
{
    public class SearchItemModel
    {
        public string name { get; set; }
        public string display_name { get; set; }
        public string description { get; set; }
        public string created_by { get; set; }
        public string released { get; set; }
        public DateTime created_at { get; set; }
        public DateTime updated_at { get; set; }
        public bool featured { get; set; }
        public bool curated { get; set; }
        public double score { get; set; }
    }
}
