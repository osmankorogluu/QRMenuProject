using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class ProductManager : IProductService
    {
        private readonly ProductManager _productManager;

        public ProductManager(ProductManager productManager)
        {
            _productManager = productManager;
        }

        public void TAdd(Product entity)
        {
            _productManager.TAdd(entity);
        }

        public void TDelete(Product entity)
        {
            _productManager.TDelete(entity);    
        }

        public Product TGetByID(int id)
        {
            return _productManager.TGetByID(id);    
        }

        public List<Product> TGetListAll()
        {
            return _productManager.TGetListAll();
        }

        public void TUpdate(Product entity)
        {
            _productManager.TUpdate(entity);
        }
    }
}
