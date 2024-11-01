using Home.Models;
using Microsoft.EntityFrameworkCore;

namespace Home.Contex
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {
        
        }
        public DbSet<FoodsModel> Foods { get; set; }
        public DbSet<TransportsModel> Transports { get; set; }
        public DbSet<MobilesModel> Mobiles { get; set; }
        public DbSet<InternetsModel> Internets { get; set; }
        public DbSet<EntertainmentsModel> Entertainments { get; set; }

    }
}
