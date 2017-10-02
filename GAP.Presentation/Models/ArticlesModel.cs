using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using GAP.Model;
using System.Web.Mvc;

namespace GAP.Presentation.Models
{
    public class ArticlesModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public String Name { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public String Description { get; set; }

        [Required(ErrorMessage = "Price is required")]
        public Double Price { get; set; }

        [Display(Name = "Total In Shelf")]
        [Required(ErrorMessage = "Total In Shelf is required")]
        public int TotalInShelf { get; set; }

        [Display(Name= "Total In Vault")]
        [Required(ErrorMessage = "Total In Vault is required")]
        public int TotalInVault { get; set; }

        [Display(Name = "Store")]
        [Required(ErrorMessage = "Store is required")]
        public int Store_Id { get; set; }

        public List<Articles> ListArticles { get; set; }
        public IEnumerable<SelectListItem> ListStores { get; set; }
    }
}