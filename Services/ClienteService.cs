using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class ClienteService
    {
        private Contracts.IClienteRepository repositorio;
        public ClienteService(Contracts.IClienteRepository repository) { 
            this.repositorio = repository;
        }

        public DomainModel.Cliente altaCliente(int id, string nombre, string apellidos, string telefono, bool vip)
        {
            DomainModel.Cliente nuevo = new DomainModel.Cliente(id, nombre, apellidos, telefono, vip);
            repositorio.insert(nuevo);
            return nuevo;   
        }
        public DomainModel.Cliente modificarCliente(int id, string nombre, string apellidos, string telefono, bool vip)
        {
            DomainModel.Cliente modificar = new DomainModel.Cliente(id, nombre, apellidos, telefono, vip);
            return repositorio.update(modificar);
        }
        public void borrarCliente(int id)
        {
            repositorio.remove(id);
        }
        public DomainModel.Cliente buscarCliente(int id)
        {
            return repositorio.findById(id);
        }
        public ICollection<DomainModel.Cliente> buscarTodosClientes()
        {
            ICollection<DomainModel.Cliente> listado = repositorio.findByAll();
            return listado;
        }
        public ICollection<DomainModel.Presupuesto> obtenerPresupuestosCliente(int id)
        {
            ICollection<DomainModel.Presupuesto> listado = repositorio.obtenerPresupuestosCliente(id);
            return listado; 
        }
    }
}
