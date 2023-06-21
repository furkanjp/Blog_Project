using DataAccess_Layer.Abstract;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.Repositories;
using Entity_Layer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess_Layer.EntityFramework
{
    public class EfIMessage2Repository : GenericRepository<Message2>, IMessage2Dal
    {
        public List<Message2> GetInboxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Message2s.Include(x => x.SenderUser).Where(x => x.ReceiverID == id).ToList();
            }
        }
        
        public List<Message2> GetSendBoxWithMessageByWriter(int id)
        {
            using (var context = new Context())
            {
                return context.Message2s.Include(x => x.ReceiverUser).Where(x => x.SenderID == id).ToList();
            }
        }

    }
}