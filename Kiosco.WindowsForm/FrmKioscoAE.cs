using Kiosco.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Windows.Forms;

namespace Kiosco.WindowsForm
{
    public partial class FrmKioscoAE : Form
    {
        private Producto? producto;

        public FrmKioscoAE()
        {
            InitializeComponent();
        }

        public Producto? GetProducto() => producto;

        public void SetProducto(Producto? producto)
        {
            this.producto = producto;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CargarTiposProducto();
            CargarDatosProducto(producto);

            if (producto is not null)
            {
                this.Text = "Editar Producto";
                txtCodigo.Enabled = false;
                cboTipoProducto.Enabled = false;
            }
            else
            {
                this.Text = "Nuevo Producto";
                nudStock.Value = 1;
            }
        }

        private void CargarTiposProducto()
        {
            cboTipoProducto.DataSource = Enum.GetValues(typeof(TipoProducto));
        }

        private void CargarDatosProducto(Producto? producto)
        {
            if (producto is null) return;

            txtCodigo.Text = producto.codigo;
            txtNombre.Text = producto.Nombre;
            txtPrecioBase.Text = producto.PrecioBase.ToString();
            nudStock.Value = producto.Stock;
            dtpFechaVencimiento.Value = producto.FechaVto;

            if (producto is Bebida b)
            {
                cboTipoProducto.SelectedItem = TipoProducto.Bebida;
                chkTieneAlcohol.Checked = b.EsAlcoholica;
                CargarMarcas(typeof(MarcaB));
                cboMarca.SelectedItem = b.MarcaB;
            }
            else if (producto is Golosina g)
            {
                cboTipoProducto.SelectedItem = TipoProducto.Golosina;
                CargarMarcas(typeof(MarcaGolosina));
                cboMarca.SelectedItem = g.MarcaGolosina;
            }
            else if (producto is Revista r)
            {
                cboTipoProducto.SelectedItem = TipoProducto.Revista;
                chkTienePoster.Checked = r.TienePoster;
                CargarMarcas(typeof(MarcaRevista));
                cboMarca.SelectedItem = r.MarcaRevista;
            }
            else if (producto is Cigarrillo c)
            {
                cboTipoProducto.SelectedItem = TipoProducto.Cigarrillo;
                chkEsImportado.Checked = c.esImportado;
                CargarMarcas(typeof(MarcaCigarrillo));
                cboMarca.SelectedItem = c.MarcaCigarillo;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text.Trim();
            string nombre = txtNombre.Text.Trim();
            decimal precioBase;
            int stock = (int)nudStock.Value;
            DateTime fechaVto = dtpFechaVencimiento.Value;

            if (!decimal.TryParse(txtPrecioBase.Text, out precioBase))
            {
                MessageBox.Show("El precio base debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (string.IsNullOrWhiteSpace(nombre))
            {
                MessageBox.Show("Debe ingresar un nombre válido.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (cboMarca.SelectedItem is null)
            {
                MessageBox.Show("Debe seleccionar una marca.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var tipoSeleccionado = (TipoProducto)cboTipoProducto.SelectedItem!;
            switch (tipoSeleccionado)
            {
                case TipoProducto.Bebida:
                    producto = new Bebida()
                    {
                        codigo = codigo,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,
                        FechaVto = fechaVto,
                        MarcaB = (MarcaB)cboMarca.SelectedItem!,
                        EsAlcoholica = chkTieneAlcohol.Checked
                    };
                    break;

                case TipoProducto.Golosina:
                    producto = new Golosina()
                    {
                        codigo = codigo,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,
                        FechaVto = fechaVto,
                        MarcaGolosina = (MarcaGolosina)cboMarca.SelectedItem!
                    };
                    break;

                case TipoProducto.Revista:
                    producto = new Revista()
                    {
                        codigo = codigo,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,
                        FechaVto = fechaVto,
                        MarcaRevista = (MarcaRevista)cboMarca.SelectedItem!,
                        TienePoster = chkTienePoster.Checked
                    };
                    break;

                case TipoProducto.Cigarrillo:
                    producto = new Cigarrillo()
                    {
                        codigo = codigo,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,
                        FechaVto = fechaVto,
                        MarcaCigarillo = (MarcaCigarrillo)cboMarca.SelectedItem!,
                        esImportado = chkEsImportado.Checked
                    };
                    break;
            }

            var context = new ValidationContext(producto!);
            var errores = new List<ValidationResult>();
            if (!Validator.TryValidateObject(producto!, context, errores, true))
            {
                MostrarErrores(errores);
                return;
            }

            DialogResult = DialogResult.OK;
        }

        private void MostrarErrores(List<ValidationResult> errores)
        {
            StringBuilder sb = new StringBuilder("Se encontraron los siguientes errores:\n");
            foreach (var error in errores)
            {
                sb.AppendLine($"- {error.ErrorMessage}");
            }
            MessageBox.Show(sb.ToString(), "Errores de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void CboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProducto.SelectedItem is TipoProducto tipo)
            {
                switch (tipo)
                {
                    case TipoProducto.Bebida:
                        MostrarControles(esAlcoholica: true, esImportado: false, tienePoster: false, fechaVto: true);
                        CargarMarcas(typeof(MarcaB));
                        break;

                    case TipoProducto.Golosina:
                        MostrarControles(esAlcoholica: false, esImportado: false, tienePoster: false, fechaVto: true);
                        CargarMarcas(typeof(MarcaGolosina));
                        break;

                    case TipoProducto.Revista:
                        MostrarControles(esAlcoholica: false, esImportado: false, tienePoster: true, fechaVto: true);
                        CargarMarcas(typeof(MarcaRevista));
                        break;

                    case TipoProducto.Cigarrillo:
                        MostrarControles(esAlcoholica: false, esImportado: true, tienePoster: false, fechaVto: true);
                        CargarMarcas(typeof(MarcaCigarrillo));
                        break;
                }
            }
        }

        private void MostrarControles(bool esAlcoholica, bool esImportado, bool tienePoster, bool fechaVto)
        {
            chkTieneAlcohol.Visible = esAlcoholica;
            chkEsImportado.Visible = esImportado;
            chkTienePoster.Visible = tienePoster;
            dtpFechaVencimiento.Visible = fechaVto;
        }

        private void CargarMarcas(Type tipoEnum)
        {
            cboMarca.DataSource = Enum.GetValues(tipoEnum);
        }
    }
}
