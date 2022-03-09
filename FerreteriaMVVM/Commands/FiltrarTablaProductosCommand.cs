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
    class FiltrarTablaProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProductosView vista = (ProductosView)parameter;
            string palabra = vista.edt_Filtro.Text;

            productosViewModel.ListaProductos = DBHandler.ActualizarTabla(palabra);



        }

        private ProductosViewModel productosViewModel { set; get; }
        public FiltrarTablaProductosCommand(ProductosViewModel ProductosViewModel)
        {
            productosViewModel = ProductosViewModel;
        }
    }
}
