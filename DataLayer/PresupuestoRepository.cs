using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Data.SqlClient;
using DomainModel;
using Services;

namespace DataLayer
{
    public class PresupuestoRepository: IPresupuestoRepository
    {
        public PresupuestoRepository() 
        {
        }

        public void insert(DomainModel.Presupuesto presupuesto)
        {
            try
            {
                if (presupuesto != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.Presupuestos ( estado, importe, clienteId, vehiculoId) VALUES (@estado, @importe,@clienteId,@vehiculoId);select @@IDENTITY";
                    cmd.Parameters.AddWithValue(@"estado", presupuesto.Estado);
                    cmd.Parameters.AddWithValue(@"importe", presupuesto.Importe);
                    cmd.Parameters.AddWithValue(@"clienteId", presupuesto.Cliente.Id );
                    cmd.Parameters.AddWithValue(@"vehiculoId", presupuesto.Vehiculo.Id);
                    presupuesto.Id = Convert.ToInt32(cmd.ExecuteScalar());
                    //cmd.ExecuteNonQuery();
                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {

                cerrarConexion();
            }
        }
        public DomainModel.Presupuesto update(DomainModel.Presupuesto presupuesto)
        {
            DomainModel.Presupuesto modificado = null;
            try
            {
                if (presupuesto != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE dbo.Presupuestos set estado = @estado, importe=@importe,clienteId=@clienteId,vehiculoId=@vehiculoId where id=@id";
                    cmd.Parameters.AddWithValue(@"estado", presupuesto.Estado);
                    cmd.Parameters.AddWithValue(@"importe", presupuesto.Importe);
                    cmd.Parameters.AddWithValue(@"clienteId", presupuesto.Cliente.Id);
                    cmd.Parameters.AddWithValue(@"vehiculoId", presupuesto.Vehiculo.Id);
                    cmd.Parameters.AddWithValue(@"id", presupuesto.Id);
                    cmd.ExecuteNonQuery();
                    modificado = presupuesto;
                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {

                cerrarConexion();
            }
            return modificado;
        }
        public void remove(int id)
        {
            try
            {
                if (id != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "delete from dbo.Presupuestos where id=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    cmd.ExecuteNonQuery();

                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {

                cerrarConexion();
            }
        }
        public DomainModel.Presupuesto findById(int id)
        {
            DomainModel.Presupuesto nuevo = null;
            SqlDataReader rdr = null;
            try
            {

                if (id != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Presupuestos where id=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        //deberia buscar el cliente y el vehiculo
                        Contracts.IClienteRepository repositorioCliente = new DataLayer.ClienteRepository();
                        Services.ClienteService servicioCliente = new Services.ClienteService(repositorioCliente);
                        Contracts.IVehiculoRepository repositorioVehiculo = new DataLayer.VehiculoRepository();
                        Services.VehiculoService servicioVehiculo = new Services.VehiculoService(repositorioVehiculo);

                        DomainModel.Cliente miCliente = servicioCliente.buscarCliente((int)rdr[3]);
                        DomainModel.Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo((int)rdr[4]);

                        nuevo = new DomainModel.Presupuesto((int)rdr[0], (string)rdr[1], (decimal)rdr[2], miCliente, miVehiculo);
                    }
                    cerrarConexion();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                cerrarConexion();
            }
            return nuevo;
        }

        public ICollection<DomainModel.Presupuesto> findByAll()
        {
            ICollection<DomainModel.Presupuesto> listado = new List<DomainModel.Presupuesto>();
            SqlDataReader rdr = null;
            try
            {
                crearConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from dbo.Presupuestos";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    //deberia buscar el cliente y el vehiculo
                    Contracts.IClienteRepository repositorioCliente = new DataLayer.ClienteRepository();
                    Services.ClienteService servicioCliente = new Services.ClienteService(repositorioCliente);
                    Contracts.IVehiculoRepository repositorioVehiculo = new DataLayer.VehiculoRepository();
                    Services.VehiculoService servicioVehiculo = new Services.VehiculoService(repositorioVehiculo);

                    DomainModel.Cliente miCliente = servicioCliente.buscarCliente((int)rdr[3]);
                    DomainModel.Vehiculo miVehiculo = servicioVehiculo.buscarVehiculo((int)rdr[4]);


                    DomainModel.Presupuesto nuevo = new DomainModel.Presupuesto((int)rdr[0], (string)rdr[1], (decimal)rdr[2], miCliente, miVehiculo);
                    listado.Add(nuevo);
                }
                cerrarConexion();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex);
            }
            finally
            {
                // close the reader
                if (rdr != null)
                {
                    rdr.Close();
                }

                cerrarConexion();
            }
            return listado;
        }

        SqlConnection conn = null;
        private void crearConexion()
        {
            if (conn == null)
            {
                conn = new SqlConnection("Data Source=RulesMan;Initial Catalog=Concesionario;Integrated Security=True");
                
            }
            conn.Open();
        }

        private void cerrarConexion()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }
    }
}
