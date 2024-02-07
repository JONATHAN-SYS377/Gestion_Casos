using static CapaUtilidades.Enumeradores.Enums;
using CapaUtilidades.Enumeradores;
using CapaNegocios;
using CapaEntidades;
using System.Windows.Forms;


namespace Gestion_Casos.Parametros
{
    public partial class FrmUsuarios : Form
    {
        private int indiceActual = -1;

        private bool isFormEnabled = true;
        private bool isUpdate;
        PersonaNegocios personaNegocios = new PersonaNegocios();
        UsuarioNegocios usuarioNegocios = new UsuarioNegocios();
        ContadorNegocios contadorNegocios = new ContadorNegocios();
        ColaboradorNegocios colaboradorNegocios = new ColaboradorNegocios();
        List<TBUsuario> listUser;

        public FrmUsuarios()
        {
            InitializeComponent();
            loadCombobox();
            listUser = usuarioNegocios.loadAll();
            loadAllUser();

        }

        private void FrmUsuarios_Load(object sender, EventArgs e)
        {

        }
        private void loadCombobox()
        {
            cbTipoCedula.DataSource = Enum.GetValues(typeof(Enums.TipoIdentificacion));
            cbTipoUsuario.DataSource = Enum.GetValues(typeof(Enums.TipoUsuario));
            cbTipoCedula.SelectedIndex = 0;
            cbTipoUsuario.SelectedIndex = 0;
        }

        private void clearfrm()
        {
            cbTipoUsuario.Enabled = true;
            cbTipoCedula.Enabled = true;
            TxtCedula.Enabled = true;
            TxtNombre.Enabled = true;
            TxtPrimerApellido.Enabled = true;
            TxtSegundoApellido.Enabled = true;
            TxtContrasenna.Enabled = true;
            TxtCarnet.Enabled = true;
            cbTipoCedula.Refresh();
            cbTipoUsuario.Refresh();
            TxtCedula.Clear();
            TxtNombre.Clear();
            TxtPrimerApellido.Clear();
            TxtSegundoApellido.Clear();
            TxtContrasenna.Clear();
            TxtCarnet.Clear();
            pbFotoPerfil.Image = ByteArrayToImage(new byte[] { });
        }


        private void Enabledfrm(bool status)
        {
            cbTipoUsuario.Enabled = status;
            cbTipoCedula.Enabled = status;
            TxtCedula.Enabled = status;
            TxtNombre.Enabled = status;
            TxtPrimerApellido.Enabled = status;
            TxtSegundoApellido.Enabled = status;
            TxtContrasenna.Enabled = status;
            TxtCarnet.Enabled = status;
        }


