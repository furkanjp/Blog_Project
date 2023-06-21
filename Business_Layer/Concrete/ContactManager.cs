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
	public class ContactManager:IContactService
	{
		IContactDal _contactDal;

		public ContactManager(IContactDal contactDal)
		{
			_contactDal = contactDal;
		}

		public void ContactAdd(Contact contact)
		{
			_contactDal.Insert(contact);	
		}
        public List<Contact> GetList()
        {
            return _contactDal.GetListAll();
        }
        public Contact TGetById(int id)
        {
            return _contactDal.GetById(id);
        }
    }
}
