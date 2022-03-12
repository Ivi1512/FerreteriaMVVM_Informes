using FerreteriaMVVM.Models;
using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class EliminarProductoDeFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter != null)
            {
                ProductoCantidadModel producto = (ProductoCantidadModel)parameter;
                formularioViewModel.Factura.PrecioTotalFactura = formularioViewModel.Factura.PrecioTotalFactura - producto.Total;
                formularioViewModel.ListaProductosCantidad.Remove(producto);
                
            }
            else
            {
                MessageBox.Show("No hay elementos seleccionados");
            }
            
        }


        private FormularioViewModel formularioViewModel { set; get; }
        public EliminarProductoDeFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
