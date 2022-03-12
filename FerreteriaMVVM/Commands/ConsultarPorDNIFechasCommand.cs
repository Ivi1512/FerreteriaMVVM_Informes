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
    class ConsultarPorDNIFechasCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(consultasViewModel.Cliente != null)
            {
                bool okConsulta = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeDNIFechas(consultasViewModel.Cliente.DNI, consultasViewModel.FechaInicio, consultasViewModel.FechaFin);
                if (okConsulta)
                {
                    consultasViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("No se encontraron registos con ese DNI entre esas fechas", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                bool okConsulta = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeFechas(consultasViewModel.FechaInicio, consultasViewModel.FechaFin);
                if (okConsulta)
                {
                    consultasViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("No se encontraron registos entre esas fechas", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }



        }

        public ConsultasViewModel consultasViewModel { get; set; }
        public ConsultarPorDNIFechasCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
