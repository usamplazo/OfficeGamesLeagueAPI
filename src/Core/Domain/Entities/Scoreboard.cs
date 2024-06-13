using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Scoreboard : AggregateRoot, IAuditableEntity
    {
        public Scoreboard(Guid scoreboardId, Guid contestantId, Guid disciplineId,int dateDisciplinePlayed, DateTime createdOnUtc, DateTime? modifiedOnUtc)
        {
            ScoreboardId = scoreboardId;
            ContestantId = contestantId;
            DisciplineId = disciplineId;
            DateDisciplinePlayed = dateDisciplinePlayed;
            CreatedOnUtc = createdOnUtc;
            ModifiedOnUtc = modifiedOnUtc;
        }

        public Scoreboard()
        {
        }

        [Key]
        public Guid ScoreboardId { get; set; }

        [Required]
        public Guid ContestantId { get; set; }

        [Required]
        public Guid DisciplineId { get; set; }

        [Required]
        // for better performance in data quering
        // format: yyyyMMdd
        public int DateDisciplinePlayed { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? ModifiedOnUtc { get; set; }
    }
}
