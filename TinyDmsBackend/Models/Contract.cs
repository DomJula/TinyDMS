namespace TinyDmsBackend.Models
{
    public class Contract
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime DateCreated { get; set; }
        public string FolderPath { get; set; } = string.Empty;
    }
}