using QRMenu.EntityLayer.Entities;
using SignalR.BussinessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.BussinessLayer.Concrete
{
    public class FeatureManager : IFeatureService
    {
        private readonly FeatureManager _featureManager;

        public FeatureManager(FeatureManager featureManager)
        {
            _featureManager = featureManager;
        }

        public void TAdd(Feature entity)
        {
            _featureManager.TAdd(entity);
        }

        public void TDelete(Feature entity)
        {
           _featureManager.TDelete(entity);
        }

        public Feature TGetByID(int id)
        {
            return _featureManager.TGetByID(id);
        }

        public List<Feature> TGetListAll()
        {
            return _featureManager.TGetListAll();
        }

        public void TUpdate(Feature entity)
        {
            _featureManager.TUpdate(entity);
        }
    }
}
