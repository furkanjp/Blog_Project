using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.Abstract
{
    //Metotlardan önce entity parametresi gönderiyoruz ve bu bir classa ait tüm değerleri kullanacak
    public interface IGenericDal<T>// where T : class
    {
        // t türünde t entity çağırıldı
        void Insert(T t); //ekle
        void Delete(T t); //Sil
        void Update(T t);//Güncelle
        List<T> GetListAll(); // Listele
        T GetById(int id); // İd'ye göre getir (find)
        List<T> GetListAll(Expression<Func<T, bool>> filter);
    }
}
