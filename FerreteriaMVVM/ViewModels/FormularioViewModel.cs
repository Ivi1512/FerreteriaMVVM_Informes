using FerreteriaMVVM.Commands;
using FerreteriaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.ViewModels
{
    class FormularioViewModel : ViewModelBase
    {
        public ICommand UpdateClientsCommand { get; set; }
        public ICommand CargarProductosCommand { get; set; }
        public ICommand CargarComboProductosFormularioCommand { get; set; }

        public DateTime FechaElegida { get; set; }

        private ObservableCollection<ProductosModel> listaProductos { get; set; }
        public ObservableCollection<ProductosModel> ListaProductos
        {
            get { return listaProductos; }
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }

        private ObservableCollection<ClienteModel> listaClientes { get; set; }
        public ObservableCollection<ClienteModel> ListaClientes
        {
            get { return listaClientes; }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        private int cantidad { get; set; }
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }

        private ProductosModel currentProducto { get; set; }
        public ProductosModel CurrentProducto
        {
            get { return currentProducto; }
            set
            {
                currentProducto = value;
                OnPropertyChanged(nameof(CurrentProducto));
            }
        }

        public FormularioViewModel()
        {
            UpdateClientsCommand = new UpdateClientsCommand(this);
            CargarComboProductosFormularioCommand = new CargarComboProductosFormularioCommand(this);

            FechaElegida = DateTime.Today;
            ListaClientes = new ObservableCollection<ClienteModel>();
            Cantidad = 1;
        }
    }
}
