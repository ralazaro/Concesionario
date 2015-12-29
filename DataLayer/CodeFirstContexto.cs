using DomainModel;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataLayer
{
    public class CodeFirstContexto : DbContext
    {
        public CodeFirstContexto() : base(nameOrConnectionString: "Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True") { 
        
        }

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Presupuesto> Presupuestos { get; set; }

    }
}


/*
using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace DataLayer
{
        
    public class CodeFirstContexto : DbContext
    {
        public CodeFirstContexto:base("Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True")
        {
    
        }
        
        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Vehiculo> Vehiculos { get; set; }

        public DbSet<Presupuesto> Presupuestos { get; set; }
    }
}
*/