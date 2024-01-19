using Gestion_Casos.Validaciones_Y_Metodos;
using Guna.UI2.WinForms;
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
    public partial class FrmInstituciones_ : Form
    {
        private int indiceActual = -1;

        private void SeleccionarFila(int nuevoIndice)
        {
            if (DgvInstituciones.Rows.Count > 0)
            {
                // Desmarca la fila actual si está seleccionada
                if (indiceActual != -1)
                {
                    DgvInstituciones.Rows[indiceActual].Selected = false;
                }

                // Establece el índiceActual en el nuevo índice
                indiceActual = nuevoIndice;

                // Marca la fila correspondiente al nuevo índice
                DgvInstituciones.Rows[indiceActual].Selected = true;
            }
        }
        public FrmInstituciones_()
        {
            InitializeComponent();
            DgvInstituciones.Rows.Add("jonathan", "Sequeira", "Cespedes");
            DgvInstituciones.Rows.Add("Axell Joao", "Sequeira", "Ocampo");
            DgvInstituciones.Rows.Add("Axell Joao", "Sequeira", "Ocampo");
            DgvInstituciones.Rows.Add("Axell Joao", "Sequeira", "Ocampo");
            DgvInstituciones.Rows.Add("Axell Joao", "Sequeira", "Ocampo");

        }

        private void BtnAdelante_Click(object sender, EventArgs e)
        {
            // Avanza al índice siguiente
            int nuevoIndice = (indiceActual + 1) % DgvInstituciones.Rows.Count;
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlFinal_Click(object sender, EventArgs e)
        {
            SeleccionarFila(DgvInstituciones.Rows.Count - 1);
        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            // Retrocede al índice anterior
            int nuevoIndice = (indiceActual - 1 + DgvInstituciones.Rows.Count) % DgvInstituciones.Rows.Count;
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlInicio_Click(object sender, EventArgs e)
        {
            SeleccionarFila(0);
        }
    }
}
