using GAP.WebApi.Persistence.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GAP.WebApi.Application.Stores
{
    public class StoreApplication
    {

        public List<Model.Stores> GetAllStores()
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                var storeList = _unitOfWork.StoresRepository.GetAll().Select(s => new Model.Stores
                {
                    Id = s.Id,
                    Address = s.Address,
                    Name = s.Name
                });

                return storeList.ToList();
            }
        }
            


        public Model.Stores GetStore(int storeId)
        {
            using (UnitOfWork _unitOfWork = new UnitOfWork())
            {
                var store = _unitOfWork.StoresRepository.GetAll().
                    Where(w => w.Id == storeId).
                    Select(s => new Model.Stores
                    {
                        Id = s.Id,
                        Address = s.Address,
                        Name = s.Name
                    }).FirstOrDefault();

                return store;
            }
        }



    }
}
