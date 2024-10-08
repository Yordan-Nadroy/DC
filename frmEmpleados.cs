using pjGestionEmpleados.Datos;
using pjGestionEmpleados.Datos.pjGestionEmpleados.Datos;
using pjGestionEmpleados.Entidades;
using pjGestionEmpleados.Presentacion.Reportes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjGestionEmpleados.Presentacion
{
    public partial class frmEmpleados : Form
    {
        public frmEmpleados()
        {
            InitializeComponent();
        }
        #region "Variables"

        int iCodigoEmpleado = 0;
        bool bEstadoGuardar = true;

        #endregion
        //fin 

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        //metodos
        private void CargarEmpleados(string cBusqueda)
        {
            try
            {
                D_Empleados Datos = new D_Empleados();
                dgvLista.DataSource = Datos.Listar_Empleados(cBusqueda);
                FormatoListaEmpleados();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void FormatoListaEmpleados()
        {
            try
            {
                for (int i = 0; i < dgvLista.Columns.Count; i++)
                {
                    switch (i)
                    {
                        case 0:
                            dgvLista.Columns[i].Width = 45;
                            break;
                        case 1:
                            dgvLista.Columns[i].Width = 160;
                            break;
                        case 2:
                            dgvLista.Columns[i].Width = 160;
                            break;
                        case 5:
                            dgvLista.Columns[i].Width = 250;
                            break;
                        case 7:
                            dgvLista.Columns[i].Width = 260;
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al formatear lista de empleados: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarDepartamentos()
        {
            try
            {
                D_Departamentos Datos = new D_Departamentos();
                DataTable departamentos = Datos.Listar_Departamentos();
                if (departamentos != null)
                {
                    cmbDepartamento.DataSource = departamentos;
                    cmbDepartamento.ValueMember = "id_departamento";
                    cmbDepartamento.DisplayMember = "nombre_departamento";
                    cmbDepartamento.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se encontraron departamentos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar departamentos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CargarCargos()
        {
            try
            {
                D_Cargos Datos = new D_Cargos();
                DataTable cargos = Datos.Listar_Cargos();
                if (cargos != null)
                {
                    cmbCargo.DataSource = cargos;
                    cmbCargo.ValueMember = "id_cargo";
                    cmbCargo.DisplayMember = "nombre_cargo";
                    cmbCargo.SelectedIndex = -1;
                }
                else
                {
                    MessageBox.Show("No se encontraron cargos", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar cargos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarTextos(bool bEstado)
        {
            try
            {
                txtNombre.Enabled = bEstado;
                txtDireccion.Enabled = bEstado;
                txtTelefono.Enabled = bEstado;
                txtSalario.Enabled = bEstado;
                cmbDepartamento.Enabled = bEstado;
                cmbCargo.Enabled = bEstado;
                dtpFechaNacimiento.Enabled = bEstado;

                if (txtBuscar != null)
                {
                    txtBuscar.Enabled = !bEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al activar textos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ActivarBotones(bool bEstado)
        {
            try
            {
                btnAgregar.Enabled = bEstado;
                btnActualizar.Enabled = bEstado;
                btnEliminar.Enabled = bEstado;
                btnReporte.Enabled = bEstado;

                if (btnGuardar != null)
                {
                    btnGuardar.Visible = !bEstado;
                }

                if (btnCancelar != null)
                {
                    btnCancelar.Visible = !bEstado;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al activar botones: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SeleccionarEmpleado()
        {
            try
            {
                if (dgvLista.CurrentRow != null)
                {
                    iCodigoEmpleado = Convert.ToInt32(dgvLista.CurrentRow.Cells["ID"].Value);

                    txtNombre.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Nombre"].Value);
                    txtDireccion.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Direccion"].Value);
                    txtTelefono.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Telefono"].Value);
                    txtSalario.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Salario"].Value);
                    cmbDepartamento.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Departamento"].Value);
                    cmbCargo.Text = Convert.ToString(dgvLista.CurrentRow.Cells["Cargo"].Value);
                    dtpFechaNacimiento.Value = Convert.ToDateTime(dgvLista.CurrentRow.Cells["Fecha_Nacimiento"].Value);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al seleccionar empleado: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Limpiar()
        {
            txtNombre.Clear();
            txtDireccion.Clear();
            txtTelefono.Clear();
            txtSalario.Clear();
            txtBuscar.Clear();

            cmbDepartamento.SelectedIndex = -1;
            cmbCargo.SelectedIndex = -1;

            dtpFechaNacimiento.Value = DateTime.Now.AddYears(-18);

            iCodigoEmpleado = 0;
        }

        private void GuardarEmpleados()
        {
            E_Empleado empleado = new E_Empleado();

            empleado.Nombre_Empleado = txtNombre.Text;
            empleado.Direccion_Empleado = txtDireccion.Text;
            empleado.Telefono_Empleado = txtTelefono.Text;

            // Validación de salario
            if (decimal.TryParse(txtSalario.Text, out decimal salario))
            {
                empleado.Salario_Empleado = salario;
            }
            else
            {
                MessageBox.Show("El salario debe ser un número decimal", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina el método si el salario no es válido.
            }

            // Validación de fecha de nacimiento
            empleado.Fecha_Nacimiento_Empleado = dtpFechaNacimiento.Value;

            // Validación de departamento
            if (int.TryParse(cmbDepartamento.SelectedValue?.ToString(), out int idDepartamento))
            {
                empleado.ID_Departamento = idDepartamento;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un departamento válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Termina el método si el departamento no es válido.
            }

            // Validación de cargo
            if (int.TryParse(cmbCargo.SelectedValue?.ToString(), out int idCargo))
            {
                empleado.ID_Cargo = idCargo;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cargo válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina el método si el cargo no es válido.
            }

            // Guardar datos del empleado
            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Guardar_Empleado(empleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Guardados Correctamente", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion De Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ActualizarEmpleados()
        {
            E_Empleado empleado = new E_Empleado();

            empleado.ID_Empleado = iCodigoEmpleado;
            empleado.Nombre_Empleado = txtNombre.Text;
            empleado.Direccion_Empleado = txtDireccion.Text;
            empleado.Telefono_Empleado = txtTelefono.Text;
            empleado.Salario_Empleado = Convert.ToDecimal(txtSalario.Text);
            empleado.Fecha_Nacimiento_Empleado = dtpFechaNacimiento.Value;

            // Validación de departamento
            if (int.TryParse(cmbDepartamento.SelectedValue?.ToString(), out int idDepartamento))
            {
                empleado.ID_Departamento = idDepartamento;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un departamento válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return; // Termina el método si el departamento no es válido.
            }

            // Validación de cargo
            if (int.TryParse(cmbCargo.SelectedValue?.ToString(), out int idCargo))
            {
                empleado.ID_Cargo = idCargo;
            }
            else
            {
                MessageBox.Show("Por favor, seleccione un cargo válido", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Termina el método si el cargo no es válido.
            }

            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Actualizar_Empleado(empleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Datos Actualizados Correctamente", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion De Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void DesactivarEmpleados(int iCodigoEmpleado)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Por favor, seleccione un empleado para desactivar", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            D_Empleados Datos = new D_Empleados();
            string respuesta = Datos.Desactivar_Empleado(iCodigoEmpleado);

            if (respuesta == "OK")
            {
                CargarEmpleados("%");
                Limpiar();
                ActivarTextos(false);
                ActivarBotones(true);

                MessageBox.Show("Registro Eliminado Correctamente", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show(respuesta, "Sistema Gestion De Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool validarTextos()
        {
            bool hayTextosVacios = false;
            if (string.IsNullOrWhiteSpace(txtNombre.Text)) hayTextosVacios = true;
            if (string.IsNullOrWhiteSpace(txtTelefono.Text)) hayTextosVacios = true;
            if (string.IsNullOrWhiteSpace(txtSalario.Text)) hayTextosVacios = true;

            return hayTextosVacios;
        }

        private void frmEmpleados_Load(object sender, EventArgs e)
        {
            CargarEmpleados("%");
            CargarDepartamentos();
            CargarCargos();

            if (dgvLista.Rows.Count == 0)
            {
                MessageBox.Show("No hay empleados que coincidan con el criterio de búsqueda", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void txtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtBuscar.Text))
            {
                CargarEmpleados(txtBuscar.Text);
            }
            else
            {
                MessageBox.Show("Por favor, ingrese un texto de búsqueda", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        /*  private void btnBuscar_Click(object sender, EventArgs e)
          {
              CargarEmpleados(txtBuscar.Text);

          }*/

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            ActivarTextos(true);
            ActivarBotones(false);
            Limpiar();

            txtNombre.Select();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            ActivarTextos(false);
            ActivarBotones(true);

            Limpiar();
        }


        private void dgvLista_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                ActivarTextos(true);
                ActivarBotones(false);

                txtNombre.Select();
            }
        }

        private void btnGuardar_Click(object sender, EventArgs e)
        {
            if (validarTextos())
            {
                MessageBox.Show("Hay Campos vacios debes llena todos los campos (*) obligatorios", "Sistema Gestion de Empleados"
                    , MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
            else
            {
                if (bEstadoGuardar)
                {
                    GuardarEmpleados();
                }
                else
                {
                    ActualizarEmpleados();
                }
            }
        }


        private void btnAgregar_Click_1(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;
            
            ActivarTextos(true);
            ActivarBotones(false);
            Limpiar();

            txtNombre.Select();

        }

        private void btnCancelar_Click_1(object sender, EventArgs e)
        {
            bEstadoGuardar = true;
            iCodigoEmpleado = 0;

            ActivarTextos(false);
            ActivarBotones(true);

            Limpiar();
        }

    

        private void btnActualizar_Click_1(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                bEstadoGuardar = false;

                ActivarTextos(true);
                ActivarBotones(false);

                txtNombre.Select();
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            if (iCodigoEmpleado == 0)
            {
                MessageBox.Show("Selecciona un Registro", "Sistema de Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                DialogResult resultado = MessageBox.Show("¿Estas seguro de eliminar este registro?", "Sistema de Gestion de Empleados", MessageBoxButtons.YesNo, MessageBoxIcon.Information);

                if (resultado == DialogResult.Yes)
                {
                    DesactivarEmpleados(iCodigoEmpleado);
                    if (iCodigoEmpleado == 0)
                    {
                        MessageBox.Show("Empleado desactivado correctamente", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Error al desactivar empleado", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnReporte_Click(object sender, EventArgs e)
        {
            frmReporteEmpleados formReporteEmpleados = new frmReporteEmpleados();
            if (formReporteEmpleados != null)
            {
                formReporteEmpleados.txtFiltrar.Text = txtBuscar.Text;
                formReporteEmpleados.ShowDialog();
            }
            else
            {
                MessageBox.Show("Error al crear formulario de reporte", "Sistema Gestion de Empleados", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void cmbCargo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void btnSalir_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void dgvLista_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            SeleccionarEmpleado();
        }

        private void txtSalario_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
