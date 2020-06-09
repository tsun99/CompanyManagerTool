using CompanyManagerTool.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyManagerTool.Data
{
    public class CompanyContext:DbContext
    {
        public CompanyContext(DbContextOptions<CompanyContext> options) : base(options)
        {

        }
        public DbSet<Company> CompanyDb { get; set; }

        public DbSet<VmvtDivision> VmvtDb { get; set; }
    }
}
