using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class SocialMediaManager : ISocialMediaService
    {
        private SocialMediaManager _socialMediaManager;

        public SocialMediaManager(SocialMediaManager socialMediaManager)
        {
            _socialMediaManager = socialMediaManager;
        }

        public void TAdd(SocialMedia entity)
        {
            _socialMediaManager.TAdd(entity);
        }
        

        public void TDelete(SocialMedia entity)
        {
           _socialMediaManager.TDelete(entity);
        }

        public SocialMedia TGetByID(int id)
        {
            return _socialMediaManager.TGetByID(id);
        }

        public List<SocialMedia> TGetListAll()
        {
            return _socialMediaManager.TGetListAll();
        }

        public void TUpdate(SocialMedia entity)
        {
            _socialMediaManager.TUpdate(entity);
        }
    }
}
