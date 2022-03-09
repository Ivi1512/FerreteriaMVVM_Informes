using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using FerreteriaMVVM.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class CargarProductosCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public async void Execute(object parameter)
        {
            productosViewModel.ListaProveedores = DBHandler.listaProveedores;

            //StudentDBHandler.CargarListaFicticia();

            RequestModel requestModel = new RequestModel();
            requestModel.route = "/products";
            requestModel.method = "GET";
            requestModel.data = "all";

            ResponseModel responseModel = await APIHandler.ConsultAPI(requestModel);

            if (responseModel.resultOK)
            {
                productosViewModel.ListaProductos = JsonConvert.DeserializeObject<ObservableCollection<ProductosModel>>((string)responseModel.data);
            }
        }

        private ProductosViewModel productosViewModel { set; get; }
        public CargarProductosCommand(ProductosViewModel ProductosViewModel)
        {
           productosViewModel = ProductosViewModel;
        }

        

    }
}
