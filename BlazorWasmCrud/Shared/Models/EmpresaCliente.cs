using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlazorWasmCrud.Shared.Models
{
    public class EmpresaCliente
    {
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required, EmailAddress]
        public string? Site { get; set; }

        public string? Segmento { get; set; }

    }
}
