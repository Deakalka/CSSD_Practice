using DataAccessLayer.Model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DataAccessLayer.Model
{
    public class Participant
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty; // Ініціалізуємо як порожній рядок

        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = string.Empty; // Ініціалізуємо як порожній рядок

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty; // Ініціалізуємо як порожній рядок

        [Required]
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty; // Ініціалізуємо як порожній рядок

        // Foreign Key
        public int ProjectId { get; set; }

        // Navigation property
        [ForeignKey("ProjectId")]
        public Project? Project { get; set; } // Дозволяємо null
    }
}