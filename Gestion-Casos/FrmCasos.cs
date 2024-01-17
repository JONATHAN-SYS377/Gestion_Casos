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

namespace Gestion_Casos.Casos
{
    public partial class FrmCasos : Form
    {
        bool revision = false;
        bool PorEntregar = false;
        bool Entregado = false;
        bool estado = false;
        bool estado2 = false;
        bool estado3 = false;






        public FrmCasos()
        {
            InitializeComponent();
            DtpFecha.Value = DateTime.Now;

        }

        private void TxtBuscar_TextChanged(object sender, EventArgs e)
        {
            if (TxtBuscar.Text != string.Empty)
            {
                // Aca puedes hacer la consulta a la base de datos si retorna lo encontrado entonces que se active el primer tab o todos segun el estado que tengan
                // si hay datos por revisar

                estado = true;
                if (estado)
                {
                    Metodos_Funciones.ActivarRevision(PanelRevision, BtnRevision, PanelContenedorTabControl);

                    // si ya se ha realizado la revision se puede acceder a por entregar
                    estado2 = true;
                    if (estado2)
                    {
                        Metodos_Funciones.ActivarBtnPorEntregar(BtnPorEntregar);


                        // si ya estan las anteriores 2 opciones entonces se habilida entregar
                        estado3 = true;
                        if (estado3)
                        {
                            Metodos_Funciones.ActivarBtnEntregado(BtnEntregado);
                        }
                        else
                        {

                            return;
                        }
                    }
                    else
                    {
                        return;
                    }
                }
                else
                {
                    return;
                }
            }
            else
            {
                Metodos_Funciones.InhabilitarTab(PanelRevision, BtnRevision, PanelPorEntregar, BtnPorEntregar, PanelEntregado, BtnEntregado);
            }
        }



        private void BtnRevision_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.mostrar_ocultar_panel(PanelRevision, PanelPorEntregar, PanelEntregado, BtnRevision, BtnPorEntregar, BtnEntregado, PanelContenedorTabControl);
        }

        private void BtnPorEntregar_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.mostrar_ocultar_panel(PanelPorEntregar, PanelRevision, PanelEntregado, BtnPorEntregar, BtnRevision, BtnEntregado, PanelContenedorTabControl);
        }

        private void BtnEntregado_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.mostrar_ocultar_panel(PanelEntregado, PanelPorEntregar, PanelRevision, BtnEntregado, BtnRevision, BtnPorEntregar, PanelContenedorTabControl);
        }

        private void BtnNUevo_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.ActivarControles(PanelDatosPrincipales);
            Metodos_Funciones.LimpiarControles(PanelDatosPrincipales);
          
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.ActivarControles(PanelDatosPrincipales);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Metodos_Funciones.LimpiarControles(PanelDatosPrincipales);
        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoVacios.ValidarCamposVaciosPanel(PanelDatosPrincipales))
            {
                Metodos_Funciones.ActivarRevision(PanelRevision, BtnRevision, PanelContenedorTabControl);
            }
            else
            {
                return;
            }
        }

        private void BtnGuardar_Click(object sender, EventArgs e)
        {

        }

        private void BtnEntregaPendiente_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoVacios.ValidarCamposVaciosPanel(PanelTab1))
            {
                // Guardar en la Base
            }
            else
            {
                return;
            }

        }

        private void BtnGuardarObservacion_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoVacios.ValidarCamposVaciosPanel(PanelTabComentarios))
            {
                // Guardar comentarios en la Base
            }
            else
            {
                return;
            }
        }

        private void BtnModificar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoVacios.ValidarCamposVaciosPanel(PanelControlesPorEntregar))
            {
                // Modificar en la base
            }
            else
            {
                return;
            }
        }

        private void BtnGuardarPorEntregar_Click(object sender, EventArgs e)
        {
            if (!ValidarCampoVacios.ValidarCamposVaciosPanel(PanelControlesPorEntregar))
            {
                // Guardar  en la Base
            }
            else
            {
                return;
            }
        }

        private void BtnBloquear_Click_1(object sender, EventArgs e)
        {
            Metodos_Funciones.BloquearControles(PanelDatosPrincipales);

        }
    }
}
