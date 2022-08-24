using EChallan.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EChallan.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<ChallaNumberDetail> ChallaNumberDetails { get; set; }

        public DbSet<ChallanDetails> ChallanDetails { get; set; }
        public DbSet<Issue> Issue { get; set; }

        public DbSet<PaymentMethod> PaymentMethod { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

    }
}
