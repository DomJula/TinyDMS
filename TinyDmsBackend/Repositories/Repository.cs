using TinyDmsBackend.Models;

namespace TinyDmsBackend.Repositories
{
    public class Repository
    {
        private static List<Contract> _contracts = new List<Contract>
        {
            new Contract { Id = 1, Name = "Vertrag A", DateCreated = DateTime.Now, FolderPath = "/path/to/folderA" },
            new Contract { Id = 2, Name = "Vertrag B", DateCreated = DateTime.Now, FolderPath = "/path/to/folderB" }
        };

        private static List<Folder> _folders = new List<Folder>
        {
            new Folder { Id = 1, Name = "Ordner A", Path = "/path/to/folderA", Documents = new List<string> { "Dokument 1", "Dokument 2" } },
            new Folder { Id = 2, Name = "Ordner B", Path = "/path/to/folderB", Documents = new List<string> { "Dokument 3", "Dokument 4" } }
        };

        // Gibt eine Liste aller Verträge zurück
        public List<Contract> GetContracts() => _contracts;

        // Gibt eine Liste der Dokumente in einem bestimmten Ordner zurück
        public List<string> GetDocumentsInFolder(int folderId) => _folders.FirstOrDefault(f => f.Id == folderId)?.Documents ?? new List<string>();

        // Fügt einen neuen Vertrag hinzu
        public Contract AddContract(Contract contract)
        {
            contract.Id = _contracts.Max(c => c.Id) + 1;
            _contracts.Add(contract);
            return contract;
        }
    }
}
