using Gestion_Casos.Casos;
using Gestion_Casos.Parametros;
using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Casos
{
    public partial class FrmPrincipal : Form
    {
        #region Variables
        bool SideBarExpand = true;
        private Image botonGrisImage = null;
        private bool isMaximized = false;
        private int normalWidth;
        private int normalHeight;
        private Point prevLocation;
        private Size prevSize;
        private bool btnClicked = false;
        private Guna2GradientButton botonClickeado = null;


        public static Form formHijoActual;
        #endregion

        #region Metodos de Diseño
        public void ObtenerFabticanteVersion()
        {
            // Obtener version de publicación de la aplicación
            string versionAplicacion = Application.ProductVersion;

            // Obtener el nombre de la Aplicación y la versión
            Assembly assembly = Assembly.GetExecutingAssembly();
            string nombreApp = assembly.GetName().Name;
            string version = assembly.GetName().Version.ToString();

            // Mostrar la información en la barra de título del formulario
            LblFabricante.Text = $"     {nombreApp} - Versión: {version}  ";
        }

        private void Reiniciar()
        {
            if (formHijoActual == null)
            {
                return;
            }
            else
            {
                formHijoActual.Close();
                
                //BtnDashboard.BackgroundImage = null;
                //BtnParametros.BackgroundImage = null;
                //BtnCasos.BackgroundImage = null;
                //BtnReportes.BackgroundImage = null;
                //BtnConsultas.BackgroundImage = null;
                //BtnChat.BackgroundImage = null;
                //BtnGestion.BackgroundImage = null;
                //BtnConfiguraciones.BackgroundImage = null;
                //PanelContenedor.Padding = new Padding(200, 120, 200, 120);
            }
        }
        public void AbrirFromHijo(Form formHijo)
        {
            Reiniciar();
            if (formHijoActual == formHijo)
            {
                if (formHijoActual != null && !formHijoActual.IsDisposed)
                {
                    if (formHijoActual.GetType() == formHijo.GetType())
                    {
                        return;
                    }
                    else
                    {
                        formHijoActual.Close();
                        formHijoActual.Dispose();
                    }
                }
            }
          
            formHijoActual = formHijo;
            formHijo.TopLevel = false;
            formHijo.FormBorderStyle = FormBorderStyle.None;
            formHijo.Dock = DockStyle.Fill;
            PanelContenedor.Controls.Add(formHijo);
            PanelContenedor.Tag = formHijo;
            formHijo.BringToFront();
            formHijo.Show();
        }

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
                // Resto de tu código para otros botones...
            }


        }
        private void HideButtonText()
        {
            BtnDashboard.Text = string.Empty;
            BtnParametros.Text = string.Empty;
            BtnCasos.Text = string.Empty;
            BtnReportes.Text = string.Empty;
            BtnConsultas.Text = string.Empty;
            BtnChat.Text = string.Empty;
            BtnGestion.Text = string.Empty;
            BtnConfiguraciones.Text = string.Empty;

        }

        private void ShowButtonText()
        {
            BtnDashboard.Text = BtnDashboard.Tag as string;
            BtnParametros.Text = BtnParametros.Tag as string;
            BtnCasos.Text = BtnCasos.Tag as string;
            BtnReportes.Text = BtnReportes.Tag as string;
            BtnConsultas.Text = BtnConsultas.Tag as string;
            BtnChat.Text = BtnChat.Tag as string;
            BtnGestion.Text = BtnGestion.Tag as string;
            BtnConfiguraciones.Text = BtnConfiguraciones.Tag as string;
        }
        #endregion

        public FrmPrincipal()
        {
            InitializeComponent();
            normalWidth = this.Width;
            normalHeight = this.Height;
            ObtenerFabticanteVersion();
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
        }
        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            botonGrisImage = Image.FromFile(@"Resources//BotonGris-2.png");
        }
        private void SlideBar_Tick(object sender, EventArgs e)
        {
            if (SideBarExpand)
            {
                Menu.Width = 90;
                SideBarExpand = false;
                SlideBar.Stop();
                //if (Menu.Width <= 85)
                //{

                    
                //}
            }
            else
            {
                Menu.Width =290;
                SideBarExpand = true;
                SlideBar.Stop();
                ShowButtonText();
                //if (Menu.Width >= 290)
                //{
                    
                //}
            }
        }

        private void BtnAMenuHam_Click(object sender, EventArgs e)
        {
            SlideBar.Start();
            HideButtonText();
        }

        private void BtnDashboard_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnDashboard);
     
        }

        private void BtnDashboard_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnDashboard);
        }

        private void BtnParametros_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnParametros);
          
        }

        private void BtnParametros_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnParametros);
        }

        private void BtnCasos_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnCasos);
        
        }

        private void BtnCasos_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnCasos);
        }

        private void BtnReportes_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnReportes);
            
        }

        private void BtnReportes_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnReportes);
        }

        private void BtnConsultas_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnConsultas);
            
        }

        private void BtnConsultas_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnConsultas);
        }

        private void BtnChat_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnChat);
          
        }

        private void BtnChat_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnChat);
        }

        private void BtnGestion_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnGestion);
          
        }

        private void BtnGestion_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnGestion);
        }

        private void BtnConfiguraciones_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnConfiguraciones);
           
        }

        private void BtnConfiguraciones_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnConfiguraciones);
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            if (!isMaximized)
            {
                this.WindowState = FormWindowState.Maximized;
                isMaximized = true;
                BtnMaximizar.Image = Image.FromFile(@"Resources//expandir-white.png");
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                isMaximized = false;
                BtnMaximizar.Image = Image.FromFile(@"Resources//maximizar1.png");

            }
        }



        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLog_In frmLog_In = new FrmLog_In();
            frmLog_In.Show();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnDashboard;
            BtnDashboard.BackgroundImage = botonGrisImage;
        }

        private void BtnParametros_Click(object sender, EventArgs e)
        {
            Reiniciar();
            AbrirFromHijo(new FrmParametros());
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnParametros;
            BtnParametros.BackgroundImage = botonGrisImage;
        }

        private void BtnCasos_Click(object sender, EventArgs e)
        {
            Reiniciar();
            AbrirFromHijo(new FrmCasos() );
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnCasos;
            BtnCasos.BackgroundImage = botonGrisImage;
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnReportes;
            BtnReportes.BackgroundImage = botonGrisImage;
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnConsultas;
            BtnConsultas.BackgroundImage = botonGrisImage;
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnChat ;
            BtnChat.BackgroundImage = botonGrisImage;
        }

        private void BtnGestion_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnGestion;
            BtnGestion.BackgroundImage = botonGrisImage;
        }

        private void BtnConfiguraciones_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnConfiguraciones;
            BtnConfiguraciones.BackgroundImage = botonGrisImage;
        }
    }
}
