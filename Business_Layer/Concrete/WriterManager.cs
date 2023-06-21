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
    public class WriterManager: IWriterService
    {
        IWriterDal _writerdal;

        public WriterManager(IWriterDal writerDal)
        {
            this._writerdal = writerDal;
        }

        public List<Writer> GetList()
        {
            throw new NotImplementedException();
        }

        public List<Writer> GetWriterById(int id)
        {
            return _writerdal.GetListAll(x => x.WriterID == id);
        }

        public void TAdd(Writer t)
        {
            _writerdal.Insert(t);
        }

        public void TDelete(Writer t)
        {
            throw new NotImplementedException();
        }

        public Writer TGetById(int id)
        {
           return _writerdal.GetById(id);
        }

        public void TUpdate(Writer t)
        {
            _writerdal.Update(t);
        }

       
    }
}
