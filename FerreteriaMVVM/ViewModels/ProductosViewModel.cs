using FerreteriaMVVM.Commands;
using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace FerreteriaMVVM.ViewModels
{
    class ProductosViewModel : ViewModelBase
    {
        public ObservableCollection<string> listaCategorias;
        public ObservableCollection<string> ListaCategorias
        {
            get => listaCategorias is null ? listaCategorias = new ObservableCollection<string>() : listaCategorias;
            set
            {
                if (listaCategorias != value)
                {
                    listaCategorias = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> listaMateriales;
        public ObservableCollection<string> ListaMateriales
        {
            get => listaMateriales is null ? listaMateriales = new ObservableCollection<string>() : listaMateriales;
            set
            {
                if (listaMateriales != value)
                {
                    listaMateriales = value;
                    OnPropertyChanged();
                }
            }
        }
        public ObservableCollection<string> listaMarcas;
        public ObservableCollection<string> ListaMarcas
        {
            get => listaMarcas is null ? listaMarcas = new ObservableCollection<string>() : listaMarcas;
            set
            {
                if (listaMarcas != value)
                {
                    listaMarcas = value;
                    OnPropertyChanged();
                }
            }
        }

        private ObservableCollection<ProductosModel> listaProductos;
        public ObservableCollection<ProductosModel> ListaProductos
        {
            get => listaProductos is null ? listaProductos = new ObservableCollection<ProductosModel>() : listaProductos;
            set
            {
                listaProductos = value;
                OnPropertyChanged(nameof(ListaProductos));
            }
        }


        private ProductosModel currentProducto;
        public ProductosModel CurrentProducto
        {
            get => currentProducto is null ? currentProducto = new ProductosModel() : currentProducto;
            set
            {
                currentProducto = value;
                OnPropertyChanged();
            }
        }


        private ProductosModel selectedProducto { set; get; }
        public ProductosModel SelectedProducto
        {
            get => selectedProducto is null ? selectedProducto = new ProductosModel() : selectedProducto;
            set
            {
                selectedProducto = value;
                OnPropertyChanged(nameof(SelectedProducto));
            }
        }

        public ICommand ProductosCommand { set; get; }
        public ICommand LimpiarFormularioProductosCommand { set; get; }
        public ICommand CrearProductoCommand { set; get; }
        public ICommand EditarProductosCommand { set; get; }
        public ICommand BorrarProductoCommand { set; get; }
        public ICommand AñadirProveedorAProductoCommand { set; get; }
        public ICommand CancelarCambiosCommand { set; get; }
        public ICommand FiltrarProductosCommand{set;get;}
        public ICommand CargarProductosCommand { set; get; }
        public ICommand BuscarProductoCommand { set; get; }
        public ProductosViewModel()
        {
            ListaCategorias = DBHandler.GetCategorias();
            ListaMarcas = DBHandler.GetMarcas();
            ListaMateriales = DBHandler.GetMateriales();
            ProductosCommand = new ProductosCommand(this);
            LimpiarFormularioProductosCommand = new LimpiarFormularioProductosCommand();
            CrearProductoCommand = new CrearProductoCommand();
            EditarProductosCommand = new EditarProductoCommand();
            BorrarProductoCommand = new BorrarProductoCommand();
            AñadirProveedorAProductoCommand = new AñadirProveedorAProductoCommand(this);
            CancelarCambiosCommand = new CancelarCambiosCommand();
            FiltrarProductosCommand = new FiltrarTablaProductosCommand(this);
            CargarProductosCommand = new CargarProductosCommand(this);
            BuscarProductoCommand = new BuscarProductoCommand(this);
        }
    }
}
