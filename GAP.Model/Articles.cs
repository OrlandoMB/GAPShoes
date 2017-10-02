using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Model
{
    public class Articles
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public Double Price { get; set; }
        public int TotalInShelf { get; set; }
        public int TotalInVault { get; set; }
        public int Store_Id { get; set; }
        public Stores Store { get; set; }
    }
}
