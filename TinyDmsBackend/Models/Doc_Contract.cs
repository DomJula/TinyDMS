using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyDmsBackend.Models
{
    public class Doc_Contract
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FileId { get; set; }

        [Required]
        [MaxLength(50)]
        public string ContractNumber { get; set; } = string.Empty;

        [Required]
        [MaxLength(255)]
        public string Title { get; set; } = string.Empty;

        [Required]
        public DateTime StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        [MaxLength(20)]
        public string Status { get; set; } = "active";

        // Beziehung zu DocFile (0..1)
        [ForeignKey(nameof(FileId))]
        public Doc_File? File { get; set; } // Nullable für optionale Beziehung
    }
}
