using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class ProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter is string)
            {
                //productosViewModel.ListaProductos = DBHandler.listaProductos;
                productosViewModel.ListaProveedores = DBHandler.listaProveedores;
            }
            else
            {
                if (parameter != null)
                {
                    ProductosModel producto = (ProductosModel)parameter;
                    productosViewModel.CurrentProducto = (ProductosModel)producto.Clone();
                    //productosViewModel.SelectedProducto = (ProductosModel)producto.Clone();
                }
            }

        }

        private ProductosViewModel productosViewModel { set; get; }
        public ProductosCommand(ProductosViewModel ProductosViewModel)
        {
            productosViewModel = ProductosViewModel;
        }
    }
}
