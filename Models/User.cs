using System;
using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class User
    {
        [Key]
        public int Id_User { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Pseudo { get; set; }
        
        public DateTime DateCreation { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Email { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Password { get; set; }
        
        // Navigation properties
        public ICollection<Categorie> Categories { get; set; }
        public ICollection<Etiquette> Etiquettes { get; set; }
        public ICollection<RelationUserTasks> RelationUserTasks { get; set; }
        public ICollection<Commentaire> Commentaires { get; set; }
    }
} 