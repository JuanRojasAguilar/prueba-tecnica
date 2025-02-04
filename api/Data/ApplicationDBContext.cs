using api.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data;

public class ApplicationDBContext : IdentityDbContext
{
    public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
    {

    }

    public DbSet<Product> Product { get; set; }
    public DbSet<Receipt> Receipt { get; set; }
    public DbSet<ReceiptDetails> ReceiptDetails { get; set; }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<ProductAudit> ProductAudit { get; set; }

    public DbSet<CustomerAudit> CustomerAudit { get; set; }

    public DbSet<ReceiptAudit> ReceiptAudit { get; set; }

    public DbSet<ReceiptOverview> ReceiptOverview { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Customer>()
            .ToTable(tb => tb.HasTrigger("trg_AuditCustomer"));

        modelBuilder.Entity<Product>()
      .ToTable(tb => tb.HasTrigger("trg_AuditProduct"));

        modelBuilder.Entity<Receipt>()
      .ToTable(tb => tb.HasTrigger("trg_AuditReceipt"));

        modelBuilder.Entity<ReceiptDetails>()
      .ToTable(tb => tb.HasTrigger("trg_UpdateProductStock"));
    }
}
