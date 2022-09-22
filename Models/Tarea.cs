using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace apitarea.Models
{
    public class Tarea
    {
        [Key]
        public int id { get; set; }

        [Required]
        
        public string idUnique { get; set; } = string.Empty;

        public string Nombres { get; set; } = string.Empty;

        public int flagAtendido { get; set; }

        public DateTime Fecha { get; set; } 
    }
}