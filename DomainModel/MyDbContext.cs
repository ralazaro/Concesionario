using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class MyDbContext : DbContext
    {
        public MyDbContext() : base(nameOrConnectionString: "MyDbContext") { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Presupuestos> Vehiculos { get; set; }

    }
}
