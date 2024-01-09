using System.ComponentModel.DataAnnotations;

namespace HermesStream.Notification.Service.Entities
{
    public class User
    {
        [Key]
        public required string ClientId { get; set; }
        public string? Name { get; set; }
        public string? Telephone { get; set; }
        public string? Email { get; set; }
    }
}
