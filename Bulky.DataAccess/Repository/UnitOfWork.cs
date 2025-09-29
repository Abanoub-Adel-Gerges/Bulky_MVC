using BulkyBook.DataAccess.Data;
using BulkyBook.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BulkyBook.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public ICategoryRepository Category { get; private set; }
        public ICompanyRepository Company { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository ShoppingCart { get; private set; }
        public IApplicationUserRepository ApplicationUser { get; private set; }
        public IOrderHeaderRepository OrderHeader { get; private set; }
        public IOrderDetailRepository OrderDetail { get; private set; }
        public IProductImageRepository ProductImage { get; private set; }
        public UnitOfWork(ApplicationDbContext db)
        {
            this._db = db;
            this.ProductImage = new ProductImageRepository(_db);
            this.ShoppingCart = new ShoppingCartRepository(_db);
            this.Category = new CategoryRepository(_db);
            this.Product = new ProductRepository(_db);
            this.Company = new CompanyRepository(_db);
            this.ApplicationUser = new ApplicationUserRepository(_db);
            this.OrderHeader = new OrderHeaderRepository(_db);
            this.OrderDetail = new OrderDetailRepository(_db);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
