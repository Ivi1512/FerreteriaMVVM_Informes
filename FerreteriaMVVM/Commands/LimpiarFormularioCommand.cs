using FerreteriaMVVM.Models;
using FerreteriaMVVM.ViewModels;
using FerreteriaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class LimpiarFormularioCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProveedoresView vista = (ProveedoresView) parameter;

            ((ProveedoresViewModel)vista.DataContext).CurrentProveedor = new ProveedoresModel();
            vista.E00EstadoInicial();
            vista.edt_cif.IsEnabled = true;
        }

        public LimpiarFormularioCommand() 
        {
            
        }
    }
}
