using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOs
{
    public class AreaCreateDto
    {
        [Required(ErrorMessage = ("name is requiered"))]
        [MaxLength(100, ErrorMessage = "name must have less than 100 characters")]
        public string Name { get; set; } = string.Empty;
    }
}
