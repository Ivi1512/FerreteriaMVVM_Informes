using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class UpdateViewCommand : ICommand
    {

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            Console.WriteLine(parameter.ToString());
            string vista = parameter.ToString();
            if(vista.Equals("Bienvenida"))
            {
                MainViewModel.SelectedViewModel = new BienvenidaViewModel();
            }
            else if(vista.Equals("Proveedores"))
            {
                MainViewModel.SelectedViewModel = new ProveedoresViewModel();
            }
            else if(vista.Equals("Productos"))
            {
                MainViewModel.SelectedViewModel = new ProductosViewModel();
            }
            else if(vista.Equals("Formulario"))
            {
                MainViewModel.SelectedViewModel = new FormularioViewModel();
            }
            else if (vista.Equals("Consultas"))
            {
                MainViewModel.SelectedViewModel = new ConsultasViewModel(this);
            }
            else if (vista.Equals("report"))
            {
                MainViewModel.SelectedViewModel = reportViewModel;
            }
        }

        public MainViewModel MainViewModel { set; get; }
        public ReportViewModel reportViewModel { get; set; }

        public UpdateViewCommand(MainViewModel mainViewModel)
        {
            MainViewModel = mainViewModel;
            MainViewModel.SelectedViewModel = new BienvenidaViewModel();
            reportViewModel = new ReportViewModel();
        }
    }
}
