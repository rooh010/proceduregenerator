﻿using System;
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
    public class ProcedureStepModelsController : ControllerBase
    {
        private readonly WebAPIContext _context;

        public ProcedureStepModelsController(WebAPIContext context)
        {
            _context = context;
        }

        // GET: api/ProcedureStepModels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProcedureStepModel>>> GetProcedureStepModel()
        {
            return await _context.ProcedureStepModel.ToListAsync();
        }

        // GET: api/ProcedureStepModels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProcedureStepModel>> GetProcedureStepModel(int id)
        {
            var procedureStepModel = await _context.ProcedureStepModel.FindAsync(id);

            if (procedureStepModel == null)
            {
                return NotFound();
            }

            return procedureStepModel;
        }

        // PUT: api/ProcedureStepModels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProcedureStepModel(int id, ProcedureStepModel procedureStepModel)
        {
            if (id != procedureStepModel.StepId)
            {
                return BadRequest();
            }

            _context.Entry(procedureStepModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProcedureStepModelExists(id))
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

        // POST: api/ProcedureStepModels
        [HttpPost]
        public async Task<ActionResult<ProcedureStepModel>> PostProcedureStepModel(ProcedureStepModel procedureStepModel)
        {
            _context.ProcedureStepModel.Add(procedureStepModel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetProcedureStepModel", new { id = procedureStepModel.StepId }, procedureStepModel);
        }

        // DELETE: api/ProcedureStepModels/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<ProcedureStepModel>> DeleteProcedureStepModel(int id)
        {
            var procedureStepModel = await _context.ProcedureStepModel.FindAsync(id);
            if (procedureStepModel == null)
            {
                return NotFound();
            }

            _context.ProcedureStepModel.Remove(procedureStepModel);
            await _context.SaveChangesAsync();

            return procedureStepModel;
        }

        private bool ProcedureStepModelExists(int id)
        {
            return _context.ProcedureStepModel.Any(e => e.StepId == id);
        }
    }
}
