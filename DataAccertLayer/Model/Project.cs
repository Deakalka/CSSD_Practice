using DataAccessLayer.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.Model
{
    public class Project
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty; // Ініціалізуємо як порожній рядок

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public ICollection<Participant> Participants { get; set; } = new List<Participant>(); // Ініціалізуємо як порожній список
    }
}