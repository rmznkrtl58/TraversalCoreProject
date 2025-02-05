using BusinessLogicLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogicLayer.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commenDal;

        public CommentManager(ICommentDal commenDal)
        {
            _commenDal = commenDal;
        }

        public void AddToTable(Comment t)
        {
            _commenDal.Insert(t);
        }

        public void DeleteFromTable(Comment t)
        {
            _commenDal.Delete(t);
        }

        public List<Comment> GetCommentWithDestination()
        {
            return _commenDal.GetCommentListByFilter(x => x.CommentState == true);
        }

        public List<Comment> GetListCommentByDestinationId(int id)
        {
           return _commenDal.GetListAll(x => x.DestinationId == id&&x.CommentState==true);
        }
        public Comment TGetById(int id)
        {
            return _commenDal.GetById(id);
        }

        public List<Comment> TGetListAll()
        {
           return _commenDal.GetListAll();
        }

        public void UpdateTheTable(Comment t)
        {
            _commenDal.Update(t);
        }
    }
}
