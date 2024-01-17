using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Casos
{
    public partial class FrmLog_In : Form
    {
        public FrmLog_In()
        {
            InitializeComponent();
        }

        private void BtnVerContraseña_Click(object sender, EventArgs e)
        {
            TxtVerContraseña.Visible = true;
            BtnOcultarContraseña.Visible = true;
            BtnOcultarContraseña.BringToFront();
            TxtContraseña.Visible = false;
            BtnVerContraseña.Visible = false;
        }

        private void BtnOcultarContraseña_Paint(object sender, PaintEventArgs e)
        {

        }

        private void BtnOcultarContraseña_Click(object sender, EventArgs e)
        {
            TxtVerContraseña.Visible = false;
            BtnOcultarContraseña.Visible = false;
            TxtVerContraseña.SendToBack();
            BtnOcultarContraseña.SendToBack();
            TxtContraseña.Visible = true;
            BtnVerContraseña.Visible = true;
            TxtContraseña.BringToFront();
            BtnVerContraseña.BringToFront();
        }

        private void TxtContraseña_TextChanged(object sender, EventArgs e)
        {
            TxtVerContraseña.Text = TxtContraseña.Text;
        }

        private void TxtVerContraseña_TextChanged(object sender, EventArgs e)
        {
            TxtContraseña.Text = TxtVerContraseña.Text;
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BtnMinimizar_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        private void BtnAcceder_Click(object sender, EventArgs e)
        {
            this.Hide();
            FrmPrincipal frmPrincipal = new FrmPrincipal();
            frmPrincipal.ShowDialog();
        }

        private void BtnEnviarCorreo_Click(object sender, EventArgs e)
        {

        }
    }
}
