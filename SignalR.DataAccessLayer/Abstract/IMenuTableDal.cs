using QRMenu.EntityLayer.Entities;
using SignalR.DataAccessLayer.Migrations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SignalR.DataAccessLayer.Abstract
{
    public interface IMenuTableDal: IGenericDal<MenuTable>
    {
        int MenuTableCount();
    }
}
