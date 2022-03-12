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
    class ConsultaPorDNIClienteCommand : ICommand
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
                bool okConsulta = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeCliente(consultasViewModel.Cliente.DNI);
                if (okConsulta)
                {
                    consultasViewModel.updateViewCommand.Execute("report");
                }
                else
                {
                    MessageBox.Show("No se encontró ningún registro para el DNI indicado", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);
                }
            }
            else
            {
                MessageBox.Show("Debes seleccionar un cliente", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);

            }


        }

        public ConsultasViewModel consultasViewModel { get; set; }
        public ConsultaPorDNIClienteCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
