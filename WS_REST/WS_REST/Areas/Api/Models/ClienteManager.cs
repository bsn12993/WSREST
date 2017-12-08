using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;

namespace WS_REST.Areas.Api.Models
{
    public class ClienteManager
    {
        public static string cadenaConexion = @"Data Source=(local);Initial Catalog=BDClientes;Persist Security Info=True;User ID=sa;Password=123";
        public SqlConnection getConnection()
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Open();
            return con;
        }

        public void closeConnection()
        {
            SqlConnection con = new SqlConnection(cadenaConexion);
            con.Close() ;
        }

        public bool InsertarCliente(Cliente cli)
        {
            string sql = "INSERT INTO Clientes (Nombre,Telefono) VALUES (@nombre,@telefono)";
            SqlCommand cmd = new SqlCommand(sql,getConnection());
            cmd.Parameters.Add("@nombre",System.Data.SqlDbType.NVarChar).Value=cli.Nombre;
            cmd.Parameters.Add("@telefono",System.Data.SqlDbType.Int).Value=cli.Telefono;
            int res = cmd.ExecuteNonQuery();
            closeConnection();
            return (res == 1 ? true : false);
        }

        public bool ActualizarCliente(Cliente cli)
        {
            string sql = "UPDATE Clientes SET Nombre = @nombre, Telefono = @telefono WHERE IdCliente = @idcliente";
            SqlCommand cmd = new SqlCommand(sql,getConnection());
            cmd.Parameters.Add("@nombre",System.Data.SqlDbType.NVarChar).Value=cli.Nombre;
            cmd.Parameters.Add("@telefono",System.Data.SqlDbType.Int).Value=cli.Telefono;
            cmd.Parameters.Add("@idcliente",System.Data.SqlDbType.Int).Value=cli.Id;
            int res = cmd.ExecuteNonQuery();
            closeConnection();
            return (res == 1);
            
        }

        public Cliente ObtenerCliente(int id)
        {
            Cliente cli = null;
            string sql = "SELECT Nombre,Telefono FROM Clientes WHERE IdCliente = @idcliente";
            SqlCommand cmd = new SqlCommand(sql,getConnection());
            cmd.Parameters.Add("@idcliente",System.Data.SqlDbType.NVarChar).Value=id;
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            if (reader.Read())
            {
                cli = new Cliente();
                cli.Id = id;
                cli.Nombre = reader.GetString(0);
                cli.Telefono = reader.GetInt32(1);
            }
            reader.Close();
            return cli;
        }

        public List<Cliente> ObtenerClientes()
        {
            List<Cliente> lstCliente = new List<Cliente>();
            string sql = "SELECT IdCliente,Nombre,Telefono FROM Clientes";
            SqlCommand cmd = new SqlCommand(sql,getConnection());
            SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
            while (reader.Read())
            {
                Cliente cli = new Cliente();
                cli = new Cliente();
                cli.Id = reader.GetInt32(0);
                cli.Nombre = reader.GetString(1);
                cli.Telefono = reader.GetInt32(2);
                lstCliente.Add(cli);
            }
            reader.Close();
            return lstCliente;
        }

        public bool EliminarCliente(int id)
        {
            string sql = "DELETE FROM Clientes WHERE IdCliente = @idcliente";
            SqlCommand cmd = new SqlCommand(sql,getConnection());
            cmd.Parameters.Add("@idcliente", System.Data.SqlDbType.Int).Value = id;
            int res = cmd.ExecuteNonQuery();
            closeConnection();
            return (res == 1);
        }
    }
}