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

        public DbSet<TaxPoc2Company> TaxPoc2Companies { get; set; }
        public DbSet<TaxPoc2CompanyDepartment> TaxPoc2CompanyDepartments { get; set; }
        public DbSet<TaxPoc2Product> TaxPoc2Products { get; set; }
        public DbSet<TaxPoc2Invoice> TaxPoc2Invoices { get; set; }
        public DbSet<TaxPoc2BankAccount> TaxPoc2BankAccounts { get; set; }
        public DbSet<TaxPoc2BankMovement> TaxPoc2BankMovements { get; set; }
        public DbSet<TaxPoc2ProductCatalogue> TaxPoc2ProductCatalogues { get; set; }
        public DbSet<TaxPoc2PurchaseCatalogue> TaxPoc2PurchaseCatalogues { get; set; }
        public DbSet<TaxPoc2Customer> TaxPoc2Customers { get; set; }

        public DbSet<BlockChainAccount> BlockChainAccounts { get; set; }
        public DbSet<BlockChainServer> BlockChainServers { get; set; }
        public DbSet<SmartContract> SmartContracts { get; set; }
        public DbSet<TransactionLog> TransactionLogs { get; set; }

    }
}