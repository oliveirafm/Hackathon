using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Hackathon.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyDepartment> CompanyDepartments { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<BankAccount> BankAccounts { get; set; }
        public DbSet<BankMovement> BankMovements { get; set; }
        public DbSet<ProductCatalogue> ProductCatalogues { get; set; }
        public DbSet<PurchaseCatalogue> PurchaseCatalogues { get; set; }
        public DbSet<Customer> Customers { get; set; }

        public DbSet<BlockChainAccount> BlockChainAccounts { get; set; }
        public DbSet<BlockChainServer> BlockChainServers { get; set; }
        public DbSet<SmartContract> SmartContracts { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

    }
}