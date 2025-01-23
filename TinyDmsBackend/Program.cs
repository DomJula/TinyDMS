using Microsoft.EntityFrameworkCore;
using TinyDmsBackend.Models;

using var dbContext = new AppDbContext();

// Datenbank erstellen
//dbContext.Database.EnsureDeleted(); // Löscht die Datenbank, wenn sie existiert (nur zu Testzwecken!)
//dbContext.Database.EnsureCreated();

// Testdaten einfügen
var file = new Doc_File
{
    FileName = "Vertrag1.pdf",
    FileType = "pdf",
    FilePath = "/files/Vertrag1.pdf",
    Description = "Dies ist ein Beispielvertrag",
    Labels = "vertrag, pdf, test"
};

var contract = new Doc_Contract
{
    File = file,
    ContractNumber = "CN12345",
    Title = "Mustervertrag",
    StartDate = DateTime.Now,
    EndDate = DateTime.Now.AddYears(1)
};

//dbContext.Contracts.Add(contract);
//dbContext.SaveChanges();

// Daten auslesen
var contractsWithFiles = dbContext.Contracts
    .Include(c => c.File)
    .ToList();

foreach (var c in contractsWithFiles)
{
    Console.WriteLine($"Vertrag: {c.Title}, Nummer: {c.ContractNumber}, Datei: {c.File?.FileName}");
}

foreach (var f in dbContext.Files)
    System.Console.WriteLine($"File: {f.FileName}, Description: {f.Description}");
;