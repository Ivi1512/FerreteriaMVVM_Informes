using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
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
    class AñadirProveedorAProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            ProveedoresModel proveedor = (ProveedoresModel)parameter;
            if (proveedor != null)
            {
                if (!productosViewModel.CurrentProducto.Proveedores.Contains(proveedor))
                {
                    productosViewModel.CurrentProducto.Proveedores.Add(proveedor);

                    MessageBox.Show("Proveedor " + proveedor.Nombre + " añadido correctamente");
                }
                else MessageBox.Show("Este producto ya tiene el proveedor " + proveedor.Nombre);
            }
            else MessageBox.Show("¡Selecciona un proveedor!");
        }

        private ProductosViewModel productosViewModel { set; get; }
        public AñadirProveedorAProductoCommand(ProductosViewModel ProductosViewModel)
        {
            productosViewModel = ProductosViewModel;
        }
    }
}
