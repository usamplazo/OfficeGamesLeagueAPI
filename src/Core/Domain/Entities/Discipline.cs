using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Discipline
    {
        [Key]
        public int DisciplineId { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public float Points { get; set; }

        [Required]
        public int DailyLimit { get; set; }

        public string? Image { get; set; }
    }
}
