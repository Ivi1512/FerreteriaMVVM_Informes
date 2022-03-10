using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
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

namespace FerreteriaMVVM
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainViewModel();
            HabilitarControles("Bienvenida");
        }

        private void Btn_Click(object sender, RoutedEventArgs e)
        {
            HabilitarControles(((Button)sender).Content.ToString());
        }

        private void HabilitarControles(string Ventana)
        {
            switch (Ventana)
            {
                case "Bienvenida":
                    BtnBienvenida.IsEnabled = false;
                    BtnProveedores.IsEnabled = true;
                    BtnProductos.IsEnabled = true;
                    BtnFormulario.IsEnabled = true;
                    BtnConsultas.IsEnabled = true;
                    break;
                case "Proveedores":
                    BtnBienvenida.IsEnabled = true;
                    BtnProveedores.IsEnabled = false;
                    BtnProductos.IsEnabled = true;
                    BtnFormulario.IsEnabled = true;
                    BtnConsultas.IsEnabled = true;
                    break;
                case "Productos":
                    BtnBienvenida.IsEnabled = true;
                    BtnProveedores.IsEnabled = true;
                    BtnProductos.IsEnabled = false;
                    BtnFormulario.IsEnabled = true;
                    BtnConsultas.IsEnabled = true;
                    break;
                case "Formulario":
                    BtnBienvenida.IsEnabled = true;
                    BtnProveedores.IsEnabled = true;
                    BtnProductos.IsEnabled = true;
                    BtnFormulario.IsEnabled = false;
                    BtnConsultas.IsEnabled = true;
                    break;
                case "Consultas":
                    BtnBienvenida.IsEnabled = true;
                    BtnProveedores.IsEnabled = true;
                    BtnProductos.IsEnabled = true;
                    BtnFormulario.IsEnabled = true;
                    BtnConsultas.IsEnabled = false;
                    break;
            }
        }
    }
}
