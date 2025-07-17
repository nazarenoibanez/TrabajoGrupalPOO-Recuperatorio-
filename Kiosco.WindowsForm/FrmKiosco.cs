using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Kiosco.Entidades;
using Kiosco.Datos.RepoWindows;
using Kiosco.Windows.GridHelper;
using System.ComponentModel.DataAnnotations;

namespace Kiosco.WindowsForm
{
    public partial class FrmKiosco : Form
    {
        private RepositorioProductosOperadores _repositorio;
        private List<Producto> productos = null!;
        public FrmKiosco()
        {
            InitializeComponent();
            _repositorio = new RepositorioProductosOperadores();

        }

        private void KioscoFrm_Load(object sender, EventArgs e)
        {
            productos = _repositorio.ObtenerTodos();
            CargarTiposProductoFiltro();
            MostrarDatosEnGrilla();
            LblStatus.Text = $"Mostrando {productos.Count} productos.";
        }
        private void CargarTiposProductoFiltro()
        {
            CboTiposProductosFiltro.Items.Add("Seleccione");
            CboTiposProductosFiltro.Items.Add("Cigarrillo");
            CboTiposProductosFiltro.Items.Add("Golosina");
            CboTiposProductosFiltro.Items.Add("Bebida");
            CboTiposProductosFiltro.Items.Add("Revista");
            CboTiposProductosFiltro.SelectedIndex = 0;
        }
        private void MostrarDatosEnGrilla()
        {
            GridHelper.LimpiarGrilla(dgvDatos);
            foreach (var producto in productos)
            {
                DataGridViewRow fila = GridHelper.ConstruirFila(dgvDatos);
                GridHelper.SetearFila(fila, producto);
                GridHelper.AgregarFila(fila, dgvDatos);
            }
        }

        private void CboTiposProductosFiltro_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (CboTiposProductosFiltro.SelectedIndex == 0) return;

            string tipo = CboTiposProductosFiltro.SelectedItem?.ToString()!;
            productos = _repositorio.ObtenerTodos(tipo);
            MostrarDatosEnGrilla();
            LblStatus.Text = $"Mostrando {productos.Count} productos de tipo {tipo}.";
        }

        private void TsbActualizar_Click(object sender, EventArgs e)
        {
            productos = _repositorio.ObtenerTodos();
            MostrarDatosEnGrilla();
            LblStatus.Text = $"Mostrando {productos.Count} productos.";
        }

        private void TsbCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void TsbNuevo_Click(object sender, EventArgs e)
        {
            using (FrmKioscoAE frm = new FrmKioscoAE())
            {
                DialogResult dr = frm.ShowDialog(this);

                if (dr == DialogResult.Cancel)
                {
                    LblStatus.Text = "Alta cancelada.";
                    return;
                }

                Producto? producto = frm.GetProducto();
                if (producto == null) return;

                try
                {
                    _repositorio.Agregar(producto);
                    DataGridViewRow r = GridHelper.ConstruirFila(dgvDatos);
                    GridHelper.SetearFila(r, producto);
                    GridHelper.AgregarFila(r, dgvDatos);
                    LblStatus.Text = "Producto agregado exitosamente.";
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LblStatus.Text = "Error al agregar el producto.";
                }
            }
        }
    }
}