        public bool validationValue()
        {
            bool isValid = true;

            if (string.IsNullOrEmpty(TxtCedula.Text.Trim()))
            {
                TxtCedula.Focus();

                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtNombre.Text.Trim()))
            {
                TxtNombre.Focus();

                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtPrimerApellido.Text.Trim()))
            {
                TxtPrimerApellido.Focus();

                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtSegundoApellido.Text.Trim()))
            {
                TxtSegundoApellido.Focus();

                isValid = false;
            }

            if (string.IsNullOrEmpty(TxtContrasenna.Text.Trim()))
            {
                TxtContrasenna.Focus();

                isValid = false;
            }

            return isValid;
        }



        public void addValue()
        {
            if (validationValue())
            {
                try
                {
                    TBPersona persona = CreatePersonaFromTextBoxes();

                    if (persona != null)
                    {
                        if ((TipoUsuario)cbTipoUsuario.SelectedValue == TipoUsuario.Tramitador)
                        {

                            TBColaborador colaborador = CreateColaboradorFromPersona(persona);
                            TBUsuario user = CreateUserFromColaborador(persona.Identificacion);

                            if (colaboradorNegocios.add(colaborador))
                            {
                                if (usuarioNegocios.add(user))
                                {
                                    listUser = usuarioNegocios.loadAll();
                                    loadAllUser();
                                    clearfrm();
                                    MessageBox.Show("Registro Exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    ShowErrorMessage("Error al agregar el Usuario");

                                }
                            }
                            else
                            {
                                ShowErrorMessage("Error al agregar el Colaborador");
                            }

                        }
                        else
                        {
                            TBUsuario user = CreateUserFromColaborador(persona.Identificacion);
                            TBContador contador = CreateContadorFromPersona(persona);
                            if (contadorNegocios.add(contador))
                            {
                                if (usuarioNegocios.add(user))
                                {
                                    listUser = usuarioNegocios.loadAll();
                                    loadAllUser();
                                    clearfrm();
                                    MessageBox.Show("Registro Exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                                else
                                {
                                    ShowErrorMessage("Error al agregar el Usuario");

                                }
                            }
                            else
                            {
                                ShowErrorMessage("Error al agregar el contador");
                            }
                        }
                    }
                    else
                    {
                        ShowErrorMessage("Error al crear la persona");
                    }

                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Verificar que los campos de texto sean llenados correctamente", "Advertencia", MessageBoxButtons.OK);
            }
        }



        public void updateValues()
        {
            if (validationValue())
            {
                try
                {
                    TBPersona persona = personaNegocios.loadById(TxtCedula.Text);
                    persona.Nombre = TxtNombre.Text;
                    persona.PrimerApellido = TxtPrimerApellido.Text;
                    persona.SegundoApellido = TxtSegundoApellido.Text;
                    persona.FechaUltimaModificacion = DateTime.Now;
                    persona.UserUltimaModificacion = "admin";
                    if (personaNegocios.updateById(persona))
                    {
                        if ((TipoUsuario)cbTipoUsuario.SelectedValue == TipoUsuario.Tramitador)
                        {
                            if (null != colaboradorNegocios.loadById(persona.Identificacion))
                            {
                                updateColaboradorAndUser(persona);

                            }
                            else
                            {
                                if (null != contadorNegocios.loadById(persona.Identificacion))
                                {
                                    contadorNegocios.deleteById(persona.Identificacion);
                                }
                                TBColaborador colaborador = new TBColaborador();
                                colaborador.IdentificacionColaboradorFK = persona.Identificacion;
                                colaborador.Estado = true;
                                colaborador.FechaUltimaModificacion = DateTime.Now;
                                colaborador.UserUltimaModificacion = "admin";
                                colaborador.FechaCreacion = DateTime.Now;

                                if (colaboradorNegocios.add(colaborador))
                                {
                                    TBUsuario user = usuarioNegocios.loadById(TxtCedula.Text);
                                    user.Contrasena = TxtContrasenna.Text;
                                    user.FechaUltimaModificacion = DateTime.Now;
                                    user.Rol = cbTipoUsuario.SelectedValue.ToString();
                                    user.Estado = true;
                                    user.UserUltimaModificacion = "admin";
                                    byte[] imagenBytes = ImageToByteArray(pbFotoPerfil.Image);
                                    user.FotoPerfil = imagenBytes;
                                    if (usuarioNegocios.updateById(user))
                                    {
                                        listUser = usuarioNegocios.loadAll();
                                        loadAllUser();
                                        clearfrm();
                                        MessageBox.Show("Actualizacion exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                    else
                                    {
                                        ShowErrorMessage("Error al actualizar el Usuario");
                                    }
                                }
                                else
                                {

                                    ShowErrorMessage("Error al actualizar el contador");
                                }
                            }

                        }
                        else
                        {
                            if (null != contadorNegocios.loadById(persona.Identificacion))
                            {

                                updateContadorAndUser(persona);

                            }
                            else
                            {
                                if (null != colaboradorNegocios.loadById(persona.Identificacion))
                                {
                                    colaboradorNegocios.deleteById(persona.Identificacion);
                                }
                                TBContador contador = new TBContador();
                                contador.IdentificacionContadorFK = persona.Identificacion;
                                contador.Estado = true;
                                contador.FechaUltimaModificacion = DateTime.Now;
                                contador.UserUltimaModificacion = "admin";
                                contador.Carnet = TxtCarnet.Text;
                                contador.FechaCreacion = DateTime.Now;

                                TBUsuario user = usuarioNegocios.loadById(persona.Identificacion);

                                user.Contrasena = TxtContrasenna.Text;
                                user.FechaUltimaModificacion = DateTime.Now;
                                user.Rol = cbTipoUsuario.SelectedValue.ToString();
                                user.Estado = true;
                                user.UserUltimaModificacion = "admin";
                                byte[] imagenBytes = ImageToByteArray(pbFotoPerfil.Image);
                                user.FotoPerfil = imagenBytes;
                                if (contadorNegocios.add(contador))
                                {
                                    if (!usuarioNegocios.updateById(user))
                                    {
                                        ShowErrorMessage("Error al actualizar el usuario");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Actualización Exitosa", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        listUser = usuarioNegocios.loadAll();
                                        loadAllUser();
                                        clearfrm();
                                    }
                                }
                                else
                                {
                                    ShowErrorMessage("Error al actualizar el contador");
                                }
                            }

                        }
                    }
                    else
                    {
                        ShowErrorMessage("Error al actualizar la persona");
                    }
                }
                catch (Exception ex)
                {
                    ShowErrorMessage("Error: " + ex.Message);
                }
            }
            else
            {
                MessageBox.Show("Error: Verificar que los campos de texto estén llenados correctamente", "Advertencia", MessageBoxButtons.OK);
            }
        }

        private void updateColaboradorAndUser(TBPersona persona)
        {
            TBColaborador colaborador = colaboradorNegocios.loadById(TxtCedula.Text);
            if (colaborador != null)
            {
                colaborador.Estado = true;
                colaborador.FechaUltimaModificacion = DateTime.Now;
                colaborador.UserUltimaModificacion = "admin";
                TBUsuario user = usuarioNegocios.loadById(TxtCedula.Text);
                user.Contrasena = TxtContrasenna.Text;
                user.FechaUltimaModificacion = DateTime.Now;
                user.Rol = cbTipoUsuario.SelectedValue.ToString();
                user.Estado = true;
                user.UserUltimaModificacion = "admin";
                byte[] imagenBytes = ImageToByteArray(pbFotoPerfil.Image);
                user.FotoPerfil = imagenBytes;
                if (colaboradorNegocios.updateById(colaborador))
                {
                    if (usuarioNegocios.updateById(user))
                    {
                        listUser = usuarioNegocios.loadAll();
                        loadAllUser();
                        clearfrm();
                        MessageBox.Show("Registro Exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        ShowErrorMessage("Error al actualizar el colaborador o el usuario");
                    }
                }
                else
                {
                    ShowErrorMessage("Error axl actualizar el colaborador o el usuario");
                }
            }
        }

        private void updateContadorAndUser(TBPersona persona)
        {
            TBContador contador = contadorNegocios.loadById(persona.Identificacion);
            contador.Estado = true;
            contador.FechaUltimaModificacion = DateTime.Now;
            contador.UserUltimaModificacion = "admin";
            contador.Carnet = TxtCarnet.Text;
            TBUsuario user = usuarioNegocios.loadById(persona.Identificacion);
            user.Contrasena = TxtContrasenna.Text;
            user.FechaUltimaModificacion = DateTime.Now;
            user.Rol = cbTipoUsuario.SelectedValue.ToString();
            user.Estado = true;
            user.UserUltimaModificacion = "admin";
            byte[] imagenBytes = ImageToByteArray(pbFotoPerfil.Image);
            user.FotoPerfil = imagenBytes;
            if (contadorNegocios.updateById(contador))
            {
                if (usuarioNegocios.updateById(user))
                {
                    listUser = usuarioNegocios.loadAll();
                    loadAllUser();
                    clearfrm();
                    MessageBox.Show("Registro Exitoso", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {

                    ShowErrorMessage("Error al actualizar el contador o el usuario");
                }
            }
            else
            {
                ShowErrorMessage("Error al actualizar el contador");
            }
        }

        private TBPersona CreatePersonaFromTextBoxes()
        {
            TBPersona persona = new TBPersona();
            persona.Identificacion = TxtCedula.Text;
            persona.Nombre = TxtNombre.Text;
            persona.PrimerApellido = TxtPrimerApellido.Text;
            persona.SegundoApellido = TxtSegundoApellido.Text;
            persona.TipoIdentificacion = (int)Enum.Parse(typeof(Enums.TipoIdentificacion), cbTipoCedula.SelectedValue.ToString());
            persona.FechaUltimaModificacion = DateTime.Now;
            persona.FechaCreacion = DateTime.Now;
            persona.UserUltimaModificacion = "admin";
            return persona;
        }

        private TBColaborador CreateColaboradorFromPersona(TBPersona persona)
        {
            TBColaborador colaborador = new TBColaborador();
            colaborador.TBPersona = persona;
            colaborador.Estado = true;
            colaborador.FechaCreacion = DateTime.Now;
            colaborador.FechaUltimaModificacion = DateTime.Now;
            colaborador.UserUltimaModificacion = "admin";
            return colaborador;
        }


        private TBUsuario CreateUserFromColaborador(string identificacionValue)
        {
            TBUsuario user = new TBUsuario();
            user.IdentificacionUserFK = identificacionValue;
            user.Contrasena = TxtContrasenna.Text;
            user.FechaCreacion = DateTime.Now;
            user.FechaUltimaModificacion = DateTime.Now;
            user.Rol = cbTipoUsuario.SelectedValue.ToString();
            user.Estado = true;
            user.UserUltimaModificacion = "admin";
            byte[] imagenBytes = ImageToByteArray(pbFotoPerfil.Image);
            user.FotoPerfil = imagenBytes;
            return user;
        }


        private TBContador CreateContadorFromPersona(TBPersona persona)
        {
            TBContador contador = new TBContador();
            contador.TBPersona = persona;
            contador.Estado = true;
            contador.FechaCreacion = DateTime.Now;
            contador.FechaUltimaModificacion = DateTime.Now;
            contador.UserUltimaModificacion = "admin";
            contador.Carnet = TxtCarnet.Text;
            return contador;
        }


        private void ShowErrorMessage(string message)
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetValues(TBUsuario value)
        {
            TxtCedula.Text = value.TBPersona.Identificacion.ToString();
            TxtNombre.Text = value.TBPersona.Nombre.ToString();
            TxtPrimerApellido.Text = value.TBPersona.PrimerApellido.ToString();
            TxtSegundoApellido.Text = value.TBPersona.SegundoApellido.ToString();
            TxtContrasenna.Text = value.Contrasena.ToString();
            cbTipoCedula.SelectedItem = (Enums.TipoIdentificacion)value.TBPersona.TipoIdentificacion;
            cbTipoUsuario.SelectedItem = (Enums.TipoUsuario)Enum.Parse(typeof(Enums.TipoUsuario), value.Rol);
            if (value.Rol == TipoUsuario.Contador.ToString() || value.Rol == TipoUsuario.Admi.ToString())
            {
                TxtCarnet.Visible = true;
                TBContador Contador = new TBContador();
                Contador = contadorNegocios.loadById(value.TBPersona.Identificacion.ToString());
                TxtCarnet.Text = Contador.Carnet.ToString();
            }
            pbFotoPerfil.Image = ByteArrayToImage(value.FotoPerfil);
        }



        private void SeleccionarFila(int nuevoIndice)
        {
            if (nuevoIndice >= 0 && nuevoIndice < DgvUsuarios.Rows.Count)
            {
                // Desmarca la fila actual si está seleccionada
                if (indiceActual != -1 && indiceActual < DgvUsuarios.Rows.Count)
                {
                    DgvUsuarios.Rows[indiceActual].Selected = false;
                }

                // Establece el índiceActual en el nuevo índice
                indiceActual = nuevoIndice;

                // Marca la fila correspondiente al nuevo índice
                DgvUsuarios.Rows[indiceActual].Selected = true;

                // Verifica si el índice es válido antes de obtener el valor de la celda
                if (DgvUsuarios.Rows[indiceActual].Cells[0].Value != null)
                {
                    var cellValue = DgvUsuarios.Rows[indiceActual].Cells[0].Value.ToString();
                    TBUsuario Usuario = usuarioNegocios.loadById(cellValue);
                    SetValues(Usuario);
                }
                else
                {
                    // Limpiar los campos si la celda está vacía
                    LimpiarCampos();
                }
            }
            else
            {
                // Si el nuevo índice está fuera de rango, establecer el índiceActual en 0
                indiceActual = 0;
            }
        }

        // Método para limpiar los campos del formulario
        private void LimpiarCampos()
        {
            TxtCedula.Clear();
            TxtNombre.Clear();
            TxtPrimerApellido.Clear();
            TxtSegundoApellido.Clear();
            TxtContrasenna.Clear();
            TxtCarnet.Clear();
            pbFotoPerfil.Refresh();
            // También puedes limpiar la selección de los ComboBox si es necesario
        }

        private void BtnAdelante_Click(object sender, EventArgs e)
        {
            // Avanza al índice siguiente
            int nuevoIndice = (indiceActual + 1);
            SeleccionarFila(nuevoIndice);
            Enabledfrm(!isFormEnabled);

        }

        private void BtnAlFinal_Click(object sender, EventArgs e)
        {
            SeleccionarFila(DgvUsuarios.Rows.Count - 1);
            Enabledfrm(!isFormEnabled);

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            // Retrocede al índice anterior
            int nuevoIndice = (indiceActual - 1 + DgvUsuarios.Rows.Count) % DgvUsuarios.Rows.Count;
            SeleccionarFila(nuevoIndice);
            Enabledfrm(!isFormEnabled);
        }

        private void BtnAlInicio_Click(object sender, EventArgs e)
        {
            SeleccionarFila(0);
            Enabledfrm(!isFormEnabled);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            isUpdate = false;
            clearfrm();
        }

        private void BtnEditar_Click(object sender, EventArgs e)
        {
            isUpdate = true;
            Enabledfrm(isFormEnabled);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {
            Enabledfrm(!isFormEnabled);
            clearfrm();
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (isUpdate)
            {
                updateValues();
            }
            else
            {
                addValue();
            }
        }
        private void cbTipoUsuario_SelectedIndexChanged(object sender, EventArgs e)
        {
            if ((TipoUsuario)cbTipoUsuario.SelectedValue != TipoUsuario.Tramitador)
            {
                TxtCarnet.Visible = true;
                guna2HtmlLabel3.Visible = true;
            }
            else
            {
                TxtCarnet.Visible = false;
                guna2HtmlLabel3.Visible = false;
            }
        }
        private void loadAllUser()
        {
            DgvUsuarios.Rows.Clear();
            foreach (var item in listUser)
            {
                if (item.Estado)
                {
                    int n = DgvUsuarios.Rows.Add();
                    DgvUsuarios.Rows[n].Cells[0].Value = item.TBPersona.Identificacion;
                    DgvUsuarios.Rows[n].Cells[1].Value = item.TBPersona.NombreCompleto;
                    DgvUsuarios.Rows[n].Cells[2].Value = item.Rol;
                    DgvUsuarios.Rows[n].Cells[3].Value = item.FechaCreacion;
                }
            }
        }

        private void DgvUsuarios_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                indiceActual = e.RowIndex;
                var cellValue = DgvUsuarios.Rows[e.RowIndex].Cells[0].Value;
                TBUsuario Usuario = new TBUsuario();
                Usuario = usuarioNegocios.loadById(cellValue.ToString());
                SetValues(Usuario);
            }
        }

        private void DgvUsuarios_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            string identificacionValue = TxtCedula.Text;


            if (string.IsNullOrEmpty(identificacionValue))
            {
                MessageBox.Show("Error: El campo de identificación está vacío.", "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                try
                {
                    bool deletedPersona = personaNegocios.deleteById(identificacionValue);
                    bool deletedUsuario = usuarioNegocios.deleteById(identificacionValue);
                    if (cbTipoUsuario.SelectedValue.ToString() == TipoUsuario.Tramitador.ToString())
                    {

                        bool deletedColaborador = colaboradorNegocios.deleteById(identificacionValue);
                        if (deletedPersona || deletedColaborador || deletedUsuario)
                        {
                            listUser = usuarioNegocios.loadAll();
                            loadAllUser();
                            clearfrm();
                            MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {
                        bool deletedContador = contadorNegocios.deleteById(identificacionValue);
                        if (deletedPersona || deletedContador || deletedUsuario)
                        {
                            listUser = usuarioNegocios.loadAll();
                            loadAllUser();
                            clearfrm();
                            MessageBox.Show("Usuario eliminado exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        }
                        else
                        {
                            MessageBox.Show("No se pudo eliminar el usuario.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al intentar eliminar el usuario: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnUpload_Click(object sender, EventArgs e)
        {
            // Configurar el cuadro de diálogo de apertura de archivo
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de imagen|*.jpg;*.jpeg;*.png;*.gif;*.bmp";
            openFileDialog.Title = "Seleccionar imagen";

            // Mostrar el cuadro de diálogo de apertura de archivo
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Obtener la ruta de la imagen seleccionada
                    string rutaImagen = openFileDialog.FileName;

                    // Cargar la imagen en el PictureBox
                    pbFotoPerfil.Image = new Bitmap(rutaImagen);

                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al cargar la imagen: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private byte[] ImageToByteArray(Image image)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                image.Save(ms, image.RawFormat);
                return ms.ToArray();
            }
        }

        private Image ByteArrayToImage(byte[] imageData)
        {
            if (imageData != null && imageData.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imageData))
                {
                    Image imagen = Image.FromStream(ms);
                    return imagen;
                }
            }
            else
            {
                return Properties.Resources.user__3_;
            }
        }

    }
}

