using Business_Layer.Abstract;
using DataAccess_Layer.Abstract;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
	public class AboutManager: IAboutServices
	{
		IAboutDal _aboutdal;

		public AboutManager(IAboutDal aboutdal)
		{
			_aboutdal = aboutdal;
		}

        public About TGetById(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> GetList()
		{
			return _aboutdal.GetListAll();
		}

        public void TAdd(About t)
        {
            throw new NotImplementedException();
        }

        public void TDelete(About t)
        {
            throw new NotImplementedException();
        }

        public void TUpdate(About t)
        {
            throw new NotImplementedException();
        }
    }
}
