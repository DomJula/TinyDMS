using Microsoft.AspNetCore.Mvc;
using TinyDmsBackend.Models;
using TinyDmsBackend.Repositories;

namespace DmsBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContractsController : ControllerBase
    {
        private readonly Repository _repository;

        public ContractsController()
        {
            _repository = new Repository();
        }

        // GET: api/contracts
        [HttpGet]
        public ActionResult<IEnumerable<Contract>> GetContracts()
        {
            var contracts = _repository.GetContracts();
            return Ok(contracts);
        }

        // GET: api/contracts/{id}/folder
        [HttpGet("{id}/folder")]
        public ActionResult<List<string>> GetDocumentsInFolder(int id)
        {
            var documents = _repository.GetDocumentsInFolder(id);
            if (documents == null || !documents.Any())
            {
                return NotFound("Keine Dokumente im Ordner gefunden.");
            }
            return Ok(documents);
        }

        // POST: api/contracts
        [HttpPost]
        public ActionResult<Contract> PostContract([FromBody] Contract contract)
        {
            if (contract == null)
            {
                return BadRequest();
            }

            var newContract = _repository.AddContract(contract);
            return CreatedAtAction(nameof(GetContracts), new { id = newContract.Id }, newContract);
        }
    }
}
