using CapaEntidades;
using CapaNegocios;
using CapaUtilidades.Enumeradores;
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
using static CapaUtilidades.Enumeradores.Enums;

namespace Gestion_Casos.Parametros
{
    public partial class FrmInstituciones_ : Form
    {
     
        ContadorNegocios contadorNegocios = new ContadorNegocios();
        PersonaNegocios personaNegocios = new PersonaNegocios();
        InstitucionNegocios institucionNegocios = new InstitucionNegocios();
        List<String> listaContadores = new List<String>();
        List<TBInstitucion> listInstituciones = new List<TBInstitucion>();
        private int indiceActual = -1;


        public FrmInstituciones_()
        {
            InitializeComponent();
            InitializeComboBoxes();
            LoadAllData();
        }

        private void FrmInstituciones__Load(object sender, EventArgs e)
        {
            LoadAllData();
        }

        private void LoadAllData()
        {
            listInstituciones = institucionNegocios.loadAll();
            LoadDataGridView();
        }

        private void LoadDataGridView()
        {
            DgvInstituciones.Rows.Clear();
            foreach (var item in listInstituciones)
            {
                if (item.Estado)
                {
                    int n = DgvInstituciones.Rows.Add();
                    DgvInstituciones.Rows[n].Cells[0].Value = item.Circuito;
                    DgvInstituciones.Rows[n].Cells[1].Value = item.NombreIntitucion;
                    TBPersona persona = personaNegocios.loadById(item.TBContador.IdentificacionContadorFK);
                    DgvInstituciones.Rows[n].Cells[2].Value = persona.NombreCompleto;
                }
            }
        }

        private void InitializeComboBoxes()
        {
            CbTipo.DataSource = Enum.GetNames(typeof(TipoInstitucion));
            CbDiaRuta.DataSource = Enum.GetNames(typeof(DiaSemana));
            CbTipoCuenta.DataSource = new List<String> { "Banco Nacional", "Caja Única" };
            cbCircuito.DataSource = Enumerable.Range(1, 8).ToArray();

            List<TBContador> ListContadors = contadorNegocios.loadAll();
            foreach (var item in ListContadors)
            {
                if (item.Estado)
                {
                    listaContadores.Add(item.TBPersona.NombreCompleto);
                }
            }
            CbContador.DataSource = listaContadores;
        }

        private void ClearForm()
        {
            cbCircuito.Enabled = true;
            CbContador.Enabled = true;
            CbDiaRuta.Enabled = true;
            CbTipoCuenta.Enabled = true;
            TxtCedulaJurica.Enabled = true;
            TxtCodigo.Enabled = true;
            TxtInstitucion.Enabled = true;
            TxtNumContacto.Enabled = true;
            TxtContacto.Enabled = true;

            cbCircuito.Refresh();
            CbContador.Refresh();
            CbDiaRuta.Refresh();
            CbTipoCuenta.Refresh();

            TxtCedulaJurica.Clear();
            TxtCodigo.Clear();
            TxtInstitucion.Clear();
            TxtNumContacto.Clear();
            TxtContacto.Clear();
        }

