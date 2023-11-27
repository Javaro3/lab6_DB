using lab6.Models;
using Microsoft.EntityFrameworkCore;

namespace lab6.Data;

public partial class InsuranceCompanyContext : DbContext {
    public InsuranceCompanyContext() { }

    public InsuranceCompanyContext(DbContextOptions<InsuranceCompanyContext> options) : base(options) { }

    public virtual DbSet<Client> Clients { get; set; }
    public virtual DbSet<InsuranceCase> InsuranceCases { get; set; }
    public virtual DbSet<SupportingDocument> SupportingDocuments { get; set; }
}