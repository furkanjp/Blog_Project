using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Abstract
{
    public interface IBlogDal:IGenericDal<Blog>
    {
        //category ile beraber listeyi getir, bu metot sadece bloklara özel çünkü dışarıdan category idsi aldığımız yer 
        
        List<Blog> GetListWithCategory();
        List<Blog> GetListWithCategoryByWriter(int id);

    }
}
