using GAP.Application.Articles;
using GAP.Application.Stores;
using GAP.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GAP.Presentation.Controllers
{

    public class ArticlesController : Controller
    {
        // WEB API BASE URL
        private static String BASE_URL = GAP.Presentation.Properties.Settings.Default.GAPWebApiBaseUrl.ToString();

        ArticlesApplication app = new ArticlesApplication(BASE_URL);

        public ActionResult Index()
        {
            try
            {

                Models.ArticlesModel model = new Models.ArticlesModel();
                model.ListArticles = app.GetAllArticles();

                return View(model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        public ActionResult AddArticle()
        {
            try
            {
                Models.ArticlesModel model = new Models.ArticlesModel();
                model.ListStores = GetStores();

                return View("AddArticles", model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        private IEnumerable<SelectListItem> GetStores()
        {
            try
            {
                StoresApplication storesApp = new StoresApplication();

                var stores = storesApp.GetAllStores()
                            .Select(st =>
                                    new SelectListItem
                                    {
                                        Value = st.Id.ToString(),
                                        Text = st.Name
                                    });

                return new SelectList(stores, "Value", "Text");
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        [HttpPost]
        public ActionResult Create(Models.ArticlesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Articles newArticle = new Articles();
                    newArticle.Name = model.Name;
                    newArticle.Description = model.Description;
                    newArticle.Price = model.Price;
                    newArticle.Store_Id = model.Store_Id;
                    newArticle.TotalInShelf = model.TotalInShelf;
                    newArticle.TotalInVault = model.TotalInVault;

                    app.CreateArticle(newArticle);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ListStores = GetStores();
                    return View("AddArticles", model);
                }
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [HttpGet]
        public ActionResult Edit(int id)
        {
            try
            {
                Models.ArticlesModel model = new Models.ArticlesModel();

                var editArticle = app.GetArticle(id);
                model.ListStores = GetStores();

                model.Name = editArticle.Name;
                model.Description = editArticle.Description;
                model.Price = editArticle.Price;
                model.TotalInShelf = editArticle.TotalInShelf;
                model.TotalInVault = editArticle.TotalInVault;
                model.Store_Id = editArticle.Store_Id;

                return View("EditArticles", model);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }


        [HttpPost]
        public ActionResult Edit(Models.ArticlesModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    Articles upArticle = new Articles();
                    upArticle.Id = model.Id;
                    upArticle.Name = model.Name;
                    upArticle.Description = model.Description;
                    upArticle.Price = model.Price;
                    upArticle.Store_Id = model.Store_Id;
                    upArticle.TotalInShelf = model.TotalInShelf;
                    upArticle.TotalInVault = model.TotalInVault;

                    app.UpdateArticle(upArticle);
                    return RedirectToAction("Index");
                }
                else
                {
                    model.ListStores = GetStores();
                    return View("EditArticles", model);
                }
            }
            catch
            {
                return View("Error");
            }
        }

       

        // GET: Articles/Delete/5
        [HttpGet]
        public ActionResult Delete(int id)
        {
            try
            {
                app.DeleteArticle(id);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        
    }
}
