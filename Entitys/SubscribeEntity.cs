using System.ComponentModel.DataAnnotations;

namespace Crito.Entitys
{
    public class SubscribeEntity
    {
        [Key]
        public string Email { get; set; } = null!;
    }
}
