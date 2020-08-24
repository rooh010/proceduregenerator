using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProcedureLib.Models;

namespace ProcedureFrontend.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<ProcedureLib.Models.ProcedureModel> ProcedureModel { get; set; }
        public DbSet<ProcedureLib.Models.ProcedureStepModel> ProcedureStepModel { get; set; }
    }
}
