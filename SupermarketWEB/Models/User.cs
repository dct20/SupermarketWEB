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
        public byte[] Password { get; set; }

       
        [Required(ErrorMessage = "La contraseña es obligatoria.")]
        [DataType(DataType.Password)]
        public string PasswordInput { get; set; }
    }
}
