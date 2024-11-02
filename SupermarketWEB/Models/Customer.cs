using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string document_number { get; set; }

        [Required]
        [StringLength(50)]
        public string first_name { get; set; }

        [Required]
        [StringLength(50)]
        public string last_name { get; set; }

        [StringLength(80)]
        public string address { get; set; }

        public DateTime? birthday { get; set; }

        [StringLength(16)]
        public string phone_number { get; set; }

        [StringLength(100)]
        public string email { get; set; }
    }
}
