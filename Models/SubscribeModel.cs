using System.ComponentModel.DataAnnotations;

namespace Crito.Models
{
    public class SubscribeModel
    {
        [Required]
        public string Email { get; set; } = null!;
    }
}
