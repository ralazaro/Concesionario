using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DomainModel
{
    public class MyDbContext : DbContext
    { 
        public MyDbContext() : base(nameOrConnectionString: "Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True") { }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Presupuesto> Presupuestos { get; set; }

    }
}
