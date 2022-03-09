using FerreteriaMVVM.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.ViewModels
{
    public class ViewModelBase : INotifyPropertyChanged
    {
        #region Notify
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName = null)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        private ObservableCollection<ProveedoresModel> listaProveedores;
        public ObservableCollection<ProveedoresModel> ListaProveedores
        {
            get => listaProveedores is null ? listaProveedores = new ObservableCollection<ProveedoresModel>() : listaProveedores;
            set
            {
                if (listaProveedores != value)
                {
                    listaProveedores = value;
                    OnPropertyChanged();
                }
            }
        }

    }
}
