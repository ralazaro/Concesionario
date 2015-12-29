using DomainModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class PresupuestoService
    {
        private Contracts.IPresupuestoRepository repositorio;
        public PresupuestoService(Contracts.IPresupuestoRepository repository)
        { 
            this.repositorio = repository;
        }

        public DomainModel.Presupuesto altaPresupuesto(int id, string estado, decimal importe, Cliente cliente, Vehiculo vehiculo)
        {
            DomainModel.Presupuesto nuevo = new DomainModel.Presupuesto(id, estado, importe, cliente, vehiculo);
            repositorio.insert(nuevo);
            return nuevo;   
        }
        public DomainModel.Presupuesto modificarPresupuesto(int id, string estado, decimal importe, Cliente cliente, Vehiculo vehiculo)
        {
            DomainModel.Presupuesto modificar = new DomainModel.Presupuesto(id, estado, importe, cliente, vehiculo);
            return repositorio.update(modificar);
        }
        public void borrarPresupuesto(int id)
        {
            repositorio.remove(id);
        }
        public DomainModel.Presupuesto buscarPresupuesto(int id)
        {
            return repositorio.findById(id);
        }
        public ICollection<DomainModel.Presupuesto> buscarTodosPresupuestos()
        {
            ICollection<DomainModel.Presupuesto> listado = repositorio.findByAll();
            return listado;
        }
    }
}
