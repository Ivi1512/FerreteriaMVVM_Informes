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

            bool existe = false;
            foreach (ProductoCantidadModel p in formularioViewModel.ListaProductosCantidad)
            {
                if (p.ProductoModel._id.Equals(formularioViewModel.ProductoTabla.ProductoModel._id))
                {
                    p.Cantidad = formularioViewModel.ProductoTabla.Cantidad + p.Cantidad;
                    existe = true;
                    p.Total = p.Total + (formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad);
                    break;
                }
            }
            if (!existe) 
            {
                formularioViewModel.ProductoTabla.Total = formularioViewModel.ProductoTabla.Total + (formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad);
                formularioViewModel.ListaProductosCantidad.Add((ProductoCantidadModel)formularioViewModel.ProductoTabla.Clone());
            }

            //formularioViewModel.ProductoTabla.Total = formularioViewModel.ProductoTabla.Total + (formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad);

            /*int lista = formularioViewModel.ListaProductosCantidad.Count();
            //formularioViewModel.ProductoTabla.ProductoModel = formularioViewModel.CurrentProducto;
            if(lista == 0)
            {
                Console.WriteLine("cdf");
                formularioViewModel.ListaProductosCantidad.Add((ProductoCantidadModel)formularioViewModel.ProductoTabla.Clone());

            }
            else
            {
                foreach (ProductoCantidadModel p in formularioViewModel.ListaProductosCantidad)
                {
                    Console.WriteLine(p.ProductoModel._id);
                    Console.WriteLine(formularioViewModel.ProductoTabla.ProductoModel._id);
                    if (p.ProductoModel._id.Equals(formularioViewModel.ProductoTabla.ProductoModel._id))
                    {
                        p.Cantidad = formularioViewModel.ProductoTabla.Cantidad + p.Cantidad;
                        break;
                    }
                    else
                    {
                        formularioViewModel.ListaProductosCantidad.Add((ProductoCantidadModel)formularioViewModel.ProductoTabla.Clone());
                        //break;
                    }
                }

            }
           

            formularioViewModel.Total = formularioViewModel.Total + (formularioViewModel.ProductoTabla.ProductoModel.Precio * formularioViewModel.ProductoTabla.Cantidad);*/



        }

        private FormularioViewModel formularioViewModel { set; get; }
        public AñadirProductoAFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
