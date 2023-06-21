using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Abstract
{
    public interface IMessage2Service:IGenericSerivce<Message2>
    {
        List<Message2> GetInboxListByWriter(int id);
        List<Message2> GetSendBoxListByWriter(int id);
    }
}
