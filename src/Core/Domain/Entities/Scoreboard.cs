using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Domain.Primitives;

namespace Domain.Entities
{
    public class Scoreboard : AggregateRoot, IAuditableEntity
    {
        public Scoreboard(int scoreboardId, int contestantId, int disciplineId, DateTime timeDisciplineStarted, DateTime timeDisciplineFinished, int dateDisciplinePlayed)
        {
            ScoreboardId = scoreboardId;
            ContestantId = contestantId;
            DisciplineId = disciplineId;
            TimeDisciplineStarted = timeDisciplineStarted;
            TimeDisciplineFinished = timeDisciplineFinished;
            DateDisciplinePlayed = dateDisciplinePlayed;
        }

        public Scoreboard()
        {
        }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ScoreboardId { get; set; }

        [Required]
        public int ContestantId { get; set; }

        [Required]
        public int DisciplineId { get; set; }

        [Required]
        public DateTime TimeDisciplineStarted { get; set; }

        [Required]
        public DateTime TimeDisciplineFinished { get; set; }

        [Required]
        // int DateDisciplinePlayed for better performance in data quering
        // format: yyyyMMdd 
        public int DateDisciplinePlayed { get; set; }

        public DateTime CreatedOnUtc { get; set; }
        public DateTime? ModifiedOnUtc { get; set; }
    }
}
