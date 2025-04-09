using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Models
{
    public class Etiquette
    {
        [Key]
        public int Id_Etiquette { get; set; }
        
        [Required]
        [StringLength(50)]
        public string Libelle { get; set; }
        
        [Required]
        public int Id_User { get; set; }
        
        // Navigation properties
        [ForeignKey("Id_User")]
        public User User { get; set; }
        
        public ICollection<Assimiler> Assimilations { get; set; }
    }
} 