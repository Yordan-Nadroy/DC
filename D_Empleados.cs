using pjGestionEmpleados.Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace pjGestionEmpleados.Datos
{
    public class D_Empleados
    {
        public DataTable Listar_Empleados(string cBusqueda)
        {
            MySqlDataReader resultado;
            DataTable tabla = new DataTable();
            MySqlConnection SqlCon = new MySqlConnection();

            try
            {
                SqlCon = Conexion.CrearInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("SP_LISTAR_EMPLEADOS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;
                comando.Parameters.Add("@cBusqueda", MySqlDbType.VarChar).Value = cBusqueda;
                SqlCon.Open();
                resultado = comando.ExecuteReader();
                tabla.Load(resultado);
                return tabla;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                throw ex;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
        }

        public string Guardar_Empleado(E_Empleado Empleado)
        {
            string respuesta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.CrearInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("SP_GUARDAR_EMPLEADOS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@cNombre", MySqlDbType.VarChar).Value = Empleado.Nombre_Empleado;

                comando.Parameters.Add("@cDireccion", MySqlDbType.VarChar).Value = Empleado.Direccion_Empleado;

                comando.Parameters.Add("@dFechaNacimiento", MySqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;

                comando.Parameters.Add("@cTelefono", MySqlDbType.VarChar).Value = Empleado.Telefono_Empleado;

                comando.Parameters.Add("@nSalario", MySqlDbType.Decimal).Value = Empleado.Salario_Empleado;

                comando.Parameters.Add("@nIdDepartamento", MySqlDbType.Int32).Value = Empleado.ID_Departamento;

                comando.Parameters.Add("@nIdCargo", MySqlDbType.Int32).Value = Empleado.ID_Cargo;

                SqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        public string Actualizar_Empleado(E_Empleado Empleado)
        {
            string respuesta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.CrearInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("SP_ACTUALIZAR_EMPLEADOS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", MySqlDbType.Int32).Value = Empleado.ID_Empleado;

                comando.Parameters.Add("@cNombre", MySqlDbType.VarChar).Value = Empleado.Nombre_Empleado;

                comando.Parameters.Add("@cDireccion", MySqlDbType.VarChar).Value = Empleado.Direccion_Empleado;

                comando.Parameters.Add("@dFechaNacimiento", MySqlDbType.Date).Value = Empleado.Fecha_Nacimiento_Empleado;

                comando.Parameters.Add("@cTelefono", MySqlDbType.VarChar).Value = Empleado.Telefono_Empleado;

                comando.Parameters.Add("@nSalario", MySqlDbType.Decimal).Value = Empleado.Salario_Empleado;

                comando.Parameters.Add("@nIdDepartamento", MySqlDbType.Int32).Value = Empleado.ID_Departamento;

                comando.Parameters.Add("@nIdCargo", MySqlDbType.Int32).Value = Empleado.ID_Cargo;

                SqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }

        public string Desactivar_Empleado(int iCodigoEmpleado)
        {
            string respuesta = "";
            MySqlConnection SqlCon = new MySqlConnection();
            try
            {
                SqlCon = Conexion.CrearInstancia().CrearConexion();
                MySqlCommand comando = new MySqlCommand("SP_DESACTIVAR_EMPLEADOS", SqlCon);
                comando.CommandType = CommandType.StoredProcedure;

                comando.Parameters.Add("@nIdEmpleado", MySqlDbType.Int32).Value = iCodigoEmpleado;

                SqlCon.Open();

                respuesta = comando.ExecuteNonQuery() >= 1 ? "OK" : "Los Datos No se pudieron Registrar";
            }
            catch (Exception ex)
            {
                respuesta = ex.Message;
            }
            finally
            {
                if (SqlCon.State == ConnectionState.Open) SqlCon.Close();
            }
            return respuesta;
        }
    }
}
