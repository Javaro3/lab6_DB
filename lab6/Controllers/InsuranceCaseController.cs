using lab6.Data;
using lab6.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace lab6.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class InsuranceCaseController : ControllerBase {
        private readonly InsuranceCompanyContext _context;

        public InsuranceCaseController(InsuranceCompanyContext context) {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<InsuranceCase> Get() {
            var data = _context.InsuranceCases
                .Include(e => e.SupportingDocument)
                .Include(e => e.Client)
                .ToList();
            return data;
        }
        
        [HttpGet("{id}")]
        public IActionResult Get(int id) {
            InsuranceCase insuranceCase = _context.InsuranceCases.FirstOrDefault(e => e.Id == id);
            if (insuranceCase == null)
                return NotFound();

            return new ObjectResult(insuranceCase);
        }

        [HttpPost]
        public IActionResult Post([FromBody] InsuranceCase insuranceCase) {
            if (insuranceCase == null) {
                return BadRequest();
            }

            _context.InsuranceCases.Add(insuranceCase);
            _context.SaveChanges();
            return Ok(insuranceCase);
        }

        [HttpPut]
        public IActionResult Put([FromBody] InsuranceCase insuranceCase) {
            if (insuranceCase == null) {
                return BadRequest();
            }

            if (!_context.InsuranceCases.Any(e => e.Id == insuranceCase.Id)) {
                return NotFound();
            }

            _context.Update(insuranceCase);
            _context.SaveChanges();
            return Ok(insuranceCase);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id) {
            InsuranceCase insuranceCase = _context.InsuranceCases.FirstOrDefault(e => e.Id == id);
            if (insuranceCase == null) {
                return NotFound();
            }

            _context.InsuranceCases.Remove(insuranceCase);
            _context.SaveChanges();
            return Ok(insuranceCase);
        }
    }
}
