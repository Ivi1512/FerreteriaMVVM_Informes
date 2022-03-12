using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services.DataSet;
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
    class GuardarFacturaCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            formularioViewModel.Factura.ListaProductosCantidadFactura = formularioViewModel.ListaProductosCantidad;
            string dni = DataSetHandler.GetClienteByDNI(formularioViewModel.Factura.ClienteFactura.DNI);
            if(dni.Equals(""))
            {
                MessageBox.Show("El DNI no existe");
            }
            else
            {
                formularioViewModel.Factura.ClienteFactura.DNI = dni;
                bool insertarOK = DataSetHandler.insertarFactura(formularioViewModel.Factura);
                if (!insertarOK)
                {
                    MessageBox.Show("No se pudo Insertar, llama al servicio técnico: 922335687");
                }
                else
                {
                    MessageBox.Show("La Factura se ha registrado correctamente");
                    formularioViewModel.Factura = new FacturaModel();
                }
            }
        }

        private FormularioViewModel formularioViewModel { set; get; }
        public GuardarFacturaCommand(FormularioViewModel formularioViewModel)
        {
            this.formularioViewModel = formularioViewModel;
        }
    }
}
