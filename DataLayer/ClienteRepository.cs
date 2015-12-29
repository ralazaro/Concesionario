using Contracts;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DomainModel;

namespace DataLayer
{
    public class ClienteRepository : IClienteRepository
    {
        public ClienteRepository() 
        {
            
        }

        public void insert(DomainModel.Cliente cliente)
        {
            try
            {
                if (cliente != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.Clientes ( nombre, apellidos, telefono, vip) VALUES ( @nombre, @apellidos,@telefono,@vip);select @@IDENTITY";
                    cmd.Parameters.AddWithValue(@"nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue(@"apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue(@"telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue(@"vip", cliente.Vip);
                    cliente.Id = Convert.ToInt32(cmd.ExecuteScalar());

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
        public DomainModel.Cliente update(DomainModel.Cliente cliente)
        {
            DomainModel.Cliente modificado = null;
            try
            {
                if (cliente != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE dbo.Clientes set nombre = @nombre, apellidos=@apellidos, telefono=@telefono, vip=@vip where id=@id";
                    cmd.Parameters.AddWithValue(@"nombre", cliente.Nombre);
                    cmd.Parameters.AddWithValue(@"apellidos", cliente.Apellidos);
                    cmd.Parameters.AddWithValue(@"telefono", cliente.Telefono);
                    cmd.Parameters.AddWithValue(@"vip", cliente.Vip);
                    cmd.Parameters.AddWithValue(@"id", cliente.Id);
                    cmd.ExecuteNonQuery();
                    cerrarConexion();
                    modificado = cliente;
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
                    cmd.CommandText = "delete from dbo.Clientes where id=@id";
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
        public DomainModel.Cliente findById(int id)
        {
            DomainModel.Cliente nuevo = null;
            SqlDataReader rdr = null;
            try
            {

                if (id != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Clientes where id=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        nuevo = new DomainModel.Cliente((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], (bool)rdr[4]);
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

        public ICollection<DomainModel.Cliente> findByAll()
        {
            ICollection<DomainModel.Cliente> listado = new List<DomainModel.Cliente>();
            SqlDataReader rdr = null;
            try
            {               
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Clientes";
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        DomainModel.Cliente nuevo = new DomainModel.Cliente((int)rdr[0], (string)rdr[1], (string)rdr[2], (string)rdr[3], (bool)rdr[4]);
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

        public ICollection<DomainModel.Presupuesto> obtenerPresupuestosCliente(int id)
        {
            ICollection<DomainModel.Presupuesto> listado = new List<DomainModel.Presupuesto>();
            SqlDataReader rdr = null;
            try
            {

                if (id != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Presupuestos where ClienteId=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();
                    
                    while (rdr.Read())
                    {
                        DomainModel.Presupuesto nuevo = new Presupuesto((int)rdr[0], (string)rdr[1], (decimal)rdr[2], (Cliente)rdr[3], (Vehiculo)rdr[4]);
                        listado.Add(nuevo);
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
