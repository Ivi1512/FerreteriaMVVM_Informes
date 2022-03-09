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
    class ProveedoresViewModel : ViewModelBase
    {
        private ProveedoresModel currentProvedor { set; get; }
        public ProveedoresModel CurrentProveedor 
        {
            get => currentProvedor is null ? currentProvedor = new ProveedoresModel() : currentProvedor;
            set
            {
                currentProvedor = value;
                OnPropertyChanged(nameof(CurrentProveedor));
            }
        }


        private ProveedoresModel selectedProvedor { set; get; }
        public ProveedoresModel SelectedProveedor
        {
            get => selectedProvedor is null ? selectedProvedor = new ProveedoresModel() : selectedProvedor;
            set
            {
                selectedProvedor = value;
                OnPropertyChanged(nameof(SelectedProveedor));
            }
        }

        public ICommand ProveedoresCommand { set; get; }

        public ICommand LimpiarFormularioCommand { set; get; }

        public ICommand CrearProveedorCommand { set; get; }

        public ICommand EditarProveedoresCommand { set; get; }

        public ICommand BorrarProveedorCommand { set; get; }

        public ProveedoresViewModel()
        {
            ProveedoresCommand = new ProveedoresCommand(this);
            LimpiarFormularioCommand = new LimpiarFormularioCommand();
            CrearProveedorCommand = new CrearProveedorCommand();
            EditarProveedoresCommand = new EditarProveedoresCommand();
            BorrarProveedorCommand = new BorrarProveedorCommand();
        }
    }
}
