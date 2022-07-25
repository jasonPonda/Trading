namespace TradingApp.Models
{
    public class Trade
    {
        public int Id { get; set; }
        public int Profile_id { get; set; }
        public string? Symbol { get; set; }
        public int Quanity { get; set; }
        public int Open_price { get; set; }
        public int Close_price { get; set; }
        public DateTime Open_datetime { get; set; }
        public DateTime Close_datetime { get; set; }
        public bool Open { get; set; }
    }
}