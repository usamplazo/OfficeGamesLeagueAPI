using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace OfficeGamesLeague.Models
{
    public class Scoreboard
    {
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
    }
}
