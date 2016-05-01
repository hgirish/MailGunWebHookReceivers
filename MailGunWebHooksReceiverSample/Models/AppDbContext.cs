using System.Data.Entity;
using GhWebHooks.Models;

namespace MailGunWebHooksReceiverSample.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() : base("AppDbContext")
        {
            
        }
        public DbSet<EmailTrackerModel> EmailTrackers { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<EmailTrackerModel>().ToTable("EmailTrackers","CommonData");
        }
    }
}