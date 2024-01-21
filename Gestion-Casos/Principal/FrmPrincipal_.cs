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
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Casos.Principal
{
    public partial class FrmPrincipal_ : Form
    {
        #region Variables
        //Fields
        private int borderSize = 2;
        private Size formSize; //Keep form size when it is minimized and restored.Since the form is resized because it takes into account the size of the title bar and borders.
        bool SideBarExpand = true;
        private Image botonGrisImage = null;
        private Image botonDarkImage = null;
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
                OcultarSubMenu();
                formHijoActual.Close();

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
            btn.BackgroundImage = botonDarkImage;
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
            BtnGestionCasos.Text = string.Empty;
            BtnCasos.Text = string.Empty;
            BtnParametros.Text = string.Empty;
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
            BtnGestionCasos.Text = BtnGestionCasos.Tag as string;
            BtnCasos.Text = BtnCasos.Tag as string;
            BtnReportes.Text = BtnReportes.Tag as string;
            BtnConsultas.Text = BtnConsultas.Tag as string;
            BtnChat.Text = BtnChat.Tag as string;
            BtnGestion.Text = BtnGestion.Tag as string;
            BtnConfiguraciones.Text = BtnConfiguraciones.Tag as string;
        }
        private void MostrarSubMenu(Guna2Panel SubMenu)
        {
            if (SubMenu3.Visible == false)
            {
                OcultarSubMenu();
                SubMenu.Visible = true;
            }
            else
            {
                SubMenu.Visible = false;
            }


        }
        private void OcultarSubMenu()
        {
            SubMenu3.Visible = false;
        }

        private void OcultarMenu()
        {
            if (SideBarExpand)
            {
                Menu.Width = 90;
                SideBarExpand = false;
                SlideBar.Stop();

            }
            else
            {
                Menu.Width = 290;
                SideBarExpand = true;
                SlideBar.Stop();
                ShowButtonText();

            }
        }

        #endregion


        #region Metodos y funciones para arrastrar form y redimencionarlo
        //Drag Form 
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();
        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParam, int lParam);

        //Overridden methods
        protected override void WndProc(ref Message m)
        {
            const int WM_NCCALCSIZE = 0x0083;//Standar Title Bar - Snap Window
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_MINIMIZE = 0xF020; //Minimize form (Before)
            const int SC_RESTORE = 0xF120; //Restore form (Before)
            const int WM_NCHITTEST = 0x0084;//Win32, Mouse Input Notification: Determine what part of the window corresponds to a point, allows to resize the form.
            const int resizeAreaSize = 10;
            #region Form Resize
            // Resize/WM_NCHITTEST values
            const int HTCLIENT = 1; //Represents the client area of the window
            const int HTLEFT = 10;  //Left border of a window, allows resize horizontally to the left
            const int HTRIGHT = 11; //Right border of a window, allows resize horizontally to the right
            const int HTTOP = 12;   //Upper-horizontal border of a window, allows resize vertically up
            const int HTTOPLEFT = 13;//Upper-left corner of a window border, allows resize diagonally to the left
            const int HTTOPRIGHT = 14;//Upper-right corner of a window border, allows resize diagonally to the right
            const int HTBOTTOM = 15; //Lower-horizontal border of a window, allows resize vertically down
            const int HTBOTTOMLEFT = 16;//Lower-left corner of a window border, allows resize diagonally to the left
            const int HTBOTTOMRIGHT = 17;//Lower-right corner of a window border, allows resize diagonally to the right
            ///<Doc> More Information: https://docs.microsoft.com/en-us/windows/win32/inputdev/wm-nchittest </Doc>
            if (m.Msg == WM_NCHITTEST)
            { //If the windows m is WM_NCHITTEST
                base.WndProc(ref m);
                if (this.WindowState == FormWindowState.Normal)//Resize the form if it is in normal state
                {
                    if ((int)m.Result == HTCLIENT)//If the result of the m (mouse pointer) is in the client area of the window
                    {
                        Point screenPoint = new Point(m.LParam.ToInt32()); //Gets screen point coordinates(X and Y coordinate of the pointer)                           
                        Point clientPoint = this.PointToClient(screenPoint); //Computes the location of the screen point into client coordinates                          
                        if (clientPoint.Y <= resizeAreaSize)//If the pointer is at the top of the form (within the resize area- X coordinate)
                        {
                            if (clientPoint.X <= resizeAreaSize) //If the pointer is at the coordinate X=0 or less than the resizing area(X=10) in 
                                m.Result = (IntPtr)HTTOPLEFT; //Resize diagonally to the left
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize))//If the pointer is at the coordinate X=11 or less than the width of the form(X=Form.Width-resizeArea)
                                m.Result = (IntPtr)HTTOP; //Resize vertically up
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTTOPRIGHT;
                        }
                        else if (clientPoint.Y <= (this.Size.Height - resizeAreaSize)) //If the pointer is inside the form at the Y coordinate(discounting the resize area size)
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize horizontally to the left
                                m.Result = (IntPtr)HTLEFT;
                            else if (clientPoint.X > (this.Width - resizeAreaSize))//Resize horizontally to the right
                                m.Result = (IntPtr)HTRIGHT;
                        }
                        else
                        {
                            if (clientPoint.X <= resizeAreaSize)//Resize diagonally to the left
                                m.Result = (IntPtr)HTBOTTOMLEFT;
                            else if (clientPoint.X < (this.Size.Width - resizeAreaSize)) //Resize vertically down
                                m.Result = (IntPtr)HTBOTTOM;
                            else //Resize diagonally to the right
                                m.Result = (IntPtr)HTBOTTOMRIGHT;
                        }
                    }
                }
                return;
            }
            #endregion
            //Remove border and keep snap window
            if (m.Msg == WM_NCCALCSIZE && m.WParam.ToInt32() == 1)
            {
                return;
            }
            //Keep form size when it is minimized and restored. Since the form is resized because it takes into account the size of the title bar and borders.
            if (m.Msg == WM_SYSCOMMAND)
            {
                /// <see cref="https://docs.microsoft.com/en-us/windows/win32/menurc/wm-syscommand"/>
                /// Quote:
                /// In WM_SYSCOMMAND messages, the four low - order bits of the wParam parameter 
                /// are used internally by the system.To obtain the correct result when testing 
                /// the value of wParam, an application must combine the value 0xFFF0 with the 
                /// wParam value by using the bitwise AND operator.
                int wParam = (m.WParam.ToInt32() & 0xFFF0);
                if (wParam == SC_MINIMIZE)  //Before
                    formSize = this.ClientSize;
                if (wParam == SC_RESTORE)// Restored form(Before)
                    this.Size = formSize;
            }
            base.WndProc(ref m);
        }

        //Private methods
        private void AjustarForm()
        {
            switch (this.WindowState)
            {
                case FormWindowState.Maximized: //Maximized form (After)
                    this.Padding = new Padding(10, 10, 10, 2);
                    break;
                case FormWindowState.Normal: //Restored form (After)
                    if (this.Padding.Top != borderSize)
                        this.Padding = new Padding(borderSize);
                    break;
            }
        }

        #endregion 
        public FrmPrincipal_()
        {
            InitializeComponent();
            this.Padding = new Padding(borderSize);//Border size
            this.MaximizedBounds = Screen.FromHandle(this.Handle).WorkingArea;
            ObtenerFabticanteVersion();
        }

        private void BarraTitulo_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void guna2Panel3_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void LblFabricante_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void IconoSoftware_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage(this.Handle, 0x112, 0xf012, 0);
        }

        private void FrmPrincipal__Resize(object sender, EventArgs e)
        {
            AjustarForm();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            formSize = this.ClientSize;
            this.WindowState = FormWindowState.Minimized;
        }

        private void BtnMaximizar_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Normal)
            {
                formSize = this.ClientSize;
                this.WindowState = FormWindowState.Maximized;
                BtnMaximizar.Image = Image.FromFile(@"Resources//expandir-white.png");
            }
            else
            {
                this.WindowState = FormWindowState.Normal;
                this.Size = formSize;
                BtnMaximizar.Image = Image.FromFile(@"Resources//maximizar1.png");

            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            this.Close();
            FrmLog_In frmLog_In = new FrmLog_In();
            frmLog_In.Show();
        }

        private void FrmPrincipal__Load(object sender, EventArgs e)
        {
            botonGrisImage = Image.FromFile(@"Resources//BotonGris-2.png");
            botonDarkImage = Image.FromFile(@"Resources//Boton Dark.png");
            formSize = this.ClientSize;
        }

        private void SlideBar_Tick(object sender, EventArgs e)
        {
            OcultarMenu();
        }

        private void BtnMenu_Click(object sender, EventArgs e)
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

        private void BtnGestionCasos_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnGestionCasos);
        }

        private void BtnGestionCasos_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnGestionCasos);
        }

        private void BtnCasos_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnCasos);
        }

        private void BtnCasos_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnCasos);
        }

        private void BtnParametros_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnParametros);
        }

        private void BtnParametros_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnParametros);
        }

        private void BtnConsultas_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnConsultas);
        }

        private void BtnConsultas_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnConsultas);
        }

        private void BtnReportes_MouseHover(object sender, EventArgs e)
        {
            EfectoHover(BtnReportes);
        }

        private void BtnReportes_MouseLeave(object sender, EventArgs e)
        {
            EfectoLeave(BtnReportes);
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

        private void BtnDashboard_Click(object sender, EventArgs e)
        {
            Reiniciar();
            OcultarSubMenu();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnDashboard;
            BtnDashboard.BackgroundImage = botonDarkImage;
        }

        private void BtnGestionCasos_Click(object sender, EventArgs e)
        {
            MostrarSubMenu(SubMenu3);
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnGestionCasos;
            BtnGestionCasos.BackgroundImage = botonDarkImage;
        }

        private void BtnCasos_Click(object sender, EventArgs e)
        {
            Reiniciar();
            AbrirFromHijo(new FrmCasos());
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnGestionCasos;
            BtnGestionCasos.BackgroundImage = botonDarkImage;
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
            BtnParametros.BackgroundImage = botonDarkImage;
        }

        private void BtnConsultas_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnConsultas;
            BtnConsultas.BackgroundImage = botonDarkImage;
        }

        private void BtnReportes_Click(object sender, EventArgs e)
        {
            Reiniciar();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnReportes;
            BtnReportes.BackgroundImage = botonDarkImage;
        }

        private void BtnChat_Click(object sender, EventArgs e)
        {
            Reiniciar();
            OcultarSubMenu();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnChat;
            BtnChat.BackgroundImage = botonDarkImage;
        }

        private void BtnGestion_Click(object sender, EventArgs e)
        {
            Reiniciar();
            OcultarSubMenu();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnGestion;
            BtnGestion.BackgroundImage = botonDarkImage;
        }

        private void BtnConfiguraciones_Click(object sender, EventArgs e)
        {
            Reiniciar();
            OcultarSubMenu();
            if (botonClickeado != null)
            {
                botonClickeado.BackgroundImage = null;
            }
            botonClickeado = BtnConfiguraciones;
            BtnConfiguraciones.BackgroundImage = botonGrisImage;
        }
    }
}
