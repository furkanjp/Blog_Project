using Business_Layer.Abstract;
using DataAccess_Layer.Abstract;
using DataAccess_Layer.Concrete;
using DataAccess_Layer.EntityFramework;
using Entity_Layer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business_Layer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentdal;

        public CommentManager(ICommentDal commentdal)
        {
            this._commentdal = commentdal;
        }

        public void CommentAdd(Comment comment)
        {
            _commentdal.Insert(comment);
        }

        public List<Comment> GetCommentWithBlog()
        {
            return _commentdal.GetListWithBlog();
        }

        public List<Comment> GetList(int id)
        {
            return _commentdal.GetListAll(x => x.BlogID == id);
        }
        public Comment TGetById(int id)
        {
            return _commentdal.GetById(id);
        }
        public void TDelete(Comment t)
        {
            _commentdal.Delete(t);
        }
        

    }
}
