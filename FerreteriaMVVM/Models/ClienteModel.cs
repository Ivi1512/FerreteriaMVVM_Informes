using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Models
{
    class ClienteModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private string dni;
        public string DNI
        {
            get { return dni; }
            set
            {
                dni = value;
                OnPropertyChanged(nameof(DNI));
            }
        }

        private string nombre;
        public string Nombre
        {
            get { return nombre; }
            set
            {
                nombre = value;
                OnPropertyChanged(nameof(Nombre));
            }
        }

        private string direccion;
        public string Direccion
        {
            get { return direccion; }
            set
            {
                direccion = value;
                OnPropertyChanged(nameof(Direccion));
            }
        }

        private string telefono;
        public string Telefono
        {
            get { return telefono; }
            set
            {
                telefono = value;
                OnPropertyChanged(nameof(Telefono));
            }
        }


        private string email;
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public override string ToString()
        {
            return "DNI: " + DNI + ", Nombre: " + Nombre;
        }
    }
}
