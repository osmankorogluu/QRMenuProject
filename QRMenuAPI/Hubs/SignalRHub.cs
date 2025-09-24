using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace QRMenuAPI.Hubs
{
    public class SignalRhub : Hub
    {
        private readonly SignalRContext _context;

        // DI ile context alıyoruz
        public SignalRhub(SignalRContext context)
        {
            _context = context;
        }

        public async Task SendCategoryCount()
        {
            var value = _context.Categories.Count();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }
    }
}
