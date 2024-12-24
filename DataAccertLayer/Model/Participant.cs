using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using DataAccessLayer.Model;



namespace DataAccessLayer.Model
{
    public class Participant
    {
        [Key] public int Id { get; set; }

        [Required]
        [MaxLength(160)]
        public string FullName { get; set; }

        [Required]
        [MaxLength(50)]
        public string Login { get; set; }

        [Required]
        [MaxLength (50)]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        public string Position { get; set; }

        public int Project { get; set; }
        
        [ForeignKey ("ProjectId") ]
        public int ProjectId { get; set; }
    }  
}
