using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
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
    class ProveedoresCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if (parameter is string)
            {
                proveedoresViewModel.ListaProveedores = DBHandler.listaProveedores;
            }
            else
            {
                if(parameter != null)
                {
                    ProveedoresModel proveedor = (ProveedoresModel)parameter;
                    proveedoresViewModel.CurrentProveedor = (ProveedoresModel)proveedor.Clone();
                    proveedoresViewModel.SelectedProveedor = (ProveedoresModel)proveedor.Clone();
                }
            }
        }

        private ProveedoresViewModel proveedoresViewModel { set; get; }
        public ProveedoresCommand(ProveedoresViewModel proveedoresViewModel)
        {
            this.proveedoresViewModel = proveedoresViewModel;

        }




    }
}
