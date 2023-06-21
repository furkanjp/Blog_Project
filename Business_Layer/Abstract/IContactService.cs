using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
	public interface IContactService
	{
		void ContactAdd(Contact contact);
		
	}
}
