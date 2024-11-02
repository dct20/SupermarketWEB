using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SupermarketWEB.Models
{
    public class PayMode
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? Observation { get; set; }
    }
}
