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
    /// Lógica de interacción para ProveedoresView.xaml
    /// </summary>
    public partial class ProveedoresView : UserControl,INotifyPropertyChanged
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



        private void proveedoresListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            E01MostrarProveedor();
        }


        private void btnEditar_Click(object sender, RoutedEventArgs e)
        {
            E02EditarProveedor();
        }
        private void btnAnadir_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            E01MostrarProveedor();
        }

        private void btnBorrar_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void btnConfirmar_Click(object sender, RoutedEventArgs e)
        {
            E02EditarProveedor();
            edt_cif.IsEnabled = false;
        }

        public void E00EstadoInicial()
        {
            btnCancelar.Visibility = Visibility.Collapsed;
            btnEditar.Visibility = Visibility.Collapsed;
            btnAnadir.Visibility = Visibility.Visible;
            btnConfirmar.Visibility = Visibility.Collapsed;
            btnAnadirNuevo.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;

            edt_cif.IsEnabled = true;
            EditarActivado = true;
        }

        public void E01MostrarProveedor()
        {
            btnCancelar.Visibility = Visibility.Collapsed;
            btnEditar.Visibility = Visibility.Visible;
            btnAnadir.Visibility = Visibility.Collapsed;
            btnConfirmar.Visibility = Visibility.Collapsed;
            btnAnadirNuevo.Visibility = Visibility.Visible;
            btnBorrar.Visibility = Visibility.Visible;
            edt_cif.IsEnabled = false;
            EditarActivado = false;
        }

        public void E02EditarProveedor()
        {
            btnCancelar.Visibility = Visibility.Visible;
            btnEditar.Visibility = Visibility.Collapsed;
            btnAnadir.Visibility = Visibility.Collapsed;
            btnConfirmar.Visibility = Visibility.Visible;
            btnAnadirNuevo.Visibility = Visibility.Collapsed;
            btnBorrar.Visibility = Visibility.Collapsed;
            EditarActivado = true;
            edt_cif.IsEnabled = false;
        }


        public ProveedoresView()
        {
            InitializeComponent();

            E00EstadoInicial();
        }

        
    }
}
