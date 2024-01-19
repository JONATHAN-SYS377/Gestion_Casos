using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Casos.Parametros
{
    public partial class FrmUsuarios : Form
    {
        private int indiceActual = -1;

        private void SeleccionarFila(int nuevoIndice)
        {
            if (DgvUsuarios.Rows.Count > 0)
            {
                // Desmarca la fila actual si está seleccionada
                if (indiceActual != -1)
                {
                    DgvUsuarios.Rows[indiceActual].Selected = false;
                }

                // Establece el índiceActual en el nuevo índice
                indiceActual = nuevoIndice;

                // Marca la fila correspondiente al nuevo índice
                DgvUsuarios.Rows[indiceActual].Selected = true;
            }
        }
        public FrmUsuarios()
        {
            InitializeComponent();
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnAdelante_Click(object sender, EventArgs e)
        {
            // Avanza al índice siguiente
            int nuevoIndice = (indiceActual + 1) % DgvUsuarios.Rows.Count;
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlFinal_Click(object sender, EventArgs e)
        {
            SeleccionarFila(DgvUsuarios.Rows.Count - 1);

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            // Retrocede al índice anterior
            int nuevoIndice = (indiceActual - 1 + DgvUsuarios.Rows.Count) % DgvUsuarios.Rows.Count;
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlInicio_Click(object sender, EventArgs e)
        {
            SeleccionarFila(0);
        }
    }
}
