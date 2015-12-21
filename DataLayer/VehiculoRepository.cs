using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using System.Data.SqlClient;

namespace DataLayer
{
    public class VehiculoRepository: IVehiculoRepository
    {
        public VehiculoRepository() 
        {
        }

        public void insert(DomainModel.Vehiculo vehiculo)
        {
            try
            {
                if (vehiculo != null)
                {
                    crearConexion();                    
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO dbo.Vehiculos ( marca, modelo, potencia) VALUES (@marca, @modelo,@potencia);select @@IDENTITY";
                    cmd.Parameters.AddWithValue(@"marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue(@"modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue(@"potencia", vehiculo.Potencia);
                    vehiculo.Id = Convert.ToInt32(cmd.ExecuteScalar());
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
        public DomainModel.Vehiculo update(DomainModel.Vehiculo vehiculo)
        {
            DomainModel.Vehiculo modificado = null;
            try
            {
                if (vehiculo != null)
                {
                    crearConexion();
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "UPDATE dbo.Vehiculos set marca =@marca, modelo=@modelo, potencia=@potencia where id=@id";
                    cmd.Parameters.AddWithValue(@"marca", vehiculo.Marca);
                    cmd.Parameters.AddWithValue(@"modelo", vehiculo.Modelo);
                    cmd.Parameters.AddWithValue(@"potencia", vehiculo.Potencia);
                    cmd.Parameters.AddWithValue(@"id", vehiculo.Id);
                    cmd.ExecuteNonQuery();
                    modificado = vehiculo;
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
                    cmd.CommandText = "delete from dbo.Vehiculos where id=@id";
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
        public DomainModel.Vehiculo findById(int id)
        {
            DomainModel.Vehiculo nuevo = null;
            SqlDataReader rdr = null;
            try
            {

                if (id != null)
                {
                    crearConexion();

                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "select * from dbo.Vehiculos where id=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();

                    while (rdr.Read())
                    {
                        nuevo = new DomainModel.Vehiculo((int)rdr[0], (string)rdr[1], (string)rdr[2], (int)rdr[3]);
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

        public ICollection<DomainModel.Vehiculo> findByAll()
        {
            ICollection<DomainModel.Vehiculo> listado = new List<DomainModel.Vehiculo>();
            SqlDataReader rdr = null;
            try
            {
                crearConexion();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                cmd.CommandText = "select * from dbo.Vehiculos";
                rdr = cmd.ExecuteReader();

                while (rdr.Read())
                {
                    DomainModel.Vehiculo nuevo = new DomainModel.Vehiculo((int)rdr[0], (string)rdr[1], (string)rdr[2], (int)rdr[3]);
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

        public ICollection<DomainModel.Presupuesto> obtenerPresupuestosVehiculo(int id)
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
                    cmd.CommandText = "select * from dbo.Presupuestos where VehiculoId=@id";
                    cmd.Parameters.AddWithValue(@"id", id);
                    rdr = cmd.ExecuteReader();

                    
                    while (rdr.Read())
                    {
                        DomainModel.Presupuesto nuevo = new DomainModel.Presupuesto((int)rdr[0], (string)rdr[1], (double)rdr[2], (int)rdr[3], (int)rdr[4]);
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
