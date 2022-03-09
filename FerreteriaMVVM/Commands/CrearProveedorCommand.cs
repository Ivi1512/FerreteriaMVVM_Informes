using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using FerreteriaMVVM.ViewModels;
using FerreteriaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class CrearProveedorCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProveedoresView vista = (ProveedoresView)parameter;

            if (Validation.ValidarCamposVaciosProveedores(vista))
            {
                MessageBoxResult confirmacion = MessageBox.Show("¿Estas seguro que quieres crear al proveedor?", "Confirmación", MessageBoxButton.YesNo);
                switch (confirmacion)
                {
                    case MessageBoxResult.Yes:
                        if (DBHandler.CrearProveedores(((ProveedoresViewModel)vista.DataContext).CurrentProveedor))
                        {
                            vista.E01MostrarProveedor();
                            vista.txtWarning.Visibility = Visibility.Collapsed;
                        }
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public CrearProveedorCommand()
        {
            
        }
    }
}
