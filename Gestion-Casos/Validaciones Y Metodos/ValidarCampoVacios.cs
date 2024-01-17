using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Gestion_Casos.Validaciones_Y_Metodos
{
public class ValidarCampoVacios
    {
        public static ErrorProvider Error = new ErrorProvider();
        /// <summary>
        /// Metodo para validar los campos vacios de un panel
        /// </summary>
        /// <param name="panel"> Resive el nombre del panel que contiene los controlos</param>
        /// <returns>Retorna true si existen campos vacios y los muestra por medio del Error Provider</returns>
        public static bool ValidarCamposVaciosPanel(Guna2Panel panel)
        {
            bool camposVacios = false;
            Error.Clear();

            foreach (Control control in panel.Controls)
            {
                if (control is Guna2TextBox textBox)
                {
                    if (string.IsNullOrEmpty(textBox.Text))
                    {
                        Error.SetError(textBox, "Este campo es obligatorio");
                        textBox.BorderColor = Color.Red;
                        camposVacios = true;
                    }
                    else
                    {
                        Error.SetError(textBox, ""); // Borrar cualquier mensaje de error previo
                        textBox.BorderColor = Color.FromArgb(64, 64, 64);
                    }
                }
                else if (control is Guna2ComboBox comboBox)
                {
                    if (comboBox.SelectedIndex == -1)
                    {
                        Error.SetError(comboBox, "Debe seleccionar una opción");
                        comboBox.BorderColor = Color.Red;
                        camposVacios = true;
                    }
                    else
                    {
                        Error.SetError(comboBox, ""); // Borrar cualquier mensaje de error previo
                        comboBox.BorderColor = Color.FromArgb(64, 64, 64);
                    }
                }
                else if (control is Guna2RadioButton radioButton)
                {
                    if (radioButton.Checked)
                    {
                        // Al menos un RadioButton está seleccionado
                        camposVacios = false;
                        break; // Salir del bucle tan pronto como se encuentra uno seleccionado
                    }
                    else
                    {
                        camposVacios = true;
                    }
                }
            }

            return camposVacios;
        }
    }
}
