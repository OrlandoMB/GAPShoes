using GAP.WebApi.Persistence.DBContext;
using GAP.WebApi.Persistence.Entities;
using System;

namespace GAP.WebApi.Persistence.UnitOfWork
{
    public class UnitOfWork : IDisposable
    {

        private GAPShoesDbContext _context = new GAPShoesDbContext();
        private Repository<Store> _storeRepository;
        private Repository<Article> _articleRepository;


        public Repository<Store> StoresRepository
        {
            get
            {
                if (this._storeRepository == null)
                {
                    this._storeRepository = new Repository<Store>(_context);
                }
                return _storeRepository;
            }
        }


        public Repository<Article> ArticlesRepository
        {
            get
            {
                if (this._articleRepository == null)
                {
                    this._articleRepository = new Repository<Article>(_context);
                }
                return _articleRepository;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }


        #region Dispose Implementation

        private bool disposed = false;

        void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }

            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion

    }
}
