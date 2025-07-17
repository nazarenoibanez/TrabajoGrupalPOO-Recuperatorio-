namespace Kiosco.WindowsForm
{
    partial class FrmKioscoAE
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
            components = new System.ComponentModel.Container();
            lblCodigo = new Label();
            lblNombre = new Label();
            lblPrecioBase = new Label();
            lblStock = new Label();
            lblTipoProducto = new Label();
            txtCodigo = new TextBox();
            txtNombre = new TextBox();
            txtPrecioBase = new TextBox();
            btnAceptar = new Button();
            btnCancelar = new Button();
            errorProvider1 = new ErrorProvider(components);
            nudStock = new NumericUpDown();
            chkTienePoster = new CheckBox();
            chkTieneAlcohol = new CheckBox();
            chkEsImportado = new CheckBox();
            dtpFechaVencimiento = new DateTimePicker();
            label1 = new Label();
            dtpFechaIngreso = new DateTimePicker();
            label2 = new Label();
            lblMarca = new Label();
            cboMarca = new ComboBox();
            cboTipoProducto = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).BeginInit();
            SuspendLayout();
            // 
            // lblCodigo
            // 
            lblCodigo.AutoSize = true;
            lblCodigo.Location = new Point(26, 96);
            lblCodigo.Name = "lblCodigo";
            lblCodigo.Size = new Size(49, 15);
            lblCodigo.TabIndex = 0;
            lblCodigo.Text = "Codigo:";
            // 
            // lblNombre
            // 
            lblNombre.AutoSize = true;
            lblNombre.Location = new Point(26, 129);
            lblNombre.Name = "lblNombre";
            lblNombre.Size = new Size(54, 15);
            lblNombre.TabIndex = 1;
            lblNombre.Text = "Nombre:";
            // 
            // lblPrecioBase
            // 
            lblPrecioBase.AutoSize = true;
            lblPrecioBase.Location = new Point(26, 168);
            lblPrecioBase.Name = "lblPrecioBase";
            lblPrecioBase.Size = new Size(70, 15);
            lblPrecioBase.TabIndex = 2;
            lblPrecioBase.Text = "Precio base:";
            // 
            // lblStock
            // 
            lblStock.AutoSize = true;
            lblStock.Location = new Point(26, 225);
            lblStock.Name = "lblStock";
            lblStock.Size = new Size(39, 15);
            lblStock.TabIndex = 3;
            lblStock.Text = "Stock:";
            // 
            // lblTipoProducto
            // 
            lblTipoProducto.AutoSize = true;
            lblTipoProducto.Location = new Point(26, 200);
            lblTipoProducto.Name = "lblTipoProducto";
            lblTipoProducto.Size = new Size(102, 15);
            lblTipoProducto.TabIndex = 4;
            lblTipoProducto.Text = "Tipo de producto:";
            // 
            // txtCodigo
            // 
            txtCodigo.Location = new Point(134, 93);
            txtCodigo.Name = "txtCodigo";
            txtCodigo.Size = new Size(231, 23);
            txtCodigo.TabIndex = 5;
            // 
            // txtNombre
            // 
            txtNombre.Location = new Point(134, 129);
            txtNombre.Name = "txtNombre";
            txtNombre.Size = new Size(408, 23);
            txtNombre.TabIndex = 6;
            // 
            // txtPrecioBase
            // 
            txtPrecioBase.Location = new Point(134, 165);
            txtPrecioBase.Name = "txtPrecioBase";
            txtPrecioBase.Size = new Size(100, 23);
            txtPrecioBase.TabIndex = 7;
            // 
            // btnAceptar
            // 
            btnAceptar.Location = new Point(81, 353);
            btnAceptar.Name = "btnAceptar";
            btnAceptar.Size = new Size(75, 23);
            btnAceptar.TabIndex = 11;
            btnAceptar.Text = "Aceptar";
            btnAceptar.UseVisualStyleBackColor = true;
            // 
            // btnCancelar
            // 
            btnCancelar.Location = new Point(304, 353);
            btnCancelar.Name = "btnCancelar";
            btnCancelar.Size = new Size(75, 23);
            btnCancelar.TabIndex = 12;
            btnCancelar.Text = "Cancelar";
            btnCancelar.UseVisualStyleBackColor = true;
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // nudStock
            // 
            nudStock.Location = new Point(134, 223);
            nudStock.Name = "nudStock";
            nudStock.Size = new Size(120, 23);
            nudStock.TabIndex = 13;
            // 
            // chkTienePoster
            // 
            chkTienePoster.AutoSize = true;
            chkTienePoster.Location = new Point(162, 311);
            chkTienePoster.Name = "chkTienePoster";
            chkTienePoster.Size = new Size(101, 19);
            chkTienePoster.TabIndex = 14;
            chkTienePoster.Text = "¿Tiene Poster?";
            chkTienePoster.UseVisualStyleBackColor = true;
            // 
            // chkTieneAlcohol
            // 
            chkTieneAlcohol.AutoSize = true;
            chkTieneAlcohol.Location = new Point(47, 311);
            chkTieneAlcohol.Name = "chkTieneAlcohol";
            chkTieneAlcohol.Size = new Size(109, 19);
            chkTieneAlcohol.TabIndex = 15;
            chkTieneAlcohol.Text = "¿Tiene Alcohol?";
            chkTieneAlcohol.UseVisualStyleBackColor = true;
            // 
            // chkEsImportado
            // 
            chkEsImportado.AutoSize = true;
            chkEsImportado.Location = new Point(269, 311);
            chkEsImportado.Name = "chkEsImportado";
            chkEsImportado.Size = new Size(106, 19);
            chkEsImportado.TabIndex = 16;
            chkEsImportado.Text = "¿Es Importado?";
            chkEsImportado.UseVisualStyleBackColor = true;
            // 
            // dtpFechaVencimiento
            // 
            dtpFechaVencimiento.Location = new Point(375, 162);
            dtpFechaVencimiento.Name = "dtpFechaVencimiento";
            dtpFechaVencimiento.Size = new Size(200, 23);
            dtpFechaVencimiento.TabIndex = 17;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(289, 165);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 18;
            label1.Text = "Fecha Vto";
            // 
            // dtpFechaIngreso
            // 
            dtpFechaIngreso.Location = new Point(375, 191);
            dtpFechaIngreso.Name = "dtpFechaIngreso";
            dtpFechaIngreso.Size = new Size(200, 23);
            dtpFechaIngreso.TabIndex = 19;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(289, 191);
            label2.Name = "label2";
            label2.Size = new Size(80, 15);
            label2.TabIndex = 20;
            label2.Text = "Fecha Ingreso";
            // 
            // lblMarca
            // 
            lblMarca.AutoSize = true;
            lblMarca.Location = new Point(26, 258);
            lblMarca.Name = "lblMarca";
            lblMarca.Size = new Size(40, 15);
            lblMarca.TabIndex = 21;
            lblMarca.Text = "Marca";
            // 
            // cboMarca
            // 
            cboMarca.FormattingEnabled = true;
            cboMarca.Location = new Point(133, 255);
            cboMarca.Name = "cboMarca";
            cboMarca.Size = new Size(121, 23);
            cboMarca.TabIndex = 22;
            // 
            // cboTipoProducto
            // 
            cboTipoProducto.FormattingEnabled = true;
            cboTipoProducto.Location = new Point(133, 194);
            cboTipoProducto.Name = "cboTipoProducto";
            cboTipoProducto.Size = new Size(121, 23);
            cboTipoProducto.TabIndex = 23;
            // 
            // FrmKioscoAE
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(cboTipoProducto);
            Controls.Add(cboMarca);
            Controls.Add(lblMarca);
            Controls.Add(label2);
            Controls.Add(dtpFechaIngreso);
            Controls.Add(label1);
            Controls.Add(dtpFechaVencimiento);
            Controls.Add(chkEsImportado);
            Controls.Add(chkTieneAlcohol);
            Controls.Add(chkTienePoster);
            Controls.Add(nudStock);
            Controls.Add(btnCancelar);
            Controls.Add(btnAceptar);
            Controls.Add(txtPrecioBase);
            Controls.Add(txtNombre);
            Controls.Add(txtCodigo);
            Controls.Add(lblTipoProducto);
            Controls.Add(lblStock);
            Controls.Add(lblPrecioBase);
            Controls.Add(lblNombre);
            Controls.Add(lblCodigo);
            Name = "FrmKioscoAE";
            Text = "FrmKioscoAE";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ((System.ComponentModel.ISupportInitialize)nudStock).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblCodigo;
        private Label lblNombre;
        private Label lblPrecioBase;
        private Label lblStock;
        private Label lblTipoProducto;
        private TextBox txtCodigo;
        private TextBox txtNombre;
        private TextBox txtPrecioBase;
        private Button btnAceptar;
        private Button btnCancelar;
        private ErrorProvider errorProvider1;
        private NumericUpDown nudStock;
        private CheckBox chkTieneAlcohol;
        private CheckBox chkTienePoster;
        private CheckBox chkEsImportado;
        private Label label2;
        private DateTimePicker dtpFechaIngreso;
        private Label label1;
        private DateTimePicker dtpFechaVencimiento;
        private ComboBox cboMarca;
        private Label lblMarca;
        private ComboBox cboTipoProducto;
    }
}