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
    class BorrarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            ProductosView vista = (ProductosView)parameter;
            MessageBoxResult confirmacion = MessageBox.Show("¿Estas seguro que quieres borrar el producto?", "Confirmación", MessageBoxButton.YesNo);
            switch (confirmacion)
            {
                case MessageBoxResult.Yes:
                    RequestModel requestModel = new RequestModel();
                    requestModel.route = "/products";
                    requestModel.method = "DELETE";
                    requestModel.data = ((ProductosViewModel)vista.DataContext).CurrentProducto._id;
                    ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                    if (responseModel.resultOK)
                    {
                        ((ProductosViewModel)vista.DataContext).CargarProductosCommand.Execute("");
                        vista.productosListView.SelectedIndex = 0;
                    }

                    MessageBox.Show((string)responseModel.data);

                    break;

                case MessageBoxResult.No:
                    break;
            }
        }

        public BorrarProductoCommand()
        {
            
        }
    }
}
