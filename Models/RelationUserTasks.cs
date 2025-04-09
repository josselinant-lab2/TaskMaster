using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Models
{
    public class RelationUserTasks
    {
        [Key]
        public int Id_RelationUserTasks { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }
        
        [Required]
        public int Id_Task { get; set; }
        
        [Required]
        public int Id_User { get; set; }
        
        // Navigation properties
        [ForeignKey("Id_Task")]
        public Task Task { get; set; }
        
        [ForeignKey("Id_User")]
        public User User { get; set; }
    }
} 