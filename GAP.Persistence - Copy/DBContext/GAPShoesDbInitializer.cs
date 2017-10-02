using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.Persistence.DBContext
{
    public class GAPShoesDbInitializer : CreateDatabaseIfNotExists<GAPShoesDbContext>
    {
        protected override void Seed(GAPShoesDbContext context)
        {
            CreateInitialStores(context);
            CreateInitialArticles(context);
            base.Seed(context);
        }

        private void CreateInitialStores(GAPShoesDbContext database)
        {
            database.Stores.Add(new Entities.Store() { Name = "Store Poblado", Address = "Carrera 48 #1 D Sur 1" });
            database.Stores.Add(new Entities.Store() { Name = "Store Sabaneta", Address = "Carrera 43 #2 D Sur 2" });
            database.Stores.Add(new Entities.Store() { Name = "Store Envigado", Address = "Carrera 48 #3 D Sur 3" });

            database.SaveChanges();
        }

        private void CreateInitialArticles(GAPShoesDbContext database)
        {
            database.Articles.Add(new Entities.Article() {
                Name = "New Balance",
                Description = "Training Shoe Pro II",
                Price =44,
                Store_Id = 1,
                TotalInShelf =1000,
                TotalInVault =2000
            });

            database.Articles.Add(new Entities.Article() {
                Name = "Puma",
                Description = "Sport Speed Perfonrmance",
                Price = 60,
                Store_Id = 1,
                TotalInShelf = 1000,
                TotalInVault = 2000
            });



            database.Articles.Add(new Entities.Article() {
                Name = "Nike",
                Description = "Race Pro IV",
                Price = 80,
                Store_Id = 2,
                TotalInShelf = 1000,
                TotalInVault = 2000
            });

            database.Articles.Add(new Entities.Article() {
                Name = "Adidas",
                Description = "Cloud Foam Type 3",
                Price = 75,
                Store_Id = 2,
                TotalInShelf = 1000,
                TotalInVault = 2000
            });



            database.Articles.Add(new Entities.Article() {
                Name = "Saucony",
                Description = "Performance Pro Running",
                Price = 56,
                Store_Id = 3,
                TotalInShelf = 1000,
                TotalInVault = 2000
            });

            database.Articles.Add(new Entities.Article() {
                Name = "Kappa",
                Description = "Pro II Predator",
                Price = 38,
                Store_Id = 3,
                TotalInShelf = 1000,
                TotalInVault = 2000
            });

            database.SaveChanges();
        }
    }
}
