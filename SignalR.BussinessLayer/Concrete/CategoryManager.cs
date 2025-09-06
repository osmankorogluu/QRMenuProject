using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class CategoryManager : ICategoryService
    {
        private readonly CategoryManager _categoryManager;

        public CategoryManager(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        public void TAdd(Category entity)
        {
            _categoryManager.TAdd(entity);
        }

        public void TDelete(Category entity)
        {
            _categoryManager.TDelete(entity);
        }

        public Category TGetByID(int id)
        {
            return _categoryManager.TGetByID(id);
            
        }

        public List<Category> TGetListAll()
        {
           return _categoryManager.TGetListAll();
        }

        public void TUpdate(Category entity)
        {
            _categoryManager.TUpdate(entity);
        }
    }
}
