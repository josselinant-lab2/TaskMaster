using System.ComponentModel.DataAnnotations;

namespace TaskMaster.Models
{
    public class Priorite
    {
        [Key]
        public int Id_Priorite { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Code { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }
        
        // Navigation property
        public ICollection<Task> Tasks { get; set; }
    }
} 