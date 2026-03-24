using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurementAppModelLayer.Entity
{
    public class UserEntity
    {
        
        public int Id { get; set; }
        public string FullName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}