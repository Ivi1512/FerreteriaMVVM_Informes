using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class AñadirProductoAFacturaCommand : ICommand
    { 
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            formularioViewModel.ProductoTabla.ProductoModel = formularioViewModel.CurrentProducto;
            formularioViewModel.ListaProductosCantidad.Add(formularioViewModel.ProductoTabla);
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public AñadirProductoAFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
