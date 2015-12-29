using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer
{
    public class UnitOfWork
    {
        public UnitOfWork()
        {
            this.context = new CodeFirstContexto();
        }
        private readonly CodeFirstContexto context;

        private GenericRepository<Cliente> clientesRepository;
        public GenericRepository<Cliente> ClientesRepository
        {
            get
            {
                if (this.clientesRepository == null)
                {
                    this.clientesRepository = new GenericRepository<Cliente>(this.context);
                }
                return this.clientesRepository;
            }
        }

        private GenericRepository<Vehiculo> vehiculosRepository;
        public GenericRepository<Vehiculo> VehiculosRepository
        {
            get
            {
                if (this.vehiculosRepository == null)
                {
                    this.vehiculosRepository = new GenericRepository<Vehiculo>(this.context);
                }
                return this.vehiculosRepository;
            }
        }

        private GenericRepository<Presupuesto> presupuestosRepository;
        public GenericRepository<Presupuesto> PresupuestosRepository
        {
            get
            {
                if (this.presupuestosRepository == null)
                {
                    this.presupuestosRepository = new GenericRepository<Presupuesto>(this.context);
                }
                return this.presupuestosRepository;
            }
        }

        public async Task SaveChangesAsync()
        {
            await this.context.SaveChangesAsync();
        }
    }
}

