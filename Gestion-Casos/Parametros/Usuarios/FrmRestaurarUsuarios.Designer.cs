namespace Gestion_Casos.Parametros.Usuarios
{
    partial class FrmRestaurarUsuarios
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle2 = new DataGridViewCellStyle();
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            BarraTitulo = new Panel();
            BtnMinimizar = new Guna.UI2.WinForms.Guna2GradientButton();
            BtnMaximizar = new Guna.UI2.WinForms.Guna2GradientButton();
            BtnClose = new Guna.UI2.WinForms.Guna2GradientButton();
            DgvRestaurar = new Guna.UI2.WinForms.Guna2DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            Restaurar = new DataGridViewButtonColumn();
            BarraTitulo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvRestaurar).BeginInit();
            SuspendLayout();
            // 
            // BarraTitulo
            // 
            BarraTitulo.BackgroundImage = Properties.Resources.BarraTareas1;
            BarraTitulo.BackgroundImageLayout = ImageLayout.Stretch;
            BarraTitulo.Controls.Add(BtnMinimizar);
            BarraTitulo.Controls.Add(BtnMaximizar);
            BarraTitulo.Controls.Add(BtnClose);
            BarraTitulo.Dock = DockStyle.Top;
            BarraTitulo.Location = new Point(0, 0);
            BarraTitulo.Name = "BarraTitulo";
            BarraTitulo.Padding = new Padding(2, 0, 2, 2);
            BarraTitulo.Size = new Size(928, 41);
            BarraTitulo.TabIndex = 2;
            BarraTitulo.MouseDown += BarraTitulo_MouseDown;
            // 
            // BtnMinimizar
            // 
            BtnMinimizar.Animated = true;
            BtnMinimizar.AnimatedGIF = true;
            BtnMinimizar.BackColor = Color.Transparent;
            BtnMinimizar.BorderColor = Color.Transparent;
            BtnMinimizar.BorderRadius = 5;
            BtnMinimizar.CustomizableEdges = customizableEdges1;
            BtnMinimizar.DisabledState.BorderColor = Color.DarkGray;
            BtnMinimizar.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnMinimizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnMinimizar.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            BtnMinimizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnMinimizar.Dock = DockStyle.Right;
            BtnMinimizar.FillColor = Color.Empty;
            BtnMinimizar.FillColor2 = Color.Empty;
            BtnMinimizar.Font = new Font("Segoe UI", 9F);
            BtnMinimizar.ForeColor = Color.White;
            BtnMinimizar.HoverState.FillColor = Color.FromArgb(215, 177, 1);
            BtnMinimizar.HoverState.FillColor2 = Color.FromArgb(239, 198, 3);
            BtnMinimizar.Image = Properties.Resources.minimizar_signo;
            BtnMinimizar.ImageOffset = new Point(1, 0);
            BtnMinimizar.ImageSize = new Size(15, 15);
            BtnMinimizar.Location = new Point(806, 0);
            BtnMinimizar.Name = "BtnMinimizar";
            BtnMinimizar.PressedColor = Color.Empty;
            BtnMinimizar.ShadowDecoration.CustomizableEdges = customizableEdges2;
            BtnMinimizar.Size = new Size(40, 39);
            BtnMinimizar.TabIndex = 5;
            BtnMinimizar.Visible = false;
            // 
            // BtnMaximizar
            // 
            BtnMaximizar.Animated = true;
            BtnMaximizar.AnimatedGIF = true;
            BtnMaximizar.BackColor = Color.Transparent;
            BtnMaximizar.BorderColor = Color.Transparent;
            BtnMaximizar.BorderRadius = 5;
            BtnMaximizar.CustomizableEdges = customizableEdges3;
            BtnMaximizar.DisabledState.BorderColor = Color.DarkGray;
            BtnMaximizar.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnMaximizar.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnMaximizar.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            BtnMaximizar.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnMaximizar.Dock = DockStyle.Right;
            BtnMaximizar.FillColor = Color.Empty;
            BtnMaximizar.FillColor2 = Color.Empty;
            BtnMaximizar.Font = new Font("Segoe UI", 9F);
            BtnMaximizar.ForeColor = Color.White;
            BtnMaximizar.HoverState.FillColor = Color.FromArgb(215, 177, 1);
            BtnMaximizar.HoverState.FillColor2 = Color.FromArgb(239, 198, 3);
            BtnMaximizar.Image = Properties.Resources.maximizar1;
            BtnMaximizar.ImageOffset = new Point(1, 0);
            BtnMaximizar.ImageSize = new Size(15, 15);
            BtnMaximizar.Location = new Point(846, 0);
            BtnMaximizar.Name = "BtnMaximizar";
            BtnMaximizar.PressedColor = Color.Empty;
            BtnMaximizar.ShadowDecoration.CustomizableEdges = customizableEdges4;
            BtnMaximizar.Size = new Size(40, 39);
            BtnMaximizar.TabIndex = 4;
            BtnMaximizar.Visible = false;
            // 
            // BtnClose
            // 
            BtnClose.Animated = true;
            BtnClose.AnimatedGIF = true;
            BtnClose.BackColor = Color.Transparent;
            BtnClose.BorderColor = Color.Transparent;
            BtnClose.BorderRadius = 5;
            BtnClose.CustomizableEdges = customizableEdges5;
            BtnClose.DisabledState.BorderColor = Color.DarkGray;
            BtnClose.DisabledState.CustomBorderColor = Color.DarkGray;
            BtnClose.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            BtnClose.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            BtnClose.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            BtnClose.Dock = DockStyle.Right;
            BtnClose.FillColor = Color.Empty;
            BtnClose.FillColor2 = Color.Empty;
            BtnClose.Font = new Font("Segoe UI", 9F);
            BtnClose.ForeColor = Color.White;
            BtnClose.HoverState.FillColor = Color.FromArgb(215, 177, 1);
            BtnClose.HoverState.FillColor2 = Color.FromArgb(239, 198, 3);
            BtnClose.Image = Properties.Resources.cerrar_24px_white;
            BtnClose.ImageOffset = new Point(1, 0);
            BtnClose.ImageSize = new Size(15, 15);
            BtnClose.Location = new Point(886, 0);
            BtnClose.Name = "BtnClose";
            BtnClose.PressedColor = Color.Empty;
            BtnClose.ShadowDecoration.CustomizableEdges = customizableEdges6;
            BtnClose.Size = new Size(40, 39);
            BtnClose.TabIndex = 3;
            BtnClose.Click += BtnClose_Click;
            // 
            // DgvRestaurar
            // 
            DgvRestaurar.AllowUserToAddRows = false;
            DgvRestaurar.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.BackColor = Color.White;
            DgvRestaurar.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            dataGridViewCellStyle2.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = Color.FromArgb(100, 88, 255);
            dataGridViewCellStyle2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle2.ForeColor = Color.White;
            dataGridViewCellStyle2.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = DataGridViewTriState.True;
            DgvRestaurar.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            DgvRestaurar.ColumnHeadersHeight = 35;
            DgvRestaurar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DgvRestaurar.Columns.AddRange(new DataGridViewColumn[] { Column1, Restaurar });
            dataGridViewCellStyle3.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = Color.White;
            dataGridViewCellStyle3.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle3.ForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.SelectionBackColor = Color.FromArgb(231, 229, 255);
            dataGridViewCellStyle3.SelectionForeColor = Color.FromArgb(71, 69, 94);
            dataGridViewCellStyle3.WrapMode = DataGridViewTriState.False;
            DgvRestaurar.DefaultCellStyle = dataGridViewCellStyle3;
            DgvRestaurar.Dock = DockStyle.Fill;
            DgvRestaurar.GridColor = Color.FromArgb(231, 229, 255);
            DgvRestaurar.Location = new Point(0, 41);
            DgvRestaurar.Name = "DgvRestaurar";
            DgvRestaurar.ReadOnly = true;
            DgvRestaurar.RowHeadersVisible = false;
            DgvRestaurar.Size = new Size(928, 522);
            DgvRestaurar.TabIndex = 3;
            DgvRestaurar.ThemeStyle.AlternatingRowsStyle.BackColor = Color.White;
            DgvRestaurar.ThemeStyle.AlternatingRowsStyle.Font = null;
            DgvRestaurar.ThemeStyle.AlternatingRowsStyle.ForeColor = Color.Empty;
            DgvRestaurar.ThemeStyle.AlternatingRowsStyle.SelectionBackColor = Color.Empty;
            DgvRestaurar.ThemeStyle.AlternatingRowsStyle.SelectionForeColor = Color.Empty;
            DgvRestaurar.ThemeStyle.BackColor = Color.White;
            DgvRestaurar.ThemeStyle.GridColor = Color.FromArgb(231, 229, 255);
            DgvRestaurar.ThemeStyle.HeaderStyle.BackColor = Color.FromArgb(100, 88, 255);
            DgvRestaurar.ThemeStyle.HeaderStyle.BorderStyle = DataGridViewHeaderBorderStyle.None;
            DgvRestaurar.ThemeStyle.HeaderStyle.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DgvRestaurar.ThemeStyle.HeaderStyle.ForeColor = Color.White;
            DgvRestaurar.ThemeStyle.HeaderStyle.HeaightSizeMode = DataGridViewColumnHeadersHeightSizeMode.EnableResizing;
            DgvRestaurar.ThemeStyle.HeaderStyle.Height = 35;
            DgvRestaurar.ThemeStyle.ReadOnly = true;
            DgvRestaurar.ThemeStyle.RowsStyle.BackColor = Color.White;
            DgvRestaurar.ThemeStyle.RowsStyle.BorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            DgvRestaurar.ThemeStyle.RowsStyle.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DgvRestaurar.ThemeStyle.RowsStyle.ForeColor = Color.FromArgb(71, 69, 94);
            DgvRestaurar.ThemeStyle.RowsStyle.Height = 25;
            DgvRestaurar.ThemeStyle.RowsStyle.SelectionBackColor = Color.FromArgb(231, 229, 255);
            DgvRestaurar.ThemeStyle.RowsStyle.SelectionForeColor = Color.FromArgb(71, 69, 94);
            // 
            // Column1
            // 
            Column1.HeaderText = "Usuario";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            // 
            // Restaurar
            // 
            Restaurar.HeaderText = "Restaurar";
            Restaurar.Name = "Restaurar";
            Restaurar.ReadOnly = true;
            // 
            // FrmRestaurarUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(928, 563);
            Controls.Add(DgvRestaurar);
            Controls.Add(BarraTitulo);
            Name = "FrmRestaurarUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FrmRestaurarUsuarios";
            BarraTitulo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvRestaurar).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel BarraTitulo;
        private Guna.UI2.WinForms.Guna2GradientButton BtnMinimizar;
        private Guna.UI2.WinForms.Guna2GradientButton BtnMaximizar;
        private Guna.UI2.WinForms.Guna2GradientButton BtnClose;
        private Guna.UI2.WinForms.Guna2DataGridView DgvRestaurar;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewButtonColumn Restaurar;
    }
}