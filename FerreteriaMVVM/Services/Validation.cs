using FerreteriaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Services
{
    class Validation
    {
        public static bool ValidarCamposVaciosProducto(ProductosView vista)
        {
            bool validadoOK = true;

            if (string.IsNullOrWhiteSpace(vista.edt_codigo_barras.Text))
            {
                vista.txtWarning.Text = "El campo Código de Barras no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (vista.comboProveedores.SelectedIndex.Equals(-1))
            {
                vista.txtWarning.Text = "Debes seleccionar un valor en el campo Proveedores";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (vista.comboCategoria.SelectedIndex.Equals(-1))
            {
                vista.txtWarning.Text = "Debes seleccionar un valor en el campo Categoría";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (vista.comboMarca.SelectedIndex.Equals(-1))
            {
                vista.txtWarning.Text = "Debes seleccionar un valor en el campo Marca";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (vista.comboMaterial.SelectedIndex.Equals(-1))
            {
                vista.txtWarning.Text = "Debes seleccionar un valor en el campo Material";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_referencia.Text))
            {
                vista.txtWarning.Text = "El campo Referencia no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_descripcion.Text))
            {
                vista.txtWarning.Text = "El campo Descripción no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_precio.Text))
            {
                vista.txtWarning.Text = "El campo Precio no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (string.IsNullOrWhiteSpace(vista.datePickerFecha.Text))
            {
                vista.txtWarning.Text = "El campo Fecha no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_stock.Text))
            {
                vista.txtWarning.Text = "El campo Stock no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                validadoOK = false;
            }

            return validadoOK;
        }

        public static bool ValidarCamposVaciosProveedores(ProveedoresView vista)
        {
            if (string.IsNullOrWhiteSpace(vista.edt_cif.Text))
            {
                vista.txtWarning.Text = "El campo CIF no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_nombre.Text))
            {
                vista.txtWarning.Text = "El campo Nombre no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_poblacion.Text))
            {
                vista.txtWarning.Text = "El campo Poblacion no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            else if (string.IsNullOrWhiteSpace(vista.edt_telefono.Text))
            {
                vista.txtWarning.Text = "El campo Telefono no puede estar vacío";
                vista.txtWarning.Visibility = System.Windows.Visibility.Visible;
                return false;
            }
            return true;
        }
    }
}
