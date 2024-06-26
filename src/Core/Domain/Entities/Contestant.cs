﻿using Domain.Primitives;
using System.ComponentModel.DataAnnotations;

namespace Domain.Entities
{
    public class Contestant : IAuditableEntity
    {
        [Key]
        public Guid ContestantId { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string FirstName { get; set; }

        //[Required]
        //[MaxLength(50)]
        //public string LastName { get; set; }

        [Required]
        [MaxLength(15)]
        public string Nickname { get; set; }

        [MaxLength(100)]
        public string? Email { get; set; }

        [Required]
        public bool IsAdmin { get; set; }

        [Required]
        public int Age { get; set; }

        public string? Image { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }
    }
}
