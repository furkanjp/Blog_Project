using Business_Layer.Abstract;
using DataAccess_Layer.Abstract;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal; //Üzerinde çalıştığım manager sınıfı için ef üzerinden değer oluşturma.
        public CategoryManager(ICategoryDal categoryDal)
        {
            this._categoryDal = categoryDal;
        }
        public Category TGetById(int id)
        {
            return _categoryDal.GetById(id);
        }

        public List<Category> GetList()
        {
            return _categoryDal.GetListAll();
        }
        public void TAdd(Category t)
        {
            _categoryDal.Insert(t);
        }

        public void TDelete(Category t)
        {
            _categoryDal.Delete(t);
        }

        public void TUpdate(Category t)
        {
            _categoryDal.Update(t);
        }
    }
}
