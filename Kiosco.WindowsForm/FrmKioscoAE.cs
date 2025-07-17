using Kiosco.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public Producto? GetProducto()
        {
            return producto;
        }
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

                txtCodigo.Enabled = false; // El código no se debe cambiar en edición
                cboTipoProducto.Enabled = false; // El tipo de producto no se cambia en edición

            }
            else
            {
                this.Text = "Nuevo Producto";
                nudStock.Value = 1;

            }
        }

        // --- Método CargarTiposProducto modificado para usar la enumeración ---
        public void CargarTiposProducto()
        {
            cboTipoProducto.DataSource = Enum.GetValues(typeof(TipoProducto));
        }

        private void CargarDatosProducto(Producto? producto)
        {
            if (producto is not null)
            {
                txtCodigo.Text = producto.codigo;
                txtNombre.Text = producto.Nombre;
                txtPrecioBase.Text = producto.PrecioBase.ToString();
                nudStock.Value = producto.Stock;

                // Determinar el tipo del producto
                TipoProducto tipoSeleccionado = TipoProducto.Bebida; // Valor por defecto

                if (producto is Bebida)
                    tipoSeleccionado = TipoProducto.Bebida;
                else if (producto is Cigarrillo)
                    tipoSeleccionado = TipoProducto.Cigarrillo;
                else if (producto is Golosina)
                    tipoSeleccionado = TipoProducto.Golosina;
                else if (producto is Revista)
                    tipoSeleccionado = TipoProducto.Revista;



                cboTipoProducto.SelectedItem = tipoSeleccionado;
            }
        }

        private void BtnOK_Click(object sender, EventArgs e)
        {
            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            decimal precioBase;
            int stock = (int)nudStock.Value;
            var marcaB = (MarcaB)cboMarca.SelectedItem!;
            var marcaGolosina = (marcaGolosina)cboMarca.SelectedItem!;
            var marcaRevista = (MarcaRevista)cboMarca.SelectedItem!;
            var marcaCigarrillo = (MarcaCigarrillo)cboMarca.SelectedItem!;
            var fechaVencimiento = (FechaVencimiento)cboMarca.SelectedItem!;





            var tipoSeleccionado = (TipoProducto)cboTipoProducto.SelectedItem!;

            if (!decimal.TryParse(txtPrecioBase.Text, out precioBase))
            {
                MessageBox.Show("El precio base debe ser un número válido.", "Error de Formato", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            switch (tipoSeleccionado)
            {
                case TipoProducto.Golosina:
                    producto = new Bebida()
                    {
                        MarcaGolosina = marcaGolosina,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,

                    };
                    break;
                case TipoProducto.Revista:
                    producto = new Bebida()
                    {
                        MarcaRevista = marcaRevista,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,

                    };
                    break;
                case TipoProducto.Bebida:
                    producto = new Bebida()
                    {
                        MarcaB = marcaB,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,

                    };
                    break;
                case TipoProducto.Cigarrillo:
                    producto = new Cigarrillo()
                    {
                        MarcaCigarillo = marcaCigarrillo,
                        Nombre = nombre,
                        PrecioBase = precioBase,
                        Stock = stock,
                        esImportado = chkEsImportado.Checked

                    };
                    break;
                default:
                    MessageBox.Show("Debe seleccionar un tipo de producto.", "Error de Selección", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
            }

            var validationContext = new ValidationContext(producto);
            var errores = new List<ValidationResult>();
            if (!Validator.TryValidateObject(producto, validationContext, errores, true))
            {
                MostrarErrores(errores);
                return;
            }
            DialogResult = DialogResult.OK;

        }
        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;

        }

        private void MostrarErrores(List<ValidationResult> errores)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("Errores en los datos comunes:");
            foreach (var error in errores)
            {
                sb.AppendLine($"- {error.ErrorMessage}");
            }
            MessageBox.Show(sb.ToString(), "Errores de Validación", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void CboTipoProducto_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cboTipoProducto.SelectedItem is TipoProducto tipo)
            {
                switch (tipo)
                {
                    case TipoProducto.Cigarrillo:
                        MostrarControles(false, false, false, false);
                        break;

                    case TipoProducto.Golosina:
                        MostrarControles(true, false, true, false);
                        break;

                    case TipoProducto.Revista:
                        MostrarControles(false, false, false, true);
                        break;

                    case TipoProducto.Bebida:
                        MostrarControles(false, true, false, false);
                        break;
                }
            }
        }
        private void MostrarControles(bool fechaVencimiento, bool esAlcoholica, bool esImportado, bool tienePoster)
        {
            dtpFechaVencimiento.Visible = fechaVencimiento;

            dtpFechaVencimiento.Visible = fechaVencimiento;

            chkTieneAlcohol.Visible = esAlcoholica;

            chkEsImportado.Visible = esImportado;

            chkTienePoster.Visible = tienePoster;

        }

    }
}
