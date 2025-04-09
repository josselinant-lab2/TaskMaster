using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Models
{
    public class Task
    {
        [Key]
        public int Id_Task { get; set; }
        
        [Required]
        [StringLength(255)]
        public string Titre { get; set; }
        
        public DateTime? Echeance { get; set; }
        
        [StringLength(255)]
        public string Description { get; set; }
        
        public DateTime DateCreation { get; set; }
        
        [Required]
        public int Id_Categorie { get; set; }
        
        [Required]
        public int Id_Priorite { get; set; }
        
        [Required]
        public int Id_Statut { get; set; }
        
        // Navigation properties
        [ForeignKey("Id_Categorie")]
        public Categorie Categorie { get; set; }
        
        [ForeignKey("Id_Priorite")]
        public Priorite Priorite { get; set; }
        
        [ForeignKey("Id_Statut")]
        public Statut Statut { get; set; }
        
        public ICollection<SubTask> SubTasks { get; set; }
        public ICollection<RelationUserTasks> RelationUserTasks { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
        public ICollection<Assimiler> Assimilations { get; set; }
    }
} 