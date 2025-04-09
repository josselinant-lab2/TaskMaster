using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Models
{
    public class SubTask
    {
        [Key]
        public int Id_SubTasks { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Titre { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Statut { get; set; }
        
        public DateTime? Echeance { get; set; }
        
        [Required]
        public int Id_Task { get; set; }
        
        // Navigation property
        [ForeignKey("Id_Task")]
        public Task Task { get; set; }
    }
} 