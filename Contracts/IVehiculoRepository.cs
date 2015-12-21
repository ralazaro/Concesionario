using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IVehiculoRepository
    {
        void insert(DomainModel.Vehiculo vehiculo);
        DomainModel.Vehiculo update(DomainModel.Vehiculo vehiculo);
        void remove(int id);
        DomainModel.Vehiculo findById(int id);
        ICollection<DomainModel.Vehiculo> findByAll();
        ICollection<DomainModel.Presupuesto> obtenerPresupuestosVehiculo(int id);
    }
}
