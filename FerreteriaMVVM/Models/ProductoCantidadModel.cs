using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Models
{
    class ProductoCantidadModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private ProductosModel productoModel { get; set; }
        public ProductosModel ProductoModel
        {
            get { return productoModel; }
            set
            {
                productoModel = value;
                OnPropertyChanged(nameof(ProductoModel));
            }
        }

        private int cantidad { get; set; }
        public int Cantidad
        {
            get { return cantidad; }
            set
            {
                cantidad = value;
                OnPropertyChanged(nameof(Cantidad));
            }
        }

    }

        
}
