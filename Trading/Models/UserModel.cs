using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Trading.Models
{
    public class UserModel
    {
        [Key]
        [Required]
        public int id;
        public string email;
        public string password;

        public UserModel(int id, string email, string password)
        {
            this.id = id;
            this.email = email;
            this.password = password;
        }
    }
}