using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class ContactManager : IContactService
    {
        private readonly ContactManager _contactManager;

        public ContactManager(ContactManager contactManager)
        {
            _contactManager = contactManager;
        }

        public void TAdd(Contact entity)
        {
            _contactManager.TAdd(entity);
        }

        public void TDelete(Contact entity)
        {
            _contactManager.TDelete(entity);
        }

        public Contact TGetByID(int id)
        {
          return _contactManager.TGetByID(id);
        }

        public List<Contact> TGetListAll()
        {
            return _contactManager.TGetListAll();
        }

        public void TUpdate(Contact entity)
        {
           _contactManager.TUpdate(entity);
        }
    }
}
