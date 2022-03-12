using FerreteriaMVVM.Services.DataSet;
using FerreteriaMVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.Commands
{
    class UpdateClientsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.Equals("consulta"))
            {
                consultasViewModel.ListaClientes = DataSetHandler.getAllClientes();
            }
            else if(parameter.Equals("formulario"))
            {
                formularioViewModel.ListaClientes = DataSetHandler.getAllClientes();
            }
        }


        private FormularioViewModel formularioViewModel { set; get; }
        public UpdateClientsCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }

        private ConsultasViewModel consultasViewModel { set; get; }
        public UpdateClientsCommand(ConsultasViewModel consultasViewModel)
        {
            this.consultasViewModel = consultasViewModel;
        }
    }
}
