using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using FerreteriaMVVM.ViewModels;
using FerreteriaMVVM.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class EditarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProductosView vista = (ProductosView)parameter;

            if (Validation.ValidarCamposVaciosProducto(vista))
            {
                MessageBoxResult confirmacion = MessageBox.Show("¿Estas seguro que quieres editar el producto?", "Confirmación", MessageBoxButton.YesNo);
                switch (confirmacion)
                {
                    case MessageBoxResult.Yes:
                        RequestModel requesModel = new RequestModel();
                        requesModel.route = "/products";
                        requesModel.method = "PUT";
                        requesModel.data = (((ProductosViewModel)vista.DataContext).CurrentProducto);
                        ResponseModel responseModel = await APIHandler.ConsultAPI(requesModel);


                        if (responseModel.resultOK)
                        {
                            vista.E01MostrarProducto();
                            ((ProductosViewModel)vista.DataContext).CargarProductosCommand.Execute("");
                        }

                        MessageBox.Show((string)responseModel.data, "Modificar", MessageBoxButton.OK, MessageBoxImage.Information);
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }
        }

        public EditarProductoCommand()
        {
            
        }
    }
}
