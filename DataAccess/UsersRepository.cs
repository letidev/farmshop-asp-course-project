using FarmShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmShop.DataAccess {
    public class UsersRepository : BaseRepository<User> {
        public UsersRepository() { }

        public UsersRepository(UnitOfWork uow) : base(uow) { }

        protected override IQueryable<User> CascadeInclude(IQueryable<User> query) {
            return query.Include(u => u.Role);
        }
    }
}
