using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entity_Layer.Concrete;

namespace DataAccess_Layer.Abstract
{
    public interface IMessage2Dal : IGenericDal<Message2>
    {
        List<Message2> GetInboxWithMessageByWriter(int id);
        List<Message2> GetSendBoxWithMessageByWriter(int id);
    }
}
