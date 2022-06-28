using System.Collections.Generic;
using System.Linq;
using Tridi_Case_Study.Infrastructure;
using Tridi_Case_Study.Models;

namespace Tridi_Case_Study.Services
{
    public class QueryProviderRepo : IQueryProviderRepo
    {
        private TridiContext _context;

        public QueryProviderRepo(TridiContext context)
        {
            _context = context;
        }
        public int add(User user)
        {
             _context.Users.Add(user);
            return  SaveChanges();
        }

        public int delete(User user)
        {
            _context.Users.Remove(user);
           return SaveChanges();
        }

        public User getByUserName(string UserName)
        {
          return  _context.Users.Where(U => (U.userName == UserName)).FirstOrDefault();
        }

        public User getByUserId(int id)
        {
            return _context.Users.Where(U => (U.id == id)).FirstOrDefault();
        }

        public bool getUserControl(string UserName, string password) 
        {
           return _context.Users.Where(U => (U.userName == UserName && U.password == password)).Count()>0?true:false;
        }
        public List<User> getByListUser()
        {
            return _context.Users.Where(U => (U.id !=0)).ToList();
        }
        public int SaveChanges()
        {
            try
            {

                return  _context.SaveChanges();
            }
            catch (System.Exception ex)
            {

                throw ex;
            }
        }




    }
}
