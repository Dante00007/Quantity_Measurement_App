using System.ComponentModel.DataAnnotations;

namespace QuantityMeasurementAppModelLayer.Entity
{
    public class QuantityMeasurementHistoryEntity
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public double InputValue1 { get; set; }
        [Required]
        public string? InputUnit1 { get; set; }

        public double? InputValue2 { get; set; }

        public string? InputUnit2 { get; set; }
        [Required]
        public string? TargetUnit { get; set; }
        [Required]
        public string? Operation { get; set; }
        public double ResultValue { get; set; }

        public string? ResultUnit { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }
}