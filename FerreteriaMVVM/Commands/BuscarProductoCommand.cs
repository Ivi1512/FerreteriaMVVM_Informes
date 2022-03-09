using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using FerreteriaMVVM.ViewModels;
using FerreteriaMVVM.Views;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class BuscarProductoCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            if (parameter is ProductosView)
            {
                ProductosView vista = (ProductosView)parameter;

                RequestModel requestModel = new RequestModel()
                {
                    route = "/products",
                    method = "GET",
                    data = vista.edtBuscar.Text
                };

                ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

                if (responseModel.resultOK)
                {
                    vista.E01MostrarProducto();
                    productosViewModel.CurrentProducto = JsonConvert.DeserializeObject<ProductosModel>((string)responseModel.data);
                }
                else
                {
                    MessageBox.Show((string)responseModel.data);
                }
            }
        }

        private ProductosViewModel productosViewModel { set; get; }
        public BuscarProductoCommand(ProductosViewModel ProductosViewModel)
        {
            productosViewModel = ProductosViewModel;
        }
    }

}