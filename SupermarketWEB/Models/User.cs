using System.ComponentModel.DataAnnotations;

namespace Autenticacion.Model
{
    public class User
    {
        public int ID { get; set; } 

        [Required]
        [StringLength(50)]
        public string Username { get; set; } 

        [Required]
        public byte[] PasswordHash { get; set; } 
    }
}
