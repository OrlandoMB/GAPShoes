using GAP.WebApi.Persistence.Entities;
using GAP.WebApi.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Application.Articles
{
    public class ArticleApplication
    {

        public List<Model.Articles> GetAllArticles()
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                var storeList = _unitOfWork.ArticlesRepository.GetAll().
                    Select(s => new Model.Articles
                    {
                       Id = s.Id,
                       Description = s.Description,
                       Name = s.Name,
                       Price = s.Price,
                       Store_Id = s.Store_Id,
                       TotalInShelf = s.TotalInShelf,
                       TotalInVault = s.TotalInVault
                    });

                return storeList.ToList();
            }
        }

        public Model.Articles GetArticle(int articleId)
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                var article = _unitOfWork.ArticlesRepository.GetAll()
                    .Where(w=> w.Id == articleId)
                    .Select(s => new Model.Articles
                    {
                        Id = s.Id,
                        Description = s.Description,
                        Name = s.Name,
                        Price = s.Price,
                        Store_Id = s.Store_Id,
                        TotalInShelf = s.TotalInShelf,
                        TotalInVault = s.TotalInVault
                    }).First();

                return article;
            }
        }

        public Boolean CreateArticle(Model.Articles newArticle)
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                Article _article = new Article();

                _article.Description = newArticle.Description;
                _article.Name = newArticle.Name;
                _article.Price = newArticle.Price;
                _article.Store_Id = newArticle.Store_Id;
                _article.TotalInShelf = newArticle.TotalInShelf;
                _article.TotalInVault = newArticle.TotalInVault; 

                _unitOfWork.ArticlesRepository.Insert(_article);
                _unitOfWork.Save();

                return true;
            }
        }



        public Boolean UpdateArticle(Model.Articles updArticle)
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                Article _article = _unitOfWork.ArticlesRepository.GetById(updArticle.Id);

                _article.Description = updArticle.Description;
                _article.Name = updArticle.Name;
                _article.Price = updArticle.Price;
                _article.Store_Id = updArticle.Store_Id;
                _article.TotalInShelf = updArticle.TotalInShelf;
                _article.TotalInVault = updArticle.TotalInVault;

                _unitOfWork.Save();

                return true;
            }
        }


        public void DeleteArticle(int articleId)
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                Article _article = _unitOfWork.ArticlesRepository.GetById(articleId);
                _unitOfWork.ArticlesRepository.Delete(_article);
                _unitOfWork.Save();
            }
        }


    }
}
