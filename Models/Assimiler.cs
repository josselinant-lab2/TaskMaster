using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TaskMaster.Models
{
    public class Assimiler
    {
        [Key]
        [Column(Order = 0)]
        public int Id_Task { get; set; }
        
        [Key]
        [Column(Order = 1)]
        public int Id_Etiquette { get; set; }
        
        // Navigation properties
        [ForeignKey("Id_Task")]
        public Task Task { get; set; }
        
        [ForeignKey("Id_Etiquette")]
        public Etiquette Etiquette { get; set; }
    }
} 