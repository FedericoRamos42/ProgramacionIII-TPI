using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Adress
    {
        public string Street {  get; set; } = string.Empty;
        public string Province {  get; set; } = string.Empty;
        public string City { get; set; } = string.Empty ;
        public string PostalCode { get; set; } = string.Empty;
    }
}
