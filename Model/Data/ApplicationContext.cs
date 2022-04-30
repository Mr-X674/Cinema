using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cinema.Model.Data
{
    internal class ApplicationContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<Genre> Genres { get; set; }
        public DbSet<hall> halls { get; set; }
        public DbSet<session> sessions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }

        public ApplicationContext() => Database.EnsureCreated();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            //optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=SAMVVMEF;Trusted_Connection=True;");
            //optionsBuilder.UseSqlServer("Data Source=DESKTOP-I8L1GP6;Initial Catalog=SAMVVMEF;Integrated Security = True");
            optionsBuilder.UseSqlServer("Data Source=MSI-AEGIS-TI3;Initial Catalog=Cinema2.0;Integrated Security=True");
            //optionsBuilder.UseSqlServer(@"Data Source=PC-232-12\SQLEXPRESS;Initial Catalog=SAMVVMEF;User ID=sa;Password=4321193");
        }
    }
}
