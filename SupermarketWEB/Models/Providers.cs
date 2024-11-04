using System;
using System.ComponentModel.DataAnnotations;

namespace SupermarketWEB.Models
{
    public class Provider
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(15)]
        public string document_number { get; set; }

        [Required]
        [StringLength(80)]
        public string company_name { get; set; }

        [StringLength(50)]
        public string contact_name { get; set; }

        [StringLength(80)]
        public string address { get; set; }

        [StringLength(16)]
        public string phone_number { get; set; }

        [StringLength(100)]
        public string email { get; set; }
    }
}
