using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class ConsultarPorFechaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
           
            bool okConsulta = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeFecha(consultasViewModel.FechaSeleccionada);
            if (okConsulta)
            {
                consultasViewModel.updateViewCommand.Execute("report");
            }
            else
            {
                MessageBox.Show("No se encontró ningún registro para las fecha indicada", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);
            }
 
        }

        public ConsultasViewModel consultasViewModel { get; set; }
        public ConsultarPorFechaCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
