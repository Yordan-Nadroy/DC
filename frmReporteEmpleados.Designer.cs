namespace pjGestionEmpleados.Presentacion.Reportes
{
    partial class frmReporteEmpleados
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.txtFiltrar = new System.Windows.Forms.TextBox();
            this.sPLISTAREMPLEADOSBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet = new pjGestionEmpleados.Presentacion.Reportes.DataSet1();
            this.sPLISTAREMPLEADOSBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.sP_LISTAR_EMPLEADOSTableAdapter = new pjGestionEmpleados.Presentacion.Reportes.DataSet1TableAdapters.SP_LISTAR_EMPLEADOSTableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.BackColor = System.Drawing.Color.DimGray;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.sPLISTAREMPLEADOSBindingSource1;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "pjGestionEmpleados.Presentacion.Reportes.ReporteEmpleados.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1113, 705);
            this.reportViewer1.TabIndex = 0;
            // 
            // txtFiltrar
            // 
            this.txtFiltrar.Location = new System.Drawing.Point(12, 82);
            this.txtFiltrar.Name = "txtFiltrar";
            this.txtFiltrar.Size = new System.Drawing.Size(208, 22);
            this.txtFiltrar.TabIndex = 1;
            this.txtFiltrar.Visible = false;
            // 
            // sPLISTAREMPLEADOSBindingSource1
            // 
            this.sPLISTAREMPLEADOSBindingSource1.DataMember = "SP_LISTAR_EMPLEADOS";
            this.sPLISTAREMPLEADOSBindingSource1.DataSource = this.dataSet;
            // 
            // dataSet
            // 
          
            // 
            // sPLISTAREMPLEADOSBindingSource
            // 
            this.sPLISTAREMPLEADOSBindingSource.DataMember = "SP_LISTAR_EMPLEADOS";
            this.sPLISTAREMPLEADOSBindingSource.DataSource = this.dataSet;
            // 
            // sP_LISTAR_EMPLEADOSTableAdapter
            // 
         
            // 
            // frmReporteEmpleados
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1113, 705);
            this.Controls.Add(this.txtFiltrar);
            this.Controls.Add(this.reportViewer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmReporteEmpleados";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Reporte Empleados";
            this.Load += new System.EventHandler(this.frmReporteEmpleados_Load);
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPLISTAREMPLEADOSBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource sPLISTAREMPLEADOSBindingSource;
        private DataSet1 dataSet;
        private DataSet1TableAdapters.SP_LISTAR_EMPLEADOSTableAdapter sP_LISTAR_EMPLEADOSTableAdapter;
        internal System.Windows.Forms.TextBox txtFiltrar;
        private System.Windows.Forms.BindingSource sPLISTAREMPLEADOSBindingSource1;
    }
}