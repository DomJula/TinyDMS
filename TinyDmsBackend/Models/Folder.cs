namespace TinyDmsBackend.Models
{
    public class Folder
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Path { get; set; } = string.Empty;
        public List<string> Documents { get; set; } = new List<string>();
    }
}