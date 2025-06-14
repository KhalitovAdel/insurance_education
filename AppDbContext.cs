using System.Diagnostics;
using insurance.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure.Internal;

namespace insurance;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    { }
    
    public DbSet<Branch> Branches { get; set; }
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employee> Employee { get; set; }
    public DbSet<InsuranceCase> InsuranceCases { get; set; }
    public DbSet<Payout> Payouts { get; set; }
    public DbSet<Policy> Policies { get; set; }
}