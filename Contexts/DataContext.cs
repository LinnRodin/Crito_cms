using Crito.Entitys;
using Microsoft.EntityFrameworkCore;

namespace Crito.Contexts
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
            
        }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<SubscribeEntity> Subscribers { get; set; }
        public DbSet<ContactFormEntity> ContactForms { get; set; }


    }
}
