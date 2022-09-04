namespace AutoComplete.Models
{
    public class SearchResultModel
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<SearchItemModel> items { get; set; }

        public SearchResultModel() { 
            items = new List<SearchItemModel>();
            total_count = 0;
            incomplete_results = false;
        }
    }
}
