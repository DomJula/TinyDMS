using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TinyDmsBackend.Models
{
    public class Doc_File
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FileName { get; set; } = string.Empty;

        [MaxLength(50)]
        public string? FileType { get; set; }

        [Required]
        [MaxLength(255)]
        public string FilePath { get; set; } = string.Empty;

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime Timestamp { get; set; } = DateTime.Now;

        public string? Description { get; set; }

        public string? Labels { get; set; }

        // Umgekehrte Beziehung zu DocContract (0..1)
        public Doc_Contract? Contract { get; set; }
    }
}
