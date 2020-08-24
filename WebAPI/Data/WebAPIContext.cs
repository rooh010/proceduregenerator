using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProcedureLib.Models;

namespace WebAPI.Data
{
    public class WebAPIContext : DbContext
    {
        public WebAPIContext (DbContextOptions<WebAPIContext> options)
            : base(options)
        {
        }

        public DbSet<ProcedureLib.Models.ProcedureModel> ProcedureModel { get; set; }

        public DbSet<ProcedureLib.Models.ProcedureStepModel> ProcedureStepModel { get; set; }
    }
}
