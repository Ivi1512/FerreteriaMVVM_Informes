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
        public ICommand AñadirProductoAFacturaCommand { get; set; }
        public ICommand EliminarProductoDeFacturaCommand { get; set; }
        public ICommand GuardarFacturaCommand { get; set; }

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

        private FacturaModel factura { get; set; }
        public FacturaModel Factura
        {
            get { return factura; }
            set
            {
                factura = value;
                OnPropertyChanged(nameof(Factura));
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


        private ObservableCollection<ProductoCantidadModel> listaProductosCantidad { get; set; }
        public ObservableCollection<ProductoCantidadModel> ListaProductosCantidad
        {
            get { return listaProductosCantidad; }
            set
            {
                listaProductosCantidad = value;
                OnPropertyChanged(nameof(ListaProductosCantidad));
            }
        }

        private ProductoCantidadModel productoTabla{ get; set; }
        public ProductoCantidadModel ProductoTabla
        {
            get { return productoTabla; }
            set
            {
                productoTabla = value;
                OnPropertyChanged(nameof(ProductoTabla));
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

        private double totalFactura{ get; set; }
        public double TotalFactura
        {
            get { return totalFactura; }
            set
            {
                totalFactura = value;
                OnPropertyChanged(nameof(TotalFactura));
            }
        }

        public FormularioViewModel()
        {
            UpdateClientsCommand = new UpdateClientsCommand(this);
            CargarComboProductosFormularioCommand = new CargarComboProductosFormularioCommand(this);
            AñadirProductoAFacturaCommand = new AñadirProductoAFacturaCommand(this);
            EliminarProductoDeFacturaCommand = new EliminarProductoDeFacturaCommand(this);
            GuardarFacturaCommand = new GuardarFacturaCommand(this);

            Factura = new FacturaModel();

            ListaProductosCantidad = new ObservableCollection<ProductoCantidadModel>();
            ProductoTabla = new ProductoCantidadModel();
            FechaElegida = DateTime.Today;
            ListaClientes = new ObservableCollection<ClienteModel>();
            ProductoTabla.Cantidad = 1;
        }
    }
}
