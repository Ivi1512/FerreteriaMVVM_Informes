using FerreteriaMVVM.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FerreteriaMVVM.ViewModels
{
    class MainViewModel : ViewModelBase
    {
        private ViewModelBase selectedViewModel { set; get; }

        public ViewModelBase SelectedViewModel
        {
            get { return selectedViewModel; }
            set
            {
                selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand UpdateViewCommand { set; get; }

        public MainViewModel()
        {
            selectedViewModel = new BienvenidaViewModel();

            UpdateViewCommand = new UpdateViewCommand(this);
        }

    }
}
