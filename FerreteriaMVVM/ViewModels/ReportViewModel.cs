using FerreteriaMVVM.Services.DataSet;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.ViewModels
{
    class ReportViewModel : ViewModelBase
    {
        public string pdfData { get; set; }
        ReportViewer myReport { get; set; }
        ReportDataSource rds { get; set; }

        private string CurrentPath = Environment.CurrentDirectory;
        private string InformeNumFactura = "Reports/InformeNumFactura.rdlc";
        private string InformeCliente = "Reports/InformeCliente.rdlc";
        private string InformeFecha = "Reports/InformeFecha.rdlc";
        private string InformeClienteFechas = "Reports/InformeClienteFechas.rdlc";

        public ReportViewModel()
        {
            myReport = new ReportViewer();
            rds = new ReportDataSource();
        }


        public bool GenerarInformeIdFactura(int idFactura)
        {
            rds.Name = "Informes";
            DataTable dt = DataSetHandler.GetDataByIdFactura(idFactura);
            if(dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeNumFactura.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeNumFactura);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public bool GenerarInformeCliente(string dni)
        {
            rds.Name = "Informes";
            DataTable dt = DataSetHandler.GetDataByDNI(dni);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByDNI(dni);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeCliente.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeCliente);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool GenerarInformeFecha(DateTime fecha)
        {
            rds.Name = "Informes";
            DataTable dt = DataSetHandler.GetDataByFecha(fecha);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                rds.Value = DataSetHandler.GetDataByFecha(fecha);
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeFecha.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeCliente);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
            
        }


        public bool GenerarInformeDNIFechas(string dni, DateTime fechaI, DateTime fechaF)
        {
            rds.Name = "Informes";
            DataTable dt = DataSetHandler.GetDataByDNIFechas(dni, fechaI, fechaF);
            if(dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeDNIFechas.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeCliente);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public bool GenerarInformeFechas(DateTime fechaI, DateTime fechaF)
        {
            rds.Name = "Informes";
            DataTable dt = DataSetHandler.GetDataByFechas(fechaI, fechaF);
            if (dt.Rows.Count > 0)
            {
                rds.Value = dt;
                myReport.LocalReport.DataSources.Add(rds);
                myReport.LocalReport.ReportPath = "../../Reports/InformeDNIFechas.rdlc";
                //myReport.LocalReport.ReportPath = System.IO.Path.Combine(CurrentPath, InformeCliente);
                byte[] PDFBytes = myReport.LocalReport.Render(format: "PDF", deviceInfo: "");
                pdfData = "data:application/pdf;base64," + Convert.ToBase64String(PDFBytes);
                return true;
            }
            else
            {
                return false;
            }

        }


    }
}
