using FarmShop.Entities;

namespace FarmShop.DataAccess {
    public class ProductsRepository : BaseRepository<Product> {
        public ProductsRepository() { }
        public ProductsRepository(UnitOfWork uow) : base(uow) { }
    }
}
