using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModel
{
    public class Vehiculo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id{get;set;}

        [Required]
        public string Marca { get; set; }

        public string Modelo { get; set; }

        public int Potencia { get; set; }

        public ICollection<Presupuesto> Presupuestos;

        public Vehiculo()
        {

        }


        public Vehiculo(int id, string marca, string modelo, int potencia)
        {
            this.Id = id;
            this.Marca = marca;
            this.Modelo = modelo;
            this.Potencia = potencia;
            this.Presupuestos = new HashSet<Presupuesto>();
        }


        /*
        private int id;
        private string marca;
        private string modelo;
        private int potencia;
        private ICollection<Presupuesto> presupuestos;
        
        public Vehiculo(int id, string marca, string modelo, int potencia)
        {
            this.id = id;
            this.marca = marca;
            this.modelo = modelo;
            this.potencia = potencia;
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

        public string Marca
        {
            get
            {
                return this.marca;
            }
            set
            {
                this.marca = value;
            }
        }
        public string Modelo
        {
            get
            {
                return this.modelo;
            }
            set
            {
                this.modelo = value;
            }
        }
        public int Potencia
        {
            get
            {
                return this.potencia;
            }
            set
            {
                this.potencia = value;
            }
        }
        public ICollection<Presupuesto> Presupuestos
        {
            get { return presupuestos; }
            set { presupuestos = value; }
        }
        */
    }
}
