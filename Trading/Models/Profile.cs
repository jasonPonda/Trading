namespace TradingApp.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public int User_id { get; set; }
        public string? Last_name { get; set; }
        public string? First_name { get; set; }
        public string? Address { get; set; }
    }
}