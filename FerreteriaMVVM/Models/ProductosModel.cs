using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Models
{
    public class ProductosModel : INotifyPropertyChanged, ICloneable
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public object Clone()
        {
            return MemberwiseClone();
        }

        private string id;
        public string _id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(_id));
            }
        }

        private ObservableCollection<ProveedoresModel> proveedores;
        public ObservableCollection<ProveedoresModel> Proveedores
        {
            get => proveedores is null ? proveedores = new ObservableCollection<ProveedoresModel>() : proveedores;
            set
            {
                proveedores = value;
                OnPropertyChanged(nameof(Proveedores));
            }
        }

        private string categoria;
        public string Categoria
        {
            get { return categoria; }
            set
            {
                categoria = value;
                OnPropertyChanged(nameof(Categoria));
            }
        }

        private string marca;
        public string Marca
        {
            get { return marca; }
            set
            {
                marca = value;
                OnPropertyChanged(nameof(Marca));
            }
        }

        private string material;
        public string Material
        {
            get { return material; }
            set
            {
                material = value;
                OnPropertyChanged(nameof(Material));
            }
        }

        private string referencia;
        public string Referencia
        {
            get { return referencia; }
            set
            {
                referencia = value;
                OnPropertyChanged(nameof(Referencia));
            }
        }

        private string descripcion;
        public string Descripcion
        {
            get { return descripcion; }
            set
            {
                descripcion = value;
                OnPropertyChanged(nameof(Descripcion));
            }
        }

        private double precio;
        public double Precio
        {
            get { return precio; }
            set
            {
                precio = value;
                OnPropertyChanged(nameof(Precio));
            }
        }

        private DateTime fechaEntrada;
        public DateTime FechaEntrada
        {
            get { return fechaEntrada; }
            set
            {
                fechaEntrada = value;
                OnPropertyChanged(nameof(FechaEntrada));
            }
        }

        

        private int stock;
        public int Stock
        {
            get { return stock; }
            set
            {
                stock = value;
                OnPropertyChanged(nameof(Stock));
            }
        }

        public string Nombre
        {
            get => _id + " " + referencia;
        }


        public override string ToString()
        {
            return "ID: " + _id + ", " + Descripcion + ", " + referencia;
        }

        public ProductosModel()
        {
            
        }

        public ProductosModel(string id, ObservableCollection<ProveedoresModel> proveedores, string categoria, string marca, string material, string referencia, string descripcion, double precio, DateTime fechaEntrada, int stock)
        {
            this.id = id;
            this.proveedores = proveedores;
            this.categoria = categoria;
            this.marca = marca;
            this.material = material;
            this.referencia = referencia;
            this.descripcion = descripcion;
            this.precio = precio;
            this.fechaEntrada = fechaEntrada;
            this.stock = stock;
        }
    }
}
