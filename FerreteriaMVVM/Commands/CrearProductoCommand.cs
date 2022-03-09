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
    class CrearProductoCommand : ICommand
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
                MessageBoxResult confirmacion = MessageBox.Show("¿Estas seguro que quieres crear el producto?", "Confirmación", MessageBoxButton.YesNo);
                switch (confirmacion)
                {
                    case MessageBoxResult.Yes:
                        RequestModel requestModel = new RequestModel();
                        requestModel.route = "/products";
                        requestModel.method = "POST";
                        requestModel.data = ((ProductosViewModel)vista.DataContext).CurrentProducto;

                        ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                        if (responseModel.resultOK)
                        {
                            MessageBox.Show("Se ha creado el producto");
                            ((ProductosViewModel)vista.DataContext).CargarProductosCommand.Execute("");
                            vista.E01MostrarProducto();
                            
                        }
                        else
                        {
                            MessageBox.Show("Error al crear");
                        }
                        break;

                    case MessageBoxResult.No:
                        break;
                }
            }

            
        }
        
        public CrearProductoCommand()
        {
            
        }
    }
}
