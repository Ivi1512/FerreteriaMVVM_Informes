using FerreteriaMVVM.Models;
using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FerreteriaMVVM.Views
{
    /// <summary>
    /// Lógica de interacción para ProductosView.xaml
    /// </summary>
    public partial class ProductosView : UserControl, INotifyPropertyChanged
    {
        
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
       
        public event PropertyChangedEventHandler PropertyChanged;


        private bool editarActivado;

        public bool EditarActivado
        {
            get { return editarActivado; }
            set
            {
                editarActivado = value;
                OnPropertyChanged(nameof(EditarActivado));
            }
        }

        private void productosListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarProducto();
        }
        

        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            E02EditarProducto();
            edt_codigo_barras.IsEnabled = false;
        }
        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarProducto();
        }


        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            E02EditarProducto();
            edt_codigo_barras.IsEnabled = false;
        }

        public void E00EstadoInicial()
        {
            btnCancelar.Visibility = Visibility.Collapsed;
            btnEditar.Visibility = Visibility.Collapsed;
            btnAnadir.Visibility = Visibility.Visible;
            btnConfirmar.Visibility = Visibility.Collapsed;
            btnAnadirNuevo.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            comboProveedores.IsEnabled = false;
            edt_codigo_barras.IsEnabled = true;
            btnNuevoProveedor.IsEnabled = true;
            
            EditarActivado = true;
        }

        public void E01MostrarProducto()
        {
            btnCancelar.Visibility = Visibility.Collapsed;
            btnEditar.Visibility = Visibility.Visible;
            btnAnadir.Visibility = Visibility.Collapsed;
            btnConfirmar.Visibility = Visibility.Collapsed;
            btnAnadirNuevo.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
            dialogProveedores.IsEnabled = false;
            comboProveedores.IsEnabled = false;
            edt_codigo_barras.IsEnabled = false;
            txtWarning.Visibility = Visibility.Collapsed;
            EditarActivado = false;
        }

        public void E02EditarProducto()
        {
            btnCancelar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Collapsed;
            btnAnadir.Visibility = Visibility.Collapsed;
            btnConfirmar.Visibility = Visibility.Visible;
            btnAnadirNuevo.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            dialogProveedores.IsEnabled = true;
            comboProveedores.IsEnabled = true;
            EditarActivado = true;
        }


        public ProductosView()
        {
            InitializeComponent();
            E00EstadoInicial();
        }
    }
}
