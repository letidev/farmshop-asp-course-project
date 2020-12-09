using FarmShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmShop.DataAccess {
    public class OrdersRepository : BaseRepository<Order> {

        public OrdersRepository() { }
        public OrdersRepository(UnitOfWork uow) : base(uow) { }

        protected override IQueryable<Order> CascadeInclude(IQueryable<Order> query) {
            return query.Include(o => o.ParentUser);
        }
    }
}
