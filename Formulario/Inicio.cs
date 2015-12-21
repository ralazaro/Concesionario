using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Formulario
{
    public partial class Inicio : Form
    {
        public Inicio()
        {
            InitializeComponent();
        }

        private void btnCliente_Click(object sender, EventArgs e)
        {
            Contracts.IClienteRepository repositorio = new DataLayer.ClienteRepository();
            Services.ClienteService servicio = new Services.ClienteService(repositorio);
            //Creamos un nuevo cliente con el constructor
            DomainModel.Cliente nuevo = new DomainModel.Cliente(1,"Raul", "Lazaro Lopez","123456789", true);
            //Damos de alta un nuevo cliente con el constructor creado
            nuevo=servicio.altaCliente(nuevo.Id, nuevo.Nombre, nuevo.Apellidos, nuevo.Telefono, nuevo.Vip);
            //Console.WriteLine("Damos de alta a primer cliente:" + nuevo.Id+", Raul, Lazaro Lopez,123456789, true");
            Console.WriteLine("Damos de alta al primer cliente:" + nuevo.Id + "," + nuevo.Nombre + "," + nuevo.Apellidos + "," + nuevo.Telefono + "," + nuevo.Vip);
            //Damos de alta a otro cliente directamente
            DomainModel.Cliente nuevo2=servicio.altaCliente(2, "Paula", "Lazaro Casado", "987654321", false);
            //Console.WriteLine("Damos de alta a segundo cliente:" + nuevo2.Id + ",Paula,Lazaro Casado,987654321,false");
            Console.WriteLine("Damos de alta al segundo cliente:" + nuevo2.Id + "," + nuevo2.Nombre + "," + nuevo2.Apellidos + "," + nuevo2.Telefono + "," + nuevo2.Vip);

            //listo todos los clientes
            ICollection<DomainModel.Cliente> listadoClientes = new List<DomainModel.Cliente>();
            listadoClientes=servicio.buscarTodosClientes();
            Console.WriteLine("el listado de clientes totales son:");
            foreach( DomainModel.Cliente cliente in listadoClientes){
                Console.WriteLine(cliente.Id + "," + cliente.Nombre + "," + cliente.Apellidos + "," + cliente.Telefono + "," + cliente.Vip);
            }

            //listo todos los presupuesto del cliente nuevo
            ICollection<DomainModel.Presupuesto> listadoPresupuestoCliente = new List<DomainModel.Presupuesto>();
            listadoPresupuestoCliente=servicio.obtenerPresupuestosCliente(nuevo2.Id);
            Console.WriteLine("el listado de presupuesto del cliente con id "+nuevo2.Id+ " son:");
            foreach (DomainModel.Presupuesto presupuesto in listadoPresupuestoCliente)
            {
                Console.WriteLine(presupuesto.Id + "," + presupuesto.Id + "," + presupuesto.Importe + "," + presupuesto.IdCliente + "," + presupuesto.IdVehiculo);
            }

            //buscamos el cliente nuevo.Id
            Console.WriteLine("Buscamos el cliente con Id="+nuevo.Id);
            DomainModel.Cliente miCliente = servicio.buscarCliente(nuevo.Id);
            Console.WriteLine("El cliente encontrado con Id=" + miCliente.Id + " es: " + miCliente.Id + "," + miCliente.Nombre + "," + miCliente.Apellidos + "," + miCliente.Telefono + "," + miCliente.Vip);

            //modificamos el cliente nuevo2.Id
              DomainModel.Cliente miClienteModificado = servicio.modificarCliente(nuevo2.Id, "Silvia", "Martinez", "567894321", false);
              Console.WriteLine("El cliente modificado con Id=" + miClienteModificado.Id + " es: " + miClienteModificado.Id + "," + miClienteModificado.Nombre + "," + miClienteModificado.Apellidos + "," + miClienteModificado.Telefono + "," + miClienteModificado.Vip);

             //borramos el cliente modificado
              servicio.borrarCliente(miClienteModificado.Id);
              Console.WriteLine("Borramos el cliente modificado con Id=" + miClienteModificado.Id);



        }

        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
            

        }

        private void btnVehiculo_Click(object sender, EventArgs e)
        {
            Contracts.IVehiculoRepository repositorio = new DataLayer.VehiculoRepository();
            Services.VehiculoService servicio = new Services.VehiculoService(repositorio);
            //Creamos un nuevo Vehiculo con el constructor
            //int id, string marca, string modelo, int potencia
            DomainModel.Vehiculo nuevo = new DomainModel.Vehiculo(1, "Audi", "A5", 150);
            //Damos de alta un nuevo Vehiculo con el constructor creado
            nuevo = servicio.altaVehiculo(nuevo.Id, nuevo.Marca, nuevo.Modelo, nuevo.Potencia);
            //Console.WriteLine("Damos de alta a primer Vehiculo:" + nuevo.Id+", Raul, Lazaro Lopez,123456789, true");
            Console.WriteLine("Damos de alta al primer Vehiculo:" + nuevo.Id + "," + nuevo.Marca + "," + nuevo.Modelo + "," + nuevo.Potencia);
            //Damos de alta a otro Vehiculo directamente
            DomainModel.Vehiculo nuevo2 = servicio.altaVehiculo(2, "mercedes", "B-180", 130);
            //Console.WriteLine("Damos de alta a segundo Vehiculo:" + nuevo2.Id + ",Paula,Lazaro Casado,987654321,false");
            Console.WriteLine("Damos de alta al segundo Vehiculo:" + nuevo2.Id + "," + nuevo2.Marca + "," + nuevo2.Modelo + "," + nuevo2.Potencia);

            //listo todos los Vehiculos
            ICollection<DomainModel.Vehiculo> listadoVehiculos = new List<DomainModel.Vehiculo>();
            listadoVehiculos = servicio.buscarTodosVehiculos();
            Console.WriteLine("el listado de Vehiculos totales son:");
            foreach (DomainModel.Vehiculo Vehiculo in listadoVehiculos)
            {
                Console.WriteLine(Vehiculo.Id + "," + Vehiculo.Marca + "," + Vehiculo.Modelo + "," + Vehiculo.Potencia);
            }

            //listo todos los presupuesto del Vehiculo nuevo
            ICollection<DomainModel.Presupuesto> listadoPresupuestoVehiculo = new List<DomainModel.Presupuesto>();
            listadoPresupuestoVehiculo = servicio.obtenerPresupuestosVehiculo(nuevo2.Id);
            Console.WriteLine("el listado de presupuesto del Vehiculo con id " + nuevo2.Id + " son:");
            foreach (DomainModel.Presupuesto presupuesto in listadoPresupuestoVehiculo)
            {
                Console.WriteLine(presupuesto.Id + "," + presupuesto.Id + "," + presupuesto.Importe + "," + presupuesto.IdVehiculo + "," + presupuesto.IdVehiculo);
            }

            //buscamos el Vehiculo nuevo.Id
            Console.WriteLine("Buscamos el Vehiculo con Id=" + nuevo.Id);
            DomainModel.Vehiculo miVehiculo = servicio.buscarVehiculo(nuevo.Id);
            Console.WriteLine("El Vehiculo encontrado con Id=" + miVehiculo.Id + " es: " + miVehiculo.Id + "," + miVehiculo.Marca + "," + miVehiculo.Modelo + "," + miVehiculo.Potencia);

            //modificamos el Vehiculo nuevo2.Id
            DomainModel.Vehiculo miVehiculoModificado = servicio.modificarVehiculo(nuevo.Id, "Mercedes", "B-200", 180);
            Console.WriteLine("El Vehiculo modificado con Id=" + miVehiculoModificado.Id + " es: " + miVehiculoModificado.Id + "," + miVehiculoModificado.Marca + "," + miVehiculoModificado.Modelo + "," + miVehiculoModificado.Potencia);

            //borramos el Vehiculo modificado
            servicio.borrarVehiculo(miVehiculoModificado.Id);
            Console.WriteLine("Borramos el Vehiculo modificado con Id=" + miVehiculoModificado.Id);
        }

        private void btnPresupuesto_Click(object sender, EventArgs e)
        {
            Contracts.IPresupuestoRepository repositorio = new DataLayer.PresupuestoRepository();
            Services.PresupuestoService servicio = new Services.PresupuestoService(repositorio);
            //Creamos un nuevo Presupuesto con el constructor
            DomainModel.Presupuesto nuevo = new DomainModel.Presupuesto(1, "terminado", 100, 28, 10);
            //int id, string estado, double importe, int idCliente, int idVehiculo
            //Damos de alta un nuevo Presupuesto con el constructor creado
            nuevo = servicio.altaPresupuesto(nuevo.Id, nuevo.Estado, nuevo.Importe, nuevo.IdCliente, nuevo.IdVehiculo);
            //Console.WriteLine("Damos de alta a primer Presupuesto:" + nuevo.Id+", Raul, Lazaro Lopez,123456789, true");
            Console.WriteLine("Damos de alta el primer Presupuesto:" + nuevo.Id + "," + nuevo.Estado + "," + nuevo.Importe + "," + nuevo.IdCliente + "," + nuevo.IdVehiculo);
            //Damos de alta a otro Presupuesto directamente
            DomainModel.Presupuesto nuevo2 = servicio.altaPresupuesto(2, "empezado", 200, 28, 10);
            //Console.WriteLine("Damos de alta a segundo Presupuesto:" + nuevo2.Id + ",Paula,Lazaro Casado,987654321,false");
            Console.WriteLine("Damos de alta el segundo Presupuesto:" + nuevo2.Id + "," + nuevo2.Estado + "," + nuevo2.Importe + "," + nuevo2.IdCliente + "," + nuevo2.IdVehiculo);

            //listo todos los Presupuestos
            ICollection<DomainModel.Presupuesto> listadoPresupuestos = new List<DomainModel.Presupuesto>();
            listadoPresupuestos = servicio.buscarTodosPresupuestos();
            Console.WriteLine("el listado de Presupuestos totales son:");
            foreach (DomainModel.Presupuesto Presupuesto in listadoPresupuestos)
            {
                Console.WriteLine(Presupuesto.Id + "," + Presupuesto.Estado + "," + Presupuesto.Importe + "," + Presupuesto.IdCliente + "," + Presupuesto.IdVehiculo);                
            }


            //buscamos el Presupuesto nuevo.Id
            Console.WriteLine("Buscamos el Presupuesto con Id=" + nuevo.Id);
            DomainModel.Presupuesto miPresupuesto = servicio.buscarPresupuesto(nuevo.Id);
            Console.WriteLine("El Presupuesto encontrado con Id=" + miPresupuesto.Id + " es: " + miPresupuesto.Id + "," + miPresupuesto.Estado + "," + miPresupuesto.Importe + "," + miPresupuesto.IdCliente + "," + miPresupuesto.IdVehiculo);

            //modificamos el Presupuesto nuevo2.Id
            DomainModel.Presupuesto miPresupuestoModificado = servicio.modificarPresupuesto(nuevo2.Id, "empezado", 300, 28, 10);
            Console.WriteLine("El Presupuesto modificado con Id=" + miPresupuestoModificado.Id + " es: " + miPresupuestoModificado.Id + "," + miPresupuestoModificado.Estado + "," + miPresupuestoModificado.Importe + "," + miPresupuestoModificado.IdCliente + "," + miPresupuestoModificado.IdVehiculo);

            //borramos el Presupuesto modificado
            servicio.borrarPresupuesto(miPresupuestoModificado.Id);
            Console.WriteLine("Borramos el Presupuesto modificado con Id=" + miPresupuestoModificado.Id);
        }


    }
}
