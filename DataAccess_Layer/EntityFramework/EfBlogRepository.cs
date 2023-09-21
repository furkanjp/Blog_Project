using DataAccess_Layer.Abstract;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.Repositories;
using Entity_Layer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.EntityFramework
{

    public class EfBlogRepository : GenericRepository<Blog>, IBlogDal
    {
        public EfBlogRepository()
        {
        }

        public EfBlogRepository(Context context) : base(context)
        {

        }

        public List<Blog> GetListWithCategory()
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).ToList();
            }
        }

        public List<Blog> GetListWithCategoryByWriter(int id)
        {
            using (var c = new Context())
            {
                return c.Blogs.Include(x => x.Category).Where(X => X.WriterID == id).ToList();
            }
        }
    }
}
