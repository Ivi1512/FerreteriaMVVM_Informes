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
    class ConsultarPorIdFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            bool consultaOK = consultasViewModel.updateViewCommand.reportViewModel.GenerarInformeIdFactura(consultasViewModel.IdFactura);
            if(consultaOK)
            {
                consultasViewModel.updateViewCommand.Execute("report");

            }
            else
            {
                MessageBox.Show("No se encontraron registros con ese ID", "Informe", MessageBoxButton.OK, MessageBoxImage.Information);

            }




        }


        public ConsultasViewModel consultasViewModel { get; set; }
        public ConsultarPorIdFacturaCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
