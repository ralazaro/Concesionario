using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Cliente
    {
        private int id;
        private string nombre;
        private string apellidos;
        private string telefono;
        private bool vip;
        private ICollection<Presupuesto> presupuestos;

        public Cliente(int id, string nombre, string apellidos, string telefono, bool vip)
        {
            this.id = id;
            this.nombre = nombre;
            this.apellidos = apellidos;
            this.telefono = telefono;
            this.vip = vip;
            this.presupuestos = new HashSet<Presupuesto>();
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

        public string Nombre
        {
            get
            {
                return this.nombre;
            }
            set
            {
                this.nombre = value;
            }
        }
        public string Apellidos
        {
            get
            {
                return this.apellidos;
            }
            set
            {
                this.apellidos = value;
            }
        }
        public string Telefono
        {
            get
            {
                return this.telefono;
            }
            set
            {
                this.telefono = value;
            }
        }

        public bool Vip
        {
            get
            {
                return this.vip;
            }
            set
            {
                this.vip = value;
            }
        }
        public ICollection<Presupuesto> Presupuestos
        {
            get
            {
                return this.presupuestos;
            }
            set
            {
                this.presupuestos = value;
            }
        }
    }
}
