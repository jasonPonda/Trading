using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Trading.Models
{
    public class UserModel
    {
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string email;
        public string password;

        public UserModel(int id, string email, string password)
        {
            this.Id = id;
            this.email = email;
            this.password = password;
        }
    }
}