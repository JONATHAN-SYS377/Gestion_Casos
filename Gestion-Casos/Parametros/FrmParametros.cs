using Gestion_Casos.Casos;
using Gestion_Casos.Parametros;
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
    public partial class FrmParametros : Form
    {
        private Guna2GradientButton botonClickeado = null;
        private Image botonGrisImage = null;
        public static Form formNietoActual;
        public void EfectoHover(Guna2GradientButton btn)
        {
            btn.Refresh();
            btn.BackgroundImage = botonGrisImage;
        }

        public void EfectoLeave(Guna2GradientButton btn)
        {
            if (botonClickeado == null || btn != botonClickeado)
            {
                btn.BackgroundImage = null;
             
            }


        }

        private void Reiniciar()
        {
            if (formNietoActual == null)
            {
                return;
            }
            else
            {
                formNietoActual.Close();

               
            }
        }
        public void AbrirFromNieto(Form formHijo)
        {
            Reiniciar();
            if (formNietoActual == formHijo)
            {
                if (formNietoActual != null && !formNietoActual.IsDisposed)
                {
                    if (formNietoActual.GetType() == formHijo.GetType())
                    {
                        return;
                    }
                    else
                    {
                        formNietoActual.Close();
                        formNietoActual.Dispose();
                    }
                }
            }

            formNietoActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            PanelContenedor2.Controls.Add(formHijo);
            PanelContenedor2.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }



        public FrmParametros()
        {
            InitializeComponent();
        }

        private void BtnUsuarios_Click(object sender, EventArgs e)
        {
            Reiniciar();
            AbrirFromNieto(new FrmUsuarios());
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnUsuarios;
            BtnUsuarios.BackgroundImage = botonGrisImage;
           
            //BtnUsuarios.ForeColor= Color.Black;
        }

        private void Parametros_Load(object sender, EventArgs e)
        {
            botonGrisImage = Image.FromFile(@"Resources//Boton Dark.png");
        }

        private void BtnUsuarios_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnUsuarios);
        }

        private void BtnUsuarios_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnUsuarios);
        }

        private void BtnInstituciones_Click(object sender, EventArgs e)
        {
            Reiniciar();
            AbrirFromNieto(new FrmInstituciones_());
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnInstituciones;
            BtnInstituciones.BackgroundImage = botonGrisImage;
           

        }



        private void BtnInstituciones_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnInstituciones);
        }

        private void BtnInstituciones_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnInstituciones);
        }
    }
}
