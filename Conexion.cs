using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Data.MySqlClient;

namespace pjGestionEmpleados.Datos
{
    public class Conexion
    {
        private string Base;
        private string Servidor;
        private string Usuario;
        private string Clave;
        private string Puerto;
        private static Conexion Con = null;

        //constructor

        private Conexion()
        {
            this.Servidor = "localhost";
            this.Base = "bd_gestion_empleados";
            this.Usuario = "root";
            this.Clave = "12345";
            this.Puerto = "3306";
        }

        public MySqlConnection CrearConexion()
        {
            MySqlConnection Cadena = new MySqlConnection();
            try
            {
                Cadena.ConnectionString = "Server=" + this.Servidor +
                                           "; Port=" + this.Puerto +
                                           "; Database=" + this.Base +
                                           "; User Id=" + this.Usuario +
                                           "; Password=" + this.Clave;

            }
            catch (Exception ex)
            {
                Cadena = null;
                throw ex;
            }
            return Cadena;
        }

        public static Conexion CrearInstancia()
        {
            if (Con == null)
            {
                Con = new Conexion();
            }
            return Con;
        }
    }
}
