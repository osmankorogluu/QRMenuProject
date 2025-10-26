using Microsoft.AspNetCore.SignalR;
using SignalR.BussinessLayer.Abstract;

namespace QRMenuAPI.Hubs
{
    public class SignalRhub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly IDiscountService _discountService;

        public SignalRhub(
            ICategoryService categoryService,
            IProductService productService,
            IOrderService orderService,
            IMoneyCaseService moneyCaseService,
            IMenuTableService menuTableService,
            IBookingService bookingService,
            IDiscountService discountService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _discountService = discountService;
        }

        // Kategori Sayısı
        public async Task SendCategoryCount()
        {
            var value = _categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", value);
        }

        // Ürün Sayısı
        public async Task SendProductCount()
        {
            var value = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", value);
        }

        public async Task ActiveCategoryCount()
        {
            var value = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", value);
        }
        public async Task PassiveCategoryCount()
        {
            var value = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", value);
        }

        // Aktif Sipariş Sayısı
        public async Task SendActiveOrderCount()
        {
            var value = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", value);
        }

        // Toplam Sipariş Sayısı
        public async Task SendTotalOrderCount()
        {
            var value = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", value);
        }

        // Bugünkü Toplam Kazanç
        public async Task SendTodayTotalPrice()
        {
            var value = _orderService.TTodayTotalPrice();
            await Clients.All.SendAsync("ReceiveTodayTotalPrice", value.ToString("0.00") + " ₺");
        }

        // Son Sipariş Fiyatı
       
        // Toplom Kasa Tutarı
        public async Task SendTotalMoneyCaseAmount()
        {
            var value = _moneyCaseService.ITotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", value.ToString("0.00") + " ₺");
        }

        // Masa Sayısı
        public async Task SendMenuTableCount()
        {
            var value = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", value);
        }

        // Rezervasyon Sayısı
        public async Task SendBookingCount()
        {
            var value = _bookingService.TGetListAll().Count;
            await Clients.All.SendAsync("ReceiveBookingCount", value);
        }

        // İndirim Sayısı
        public async Task SendDiscountCount()
        {
            var value = _discountService.TGetListAll().Count;
            await Clients.All.SendAsync("ReceiveDiscountCount", value);
        }

        // Ortalama Ürün Fiyatı
        public async Task SendAvgProductPrice()
        {
            var value = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveAvgProductPrice", value.ToString("0.00") + " ₺");
        }

        // En Pahalı Ürün İsmi
        public async Task SendProductNameByMaxPrice()
        {
            var value = _productService.TProductNameByMaxPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMaxPrice", value);
        }

        // En Ucuz Ürün İsmi
        public async Task SendProductNameByMinPrice()
        {
            var value = _productService.TProductNameByMinPrice();
            await Clients.All.SendAsync("ReceiveProductNameByMinPrice", value);
        }

        // Hamburger Kategorisindeki Ürün Sayısı
        public async Task SendProductCountByCategoryNameHamburger()
        {
            var value = _productService.TProductCountByCategoryNameHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameHamburger", value);
        }

        // İçecek Kategorisindeki Ürün Sayısı
        public async Task SendProductCountByCategoryNameDrink()
        {
            var value = _productService.TProductCountByCategoryNameDrink();
            await Clients.All.SendAsync("ReceiveProductCountByCategoryNameDrink", value);
        }

        // Ortalama Hamburger Fiyatı
        
    }
}