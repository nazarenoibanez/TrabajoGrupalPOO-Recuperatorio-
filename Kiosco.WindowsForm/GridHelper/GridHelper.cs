using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Kiosco.Entidades;
using System.Windows.Forms;

namespace Kiosco.Windows.GridHelper
{
    public static class GridHelper
    {
        /// <summary>
        /// Limpia todas las filas de la grilla.
        /// </summary>
        public static void LimpiarGrilla(DataGridView grid)
        {
            grid.Rows.Clear();
        }

        /// <summary>
        /// Construye una nueva fila para la grilla.
        /// </summary>
        public static DataGridViewRow ConstruirFila(DataGridView grid)
        {
            DataGridViewRow fila = new DataGridViewRow();
            fila.CreateCells(grid);
            return fila;
        }

        /// <summary>
        /// Setea los valores de una fila con los datos del producto.
        /// </summary>
        public static void SetearFila(DataGridViewRow fila, Producto producto)
        {
            fila.Cells[0].Value = producto.codigo;
            fila.Cells[1].Value = producto.Nombre;
            fila.Cells[2].Value = producto.calcularPrecioFinal().ToString("C");
            fila.Cells[3].Value = producto.Stock;
            fila.Cells[4].Value = producto.GetType().Name;

            fila.Tag = producto;
        }

        /// <summary>
        /// Agrega una fila a la grilla.
        /// </summary>
        public static void AgregarFila(DataGridViewRow fila, DataGridView grid)
        {
            grid.Rows.Add(fila);
        }

        /// <summary>
        /// Quita una fila de la grilla.
        /// </summary>
        public static void QuitarFila(DataGridViewRow fila, DataGridView grid)
        {
            grid.Rows.Remove(fila);
        }
    }
}
