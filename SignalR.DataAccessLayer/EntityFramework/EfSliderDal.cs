using Microsoft.EntityFrameworkCore;
using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Abstract;
using SignalR.DataAccessLayer.Concrete;
using SignalR.DataAccessLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.EntityFramework
{
    public class EfSliderDal:GenericRepository<Slider>, ISliderDal
    {
        private readonly SignalRContext _context;

    public EfSliderDal(SignalRContext context) : base(context)
    {
        _context = context;
    }
    
    }
}
