namespace Trading.Models
{
    public class UserModel
    {
        public int id;
        public string email;
        public string password;

        public UserModel(int Id, string Email, string Password)
        {
            id = Id;
            email = Email;
            password = Password;
        }

        public int Id
        {
            get { return id; }
        }

        public string Email
        {
            get { return email; }
        }

        public string Password
        {
            get { return password; }
        }
    }
}