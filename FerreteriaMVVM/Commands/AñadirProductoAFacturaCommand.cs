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

        public void Execute(object parameter)
        {
            int lista = formularioViewModel.ListaProductosCantidad.Count();

            formularioViewModel.ProductoTabla.ProductoModel = formularioViewModel.CurrentProducto;

            if (lista == 0)
            {
                formularioViewModel.ListaProductosCantidad.Add(formularioViewModel.ProductoTabla);
            }
            else
            {
                foreach (ProductoCantidadModel p in formularioViewModel.ListaProductosCantidad)
                {   
                    if (!p.ProductoModel._id.Equals(formularioViewModel.ProductoTabla.ProductoModel._id))
                    {
                        formularioViewModel.ListaProductosCantidad.Add(formularioViewModel.ProductoTabla);
                        break;
                    }
                    else
                    {
                        formularioViewModel.ProductoTabla.Cantidad = formularioViewModel.ProductoTabla.Cantidad + p.Cantidad;
                        break;
                    }
                }

                formularioViewModel.Total = formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad;
            } 
            
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public AñadirProductoAFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
