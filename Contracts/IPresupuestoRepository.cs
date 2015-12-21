using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contracts
{
    public interface IPresupuestoRepository
    {
         void insert(DomainModel.Presupuesto presupuesto);
         DomainModel.Presupuesto update(DomainModel.Presupuesto presupuesto);
         void remove(int id);
         DomainModel.Presupuesto findById(int id);
         ICollection<DomainModel.Presupuesto> findByAll();
    }
}
