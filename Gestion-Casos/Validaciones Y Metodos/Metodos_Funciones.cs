using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gestion_Casos.Validaciones_Y_Metodos
{
    public class Metodos_Funciones
    {

        /// <summary>
        /// Metodo para activar los controles
        /// </summary>
        /// <param name="panelControles">Resebe nombre del panel que contiene los controles</param>
        public static void ActivarControles(Guna2Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)control;
                    textBox.Enabled = true;
                }
                if (control is Guna2ComboBox)
                {
                    Guna2ComboBox cb = (Guna2ComboBox)control;
                    cb.Enabled = true;
                }
                if (control is Guna2DateTimePicker)
                {
                    Guna2DateTimePicker Dtp = (Guna2DateTimePicker)control;
                    Dtp.Enabled = true;
                }
            }
        }

        /// <summary>
        /// Metodo para limpiar los controles
        /// </summary>
        /// <param name="panelControles">Resebe nombre del panel que contiene los controles</param>
        public static void LimpiarControles(Guna2Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)control;
                    textBox.Clear();
                }
                if (control is Guna2ComboBox)
                {
                    Guna2ComboBox cb = (Guna2ComboBox)control;
                    cb.SelectionStart = 0;
                }
                if (control is Guna2DateTimePicker)
                {
                    Guna2DateTimePicker Dtp = (Guna2DateTimePicker)control;
                    Dtp.Value = DateTime.Now;
                }
            }
        }

        /// <summary>
        /// Metodo para activar los controles
        /// </summary>
        /// <param name="panelControles">Resebe nombre del panel que contiene los controles</param>
        public static void BloquearControles(Guna2Panel panelControles)
        {
            foreach (Control control in panelControles.Controls)
            {
                if (control is Guna2TextBox)
                {
                    Guna2TextBox textBox = (Guna2TextBox)control;
                    textBox.Enabled = false;
                }
                if (control is Guna2ComboBox)
                {
                    Guna2ComboBox cb = (Guna2ComboBox)control;
                    cb.Enabled = false;
                }
                if (control is Guna2DateTimePicker)
                {
                    Guna2DateTimePicker Dtp = (Guna2DateTimePicker)control;
                    Dtp.Enabled = false;
                }
            }
        }

        /// <summary>
        /// Metodo para realizar la activacion del BtnRevicion y el Tab Correspondiente parametros 1>PanelRevision, 2>BotonRevision y 3>PanelContenedorTabControl
        /// </summary>
        /// <param name="panelRevision"></param>
        /// <param name="buttonRevision"></param>
        /// <param name="PanelContenedorTabControl"></param>
        public static void ActivarRevision(Guna2Panel panelRevision, Guna2Button buttonRevision, Guna2Panel PanelContenedorTabControl)
        {
            buttonRevision.Enabled = true;
            panelRevision.Visible = true;
            buttonRevision.BackgroundImage = Image.FromFile(@"Resources//Boton Azul-2.png");
            PanelContenedorTabControl.AutoScroll = false;
            panelRevision.Visible = true;
            panelRevision.Dock = DockStyle.Fill;
        }

        /// <summary>
        /// Metodo para Activar el BtnPorEntregar si ya se realizaron los procesos anterior a este estado
        /// </summary>
        /// <param name="buttonPorEntregar"></param>
        public static void ActivarBtnPorEntregar( Guna2Button buttonPorEntregar)
        {
            buttonPorEntregar.Enabled = true;

        }

        /// <summary>
        /// Metodo para Activar el BtnEntregado si ya se realizaron los procesos anterior a este estado
        /// </summary>
        /// <param name="buttonEntregado"></param>
        public static void ActivarBtnEntregado(Guna2Button buttonEntregado)
        {
            buttonEntregado.Enabled = true;

        }

        /// <summary>
        /// Metodo para realizar la funcion del Tab Control resibe el primer parametros seria el panel que e quiere mostrar y 
        /// parametros 2 y 3 los paneles a ocultar, el parametro 4 seria el boton a que se deasea mostrar como activo 
        /// y los paramentros 5 y 6 los botones que no estaran activos
        /// </summary>
        /// <param name="panelactivo"></param>
        /// <param name="panelInactivo1"></param>
        /// <param name="panelInactivo2"></param>
        /// <param name="BtnActivo"></param>
        /// <param name="BtnInactivo2"></param>
        /// <param name="BtnInactivo3"></param>
        public static void mostrar_ocultar_panel(Guna2Panel panelActivo, Guna2Panel panelInactivo1, Guna2Panel panelInactivo2, Guna2Button BtnActivo, Guna2Button BtnInactivo2, Guna2Button BtnInactivo3, Guna2Panel PanelContenedorTabControl)
        {
            PanelContenedorTabControl.AutoScroll = false;
            panelActivo.Visible = true;
            panelActivo.Dock = DockStyle.Fill;
            panelInactivo1.Visible = false;
            panelInactivo2.Visible = false;
            BtnActivo.BackgroundImage = Image.FromFile(@"Resources//Boton Azul-2.png");
            BtnInactivo2.BackgroundImage = Image.FromFile(@"Resources//BotonGris-2.png");
            BtnInactivo3.BackgroundImage = Image.FromFile(@"Resources//BotonGris-2.png");

        }


        public static void InhabilitarTab(Guna2Panel panelRevision, Guna2Button buttonRevision, Guna2Panel panelPorEntregar, Guna2Button buttonPorEntregar, Guna2Panel panelEntregado, Guna2Button buttonEntregado)
        {
            panelRevision.Visible = false;
            buttonRevision.Enabled = false;
            panelPorEntregar.Visible = false;
            buttonPorEntregar.Enabled= false;
            panelEntregado.Visible = false;
            buttonEntregado.Enabled= false; 
        }
    }
}
