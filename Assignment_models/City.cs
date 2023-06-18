using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment_models
{
    public class City
    {
        [Key]
        public int Id { get; set; }
        public string Country { get; set; }
    }
}
