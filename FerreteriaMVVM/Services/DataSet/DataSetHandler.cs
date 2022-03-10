using FerreteriaMVVM.Models;
using FerreteriaMVVM.Services.DataSet.DataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Services.DataSet
{
    class DataSetHandler
    {
        private static clientesTableAdapter clientesAdapter = new clientesTableAdapter();
        private static InformesTableAdapter informesAdapter = new InformesTableAdapter();

        public static DataTable GetDataByIdFactura(string id_factura)
        {
            return informesAdapter.GetDataByIdFactura(id_factura);
        }

        public static ObservableCollection<ClienteModel> getAllClientes()
        {
            DataTable clientes = clientesAdapter.GetData();
            ObservableCollection<ClienteModel> listaClientes = new ObservableCollection<ClienteModel>();

            foreach (DataRow cliente in clientes.Rows)
            {
                ClienteModel myCliente = new ClienteModel();
                myCliente.DNI = cliente["DNI"].ToString();
                myCliente.Nombre = cliente["nombre"].ToString();
                myCliente.Direccion = cliente["direccion"].ToString();
                myCliente.Telefono = cliente["telefono"].ToString();
                myCliente.Email = cliente["email"].ToString();
                listaClientes.Add(myCliente);
            }
            return listaClientes;

        }
    }
}
