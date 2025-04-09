using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class Statut
    {
        [Key]
        public int Id_Statut { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        
        // Navigation property
        public ICollection<Task> Tasks { get; set; }
    }
} 