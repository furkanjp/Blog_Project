using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
	public interface IBlogService:IGenericSerivce<Blog>
	{
		List<Blog> GetBlogListWithCategory();
		List<Blog> GetBlogListByWriter(int id);
	}
}
