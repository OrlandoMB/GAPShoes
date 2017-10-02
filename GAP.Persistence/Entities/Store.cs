using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Persistence.Entities
{
    public class Store
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public string Address { get; set; }
    }
}
