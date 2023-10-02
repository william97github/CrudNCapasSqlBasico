using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class CDusuario
    {
        private CDconexion conexion = new CDconexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from usuario;";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

        public void Insertar(string usuario, string clave)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into usuario values ('"+usuario+"', '"+clave+"');";
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void Editar(string usuario, string clave, int idusuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "update usuario set usuario = '"+usuario+"', clave = '"+clave+"' where idusuario = "+idusuario+";";
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }

        public void Eliminar(int idusuario)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "delete from usuario where idusuario = "+idusuario+";";
            comando.ExecuteNonQuery();
            conexion.CerrarConexion();
        }
        public DataTable Buscar(string buscar)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "select * from usuario where usuario like '%"+buscar+"%';";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;
        }

    }
}
