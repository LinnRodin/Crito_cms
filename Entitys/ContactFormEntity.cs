using System.ComponentModel.DataAnnotations;
using Umbraco.Cms.Core.Models;

namespace Crito.Entitys
{
    public class ContactFormEntity
    {

        
        [Key]
        public Guid Id { get; set; }

        public string Name { get; set; } = null!;
        
        public string Email { get; set; } = null!;
       
        public string Message { get; set; } = null!;

        public string? RedirectUrl { get; set; } = "/home";
    }
}
