using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Presupuesto
    {
        private int id;
        private string estado;
        private double importe;
        private int idCliente;
        private int idVehiculo;

        public Presupuesto(int id, string estado, double importe, int idCliente, int idVehiculo)
        {
            this.id = id;
            this.estado = estado;
            this.importe = importe;
            this.idCliente = idCliente;
            this.idVehiculo = idVehiculo;
        }

        public int Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }      

        public string Estado
        {
            get
            {
                return this.estado;
            }
            set
            {
                this.estado = value;
            }
        }
        public double Importe
        {
            get
            {
                return this.importe;
            }
            set
            {
                this.importe = value;
            }
        }
        public int IdCliente
        {
            get
            {
                return this.idCliente;
            }
            private set
            {
                this.idCliente = value;
            }
        }
        public int IdVehiculo
        {
            get
            {
                return this.idVehiculo;
            }
            private set
            {
                this.idVehiculo = value;
            }
        }
    }
}
