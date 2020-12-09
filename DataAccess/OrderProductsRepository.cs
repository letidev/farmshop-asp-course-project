using FarmShop.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FarmShop.DataAccess {
    public class OrderProductsRepository : BaseRepository<OrderProduct> {
        public OrderProductsRepository() { }
        public OrderProductsRepository(UnitOfWork uow) : base(uow) { }

        protected override IQueryable<OrderProduct> CascadeInclude(IQueryable<OrderProduct> query) {
            return query.Include(op => op.Product).Include(op => op.Order);
        }
    }
}
