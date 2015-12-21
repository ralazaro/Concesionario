using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class VehiculoService
    {
        private Contracts.IVehiculoRepository repositorio;
        public VehiculoService(Contracts.IVehiculoRepository repository) { 
            this.repositorio = repository;
        }

        public DomainModel.Vehiculo altaVehiculo(int id, string marca, string modelo, int potencia)
        {
            DomainModel.Vehiculo nuevo = new DomainModel.Vehiculo(id,marca,modelo,potencia);
            repositorio.insert(nuevo);
            return nuevo;   
        }
        public DomainModel.Vehiculo modificarVehiculo(int id, string marca, string modelo, int potencia)
        {
            DomainModel.Vehiculo modificar = new DomainModel.Vehiculo(id, marca, modelo, potencia);
            return repositorio.update(modificar);
        }
        public void borrarVehiculo(int id)
        {
            repositorio.remove(id);
        }
        public DomainModel.Vehiculo buscarVehiculo(int id)
        {
            return repositorio.findById(id);
        }
        public ICollection<DomainModel.Vehiculo> buscarTodosVehiculos()
        {
            ICollection<DomainModel.Vehiculo> listado = repositorio.findByAll();
            return listado;
        }

        public ICollection<DomainModel.Presupuesto> obtenerPresupuestosVehiculo(int id)
        {
            ICollection<DomainModel.Presupuesto> listado = repositorio.obtenerPresupuestosVehiculo(id);
            return listado;
        }
    }
}
