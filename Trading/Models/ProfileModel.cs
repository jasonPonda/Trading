namespace Trading.Models
{
    public class ProfileModel 
    {
        public  int Id;
        public  int User_id;
        public string Last_name;
        public string First_name;
        public string Address;

        public ProfileModel(int id, int user_id,
            string last_name, string first_name, string address)
            
        {
            this.Id = id;
            User_id = user_id;
            Last_name = last_name;
            First_name = first_name;
            Address = address;
        }

        
    }
}