        private bool ValidarDatosInstitucion()
        {
            if (string.IsNullOrWhiteSpace(TxtCodigo.Text) || !int.TryParse(TxtCodigo.Text, out int codigo))
            {
                MessageBox.Show("Por favor, ingrese un código válido para la institución.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtInstitucion.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre de la institución.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtCedulaJurica.Text))
            {
                MessageBox.Show("Por favor, ingrese la cédula jurídica de la institución.");
                return false;
            }

            if (CbTipo.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de institución.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtContacto.Text))
            {
                MessageBox.Show("Por favor, ingrese el nombre del contacto de la institución.");
                return false;
            }

            if (string.IsNullOrWhiteSpace(TxtNumContacto.Text))
            {
                MessageBox.Show("Por favor, ingrese el número de contacto de la institución.");
                return false;
            }

            if (cbCircuito.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un circuito para la institución.");
                return false;
            }

            if (CbDiaRuta.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione un día de ruta para la institución.");
                return false;
            }

            if (CbTipoCuenta.SelectedIndex == -1)
            {
                MessageBox.Show("Por favor, seleccione el tipo de cuenta para la institución.");
                return false;
            }

            return true;
        }

        private TBInstitucion CreateInstitucionFromTextBoxs()
        {
            TBInstitucion institucion = new TBInstitucion();
            institucion.Codigo = int.Parse(TxtCodigo.Text);
            institucion.Circuito = int.Parse(cbCircuito.SelectedValue.ToString());
            institucion.TipoFK = (int)Enum.Parse(typeof(Enums.TipoInstitucion), CbTipo.SelectedValue.ToString());
            institucion.NombreIntitucion = TxtInstitucion.Text;
            institucion.CedulaJuridica = TxtCedulaJurica.Text;
            institucion.CuentaLey = TxtCuentaLey.Text;
            institucion.Responsable = TxtContacto.Text;
            institucion.Contacto = TxtNumContacto.Text;
            institucion.DiaRuta = CbDiaRuta.SelectedValue.ToString();
            institucion.TipoBanco = CbTipoCuenta.SelectedValue.ToString();
            institucion.FechaCreacion = DateTime.Now;
            institucion.FechaUltimaModificacion = DateTime.Now;
            institucion.UserUltimaModificacion = "Admin";
            institucion.Estado = true;
            List<TBContador> ListContadors = contadorNegocios.loadAll();
            foreach (var item in ListContadors)
            {
                String valueCbContador = CbContador.SelectedValue.ToString();
                if (item.TBPersona.NombreCompleto == valueCbContador)
                {
                    institucion.ContadorFK = item.ContadorID;
                    break;
                }

            }

            return institucion;
        }

        private void setValues(TBInstitucion value)
        {
            if (value != null)
            {
                TxtCodigo.Text = value.Codigo.ToString();
                TxtInstitucion.Text = value.NombreIntitucion;
                TxtCedulaJurica.Text = value.CedulaJuridica;
                TxtCuentaLey.Text = value.CuentaLey;
                TxtContacto.Text = value.Responsable;
                TxtNumContacto.Text = value.Contacto;
                cbCircuito.SelectedItem = value.Circuito;
                CbTipo.SelectedItem = (Enums.TipoInstitucion)value.TipoFK;
                CbTipoCuenta.Text = value.TipoBanco;
                List<TBContador> ListContadors = contadorNegocios.loadAll();
                foreach (var item in ListContadors)
                {
                    if (item.ContadorID == value.ContadorFK)
                    {
                        CbContador.SelectedValue = item.TBPersona.NombreCompleto.ToString();

                    }
                }
                CbDiaRuta.SelectedValue = value.DiaRuta;
            }

        }

        private void add()
        {

            if (ValidarDatosInstitucion())
            {
                TBInstitucion nuevaInstitucion = CreateInstitucionFromTextBoxs();

                bool agregada = false;
                if (nuevaInstitucion != null)
                {
                    agregada = institucionNegocios.add(nuevaInstitucion);

                    if (agregada)
                    {
                        MessageBox.Show("Institución agregada exitosamente.");
                    }
                    else
                    {
                        MessageBox.Show("Error al agregar la institución. Por favor, revise los datos ingresados.");
                    }
                }
                else
                {
                    MessageBox.Show("No se pueden dejar campos en blanco.");
                }
            }
        }

     
        private void SeleccionarFila(int nuevoIndice)
        {
            if (nuevoIndice >= 0 && nuevoIndice < DgvInstituciones.Rows.Count)
            {
                // Desmarca la fila actual si está seleccionada
                if (indiceActual != -1 && indiceActual < DgvInstituciones.Rows.Count)
                {
                    DgvInstituciones.Rows[indiceActual].Selected = false;
                }

                // Establece el índiceActual en el nuevo índice
                indiceActual = nuevoIndice;

                // Marca la fila correspondiente al nuevo índice
                DgvInstituciones.Rows[indiceActual].Selected = true;

            }
            else
            {
                // Si el nuevo índice está fuera de rango, establecer el índiceActual en 0
                indiceActual = 0;
            }
        }


        private void BtnAdelante_Click(object sender, EventArgs e)
        {
            // Avanza al índice siguiente
            int nuevoIndice = (indiceActual + 1);
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlFinal_Click(object sender, EventArgs e)
        {
            SeleccionarFila(DgvInstituciones.Rows.Count - 1);

        }

        private void BtnAtras_Click(object sender, EventArgs e)
        {
            int nuevoIndice = (indiceActual - 1 + DgvInstituciones.Rows.Count) % DgvInstituciones.Rows.Count;
            SeleccionarFila(nuevoIndice);
        }

        private void BtnAlInicio_Click(object sender, EventArgs e)
        {
            SeleccionarFila(0);
        }

        private void BtnCancelar_Click(object sender, EventArgs e)
        {

        }
        private void BtnEditar_Click(object sender, EventArgs e)
        {

        }


        private void BtnNUevo_Click(object sender, EventArgs e)
        {

        }

        private void BtnSave_Click(object sender, EventArgs e)
        {

        }

        private void BtnBloquear_Click(object sender, EventArgs e)
        {

        }
    }
}
