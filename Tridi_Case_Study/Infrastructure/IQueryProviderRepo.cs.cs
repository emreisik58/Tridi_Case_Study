using System.Collections.Generic;
using Tridi_Case_Study.Models;

namespace Tridi_Case_Study.Infrastructure
{
    public interface IQueryProviderRepo
    {

        public int add(User user);
        public int delete(User user);
        public User getByUserName(string UserName);
        public bool getUserControl(string UserName, string Password);
        public User getByUserId(int id);
        public List<User> getByListUser();
        public int SaveChanges();

    }
}
