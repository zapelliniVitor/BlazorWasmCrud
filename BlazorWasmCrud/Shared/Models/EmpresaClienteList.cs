using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Shared.Models
{
    public class EmpresaClienteList
    {
        public string SearchTerm { get; set; }
        public List<EmpresaCliente>? EmpresasClientes { get; set; }
        public int TotalPages { get; set; }
        public int PageNumber { get; set; }
    }
}
