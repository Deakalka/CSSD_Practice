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
        public string FullName { get; set; } = string.Empty; 

        [Required]
        [MaxLength(50)]
        public string Login { get; set; } = string.Empty; 

        [Required]
        [MaxLength(50)]
        public string Password { get; set; } = string.Empty; 

        [Required]
        [MaxLength(50)]
        public string Position { get; set; } = string.Empty;

        public int ProjectId { get; set; }

        [ForeignKey("ProjectId")]
        public Project? Project { get; set; } 
    }
}