using FerreteriaMVVM.Models;
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

        double sumatotal = 0.0;

        public void Execute(object parameter)
        {
            
            bool existe = false;
            foreach (ProductoCantidadModel p in formularioViewModel.ListaProductosCantidad)
            {
                if (p.ProductoModel._id.Equals(formularioViewModel.ProductoTabla.ProductoModel._id))
                {
                    p.Cantidad = formularioViewModel.ProductoTabla.Cantidad + p.Cantidad;
                    p.Total = p.ProductoModel.Precio * p.Cantidad;
                    existe = true;
                    break;
                }
            }
            if (!existe) 
            {
                formularioViewModel.ProductoTabla.Total = formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad;
                formularioViewModel.ListaProductosCantidad.Add((ProductoCantidadModel)formularioViewModel.ProductoTabla.Clone());
            }

            formularioViewModel.Factura.PrecioTotalFactura = formularioViewModel.Factura.PrecioTotalFactura + formularioViewModel.ProductoTabla.Cantidad * formularioViewModel.ProductoTabla.ProductoModel.Precio;
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public AñadirProductoAFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
