using FerreteriaMVVM.Commands;
using FerreteriaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.ViewModels
{
    class ConsultasViewModel : ViewModelBase
    {
        
        public ICommand ConsultarPorIdFacturaCommand { get; set; }
        public ICommand UpdateClientsCommand { get; set; }
        public ICommand ConsultaPorDNIClienteCommand { get; set; }
        public ICommand ConsultarPorFechaCommand { get; set; }
        public ICommand ConsultarPorDNIFechasCommand { get; set; }

        private ObservableCollection<ClienteModel> listaClientes { get; set; }
        public ObservableCollection<ClienteModel> ListaClientes
        {
            get { return listaClientes; }
            set
            {
                listaClientes = value;
                OnPropertyChanged(nameof(ListaClientes));
            }
        }

        public DateTime FechaSeleccionada { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }


        public ClienteModel Cliente { get; set; }

        public int IdFactura { get; set; }



        public UpdateViewCommand updateViewCommand { get; set; }

        public ConsultasViewModel(UpdateViewCommand updateViewCommand)
        {
            this.updateViewCommand = updateViewCommand;

            ConsultarPorIdFacturaCommand = new ConsultarPorIdFacturaCommand(this);
            UpdateClientsCommand = new UpdateClientsCommand(this);
            ConsultaPorDNIClienteCommand = new ConsultaPorDNIClienteCommand(this);
            ConsultarPorFechaCommand = new ConsultarPorFechaCommand(this);
            ConsultarPorDNIFechasCommand = new ConsultarPorDNIFechasCommand(this);

            ListaClientes = new ObservableCollection<ClienteModel>();
            FechaSeleccionada = DateTime.Today;
            FechaInicio = DateTime.Today;
            FechaFin = DateTime.Today;
        }

    }
}
