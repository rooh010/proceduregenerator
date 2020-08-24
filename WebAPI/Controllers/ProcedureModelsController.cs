using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ProcedureLib.Models;
using WebAPI.Data;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProcedureModelsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ProcedureModelsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProcedureModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedureModel>>> GetProcedureModel()
        {
            return await _context.ProcedureModel.ToListAsync();
        }

        // GET: api/ProcedureModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureModel>> GetProcedureModel(int id)
        {
            var procedureModel = await _context.ProcedureModel.FindAsync(id);

            if (procedureModel == null)
            {
                return NotFound();
            }

            return procedureModel;
        }

        // PUT: api/ProcedureModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedureModel(int id, ProcedureModel procedureModel)
        {
            if (id != procedureModel.ProcedureId)
            {
                return BadRequest();
            }

            _context.Entry(procedureModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureModelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ProcedureModels
        [HttpPost]
        public async Task<ActionResult<ProcedureModel>> PostProcedureModel(ProcedureModel procedureModel)
        {
            _context.ProcedureModel.Add(procedureModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedureModel", new { id = procedureModel.ProcedureId }, procedureModel);
        }

        // DELETE: api/ProcedureModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProcedureModel>> DeleteProcedureModel(int id)
        {
            var procedureModel = await _context.ProcedureModel.FindAsync(id);
            if (procedureModel == null)
            {
                return NotFound();
            }

            _context.ProcedureModel.Remove(procedureModel);
            await _context.SaveChangesAsync();

            return procedureModel;
        }

        private bool ProcedureModelExists(int id)
        {
            return _context.ProcedureModel.Any(e => e.ProcedureId == id);
        }
    }
}
