using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Persistence.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public int Store_Id { get; set; }

        [ForeignKey("Store_Id")]
        public virtual Store Store { get; set; }

    }
}
