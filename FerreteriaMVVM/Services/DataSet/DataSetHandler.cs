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
        private static facturaTableAdapter facturasAdapter = new facturaTableAdapter();
        private static detalleTableAdapter detallesAdapter = new detalleTableAdapter();

        public static DataTable GetDataByIdFactura(int id_factura)
        {
            return informesAdapter.GetDataByIdFactura(id_factura);
        }

        public static DataTable GetDataByDNI(string dni)
        {
            return informesAdapter.GetDataByDNICliente(dni);
        }

        public static DataTable GetDataByFecha(DateTime fecha)
        {
            return informesAdapter.GetDataByFecha(fecha.ToString());
        }

        public static DataTable GetDataByDNIFechas(string dni, DateTime fechaI, DateTime fechaF)
        {
            return informesAdapter.GetDataByClienteFechas(dni, fechaI.ToString(), fechaF.ToString());
        }

        public static DataTable GetDataByFechas(DateTime fechaI, DateTime fechaF)
        {
            return informesAdapter.GetDataByFechas(fechaI.ToString(), fechaF.ToString());
        }

        public static bool insertarFactura(FacturaModel factura)
        {
            try
            {
                facturasAdapter.Insert(factura.FechaFactura, (decimal?)factura.PrecioTotalFactura, factura.ClienteFactura.DNI);
                DataRow ultimoRegistro = facturasAdapter.GetData().Last();
                int idUltimaFactura = (int)ultimoRegistro["id_factura"];
                foreach (ProductoCantidadModel p in factura.ListaProductosCantidadFactura)
                {
                    detallesAdapter.Insert(p.ProductoModel.Descripcion, p.Cantidad, (decimal?)p.ProductoModel.Precio, p.ProductoModel._id, idUltimaFactura);
                }

                return true;
            }
            catch
            {
                return false;
            }

        }


        public static string GetClienteByDNI(string dni)
        {
            try
            {
                DataTable clienteDT = informesAdapter.GetDataByDNICliente(dni);
                DataRow clienteRow = clienteDT.Rows[0];
                string dniCliente = (string)clienteRow["DNI"];
                return dniCliente;
            }
            catch
            {
                return "";
            }

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
