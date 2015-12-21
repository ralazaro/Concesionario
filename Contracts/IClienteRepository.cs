using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IClienteRepository
    {
        void insert(DomainModel.Cliente cliente);
        DomainModel.Cliente update(DomainModel.Cliente cliente);
        void remove(int id);
        DomainModel.Cliente findById(int id);
        ICollection<DomainModel.Cliente> findByAll();
        ICollection<DomainModel.Presupuesto> obtenerPresupuestosCliente(int id);
    }
}
