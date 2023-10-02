using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using CapaDatos;

namespace CapaNegocio
{
    public class CNusuario
    {
        private CDusuario objetoCD = new CDusuario();
        public DataTable MostrarUsuario()
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Mostrar();
            return tabla;
        }
        public void InsertarUsuario(string usuario, string clave)
        {
            objetoCD.Insertar(usuario, clave);
        }

        public void EditarUsuario(string usuario, string clave, string idusuario)
        {
            objetoCD.Editar(usuario, clave, Convert.ToInt32(idusuario));
        }

        public void EliminarUsuario(string idusuario)
        {
            objetoCD.Eliminar(Convert.ToInt32(idusuario));
        }

        public DataTable BuscarUsuario(string buscar)
        {
            DataTable tabla = new DataTable();
            tabla = objetoCD.Buscar(buscar);
            return tabla;
        }

    }
}
