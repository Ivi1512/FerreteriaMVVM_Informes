using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Models
{
    class FacturaModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        private DateTime fechaFactura { get; set; }
        public DateTime FechaFactura
        {
            get { return fechaFactura; }
            set
            {
                fechaFactura = value;
                OnPropertyChanged(nameof(FechaFactura));
            }
        }


        private ClienteModel clienteFactura{ get; set; }
        public ClienteModel ClienteFactura
        {
            get { return clienteFactura; }
            set
            {
                clienteFactura = value;
                OnPropertyChanged(nameof(ClienteFactura));
            }
        }

        public ObservableCollection<ProductoCantidadModel> ListaProductosCantidadFactura { get; set; }


        private double precioTotalFactura{ get; set; }
        public double PrecioTotalFactura
        {
            get { return precioTotalFactura; }
            set
            {
                precioTotalFactura = value;
                OnPropertyChanged(nameof(PrecioTotalFactura));
            }
        }

    }
}
