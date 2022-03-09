using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FerreteriaMVVM.Models
{
    public class ResponseModel
    {
        public object data { get; set; }
        public bool resultOK { get; set; }

        public ResponseModel()
        {
            data = "Error consulta";
            resultOK = false;
        }
    }
}
