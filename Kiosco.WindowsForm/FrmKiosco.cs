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

        private void TsbEditar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para editar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvDatos.SelectedRows[0];
            Producto productoSeleccionado = (Producto)fila.Tag!;

            using (FrmKioscoAE frm = new FrmKioscoAE())
            {
                frm.SetProducto(productoSeleccionado);
                DialogResult dr = frm.ShowDialog(this);
                if (dr == DialogResult.Cancel)
                {
                    LblStatus.Text = "Edición cancelada.";
                    return;
                }

                Producto? productoEditado = frm.GetProducto();
                if (productoEditado == null) return;

                try
                {
                    _repositorio.Editar(productoEditado);
                    GridHelper.SetearFila(fila, productoEditado);
                    LblStatus.Text = "Producto editado correctamente.";
                }
                catch (ValidationException ex)
                {
                    MessageBox.Show(ex.Message, "Error de validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    LblStatus.Text = "Error al editar el producto.";
                }
            }
        }

        private void TsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0)
            {
                MessageBox.Show("Debe seleccionar un producto para eliminar.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var fila = dgvDatos.SelectedRows[0];
            Producto productoSeleccionado = (Producto)fila.Tag!;

            DialogResult dr = MessageBox.Show($"¿Está seguro que desea eliminar '{productoSeleccionado.Nombre}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (dr == DialogResult.No)
            {
                LblStatus.Text = "Eliminación cancelada.";
                return;
            }

            try
            {
                _repositorio.Eliminar(productoSeleccionado.Id);
                dgvDatos.Rows.Remove(fila);
                LblStatus.Text = "Producto eliminado correctamente.";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al intentar eliminar el producto.\n" + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                LblStatus.Text = "Error al eliminar.";
            }
        }
    }
}
