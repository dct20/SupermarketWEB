using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Autenticacion.Model
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        public byte[] Password { get; set; }

        [NotMapped]
        public string PasswordInput { get; set; } 
    }
}
