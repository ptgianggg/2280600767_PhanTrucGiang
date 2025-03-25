using _2280600767_PhanTrucGiang.Extensions;
using _2280600767_PhanTrucGiang.Models;
using _2280600767_PhanTrucGiang.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace _2280600767_PhanTrucGiang.Controllers
{
    [Authorize]
    public class ShoppingCartController : Controller
    {
        private readonly IMonAnRepository _monAnRepository;
        private readonly GiangDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;

        public ShoppingCartController(GiangDbContext context, UserManager<ApplicationUser> userManager, IMonAnRepository monAnRepository)
        {
            _monAnRepository = monAnRepository;
            _context = context;
            _userManager = userManager;
        }

        // ✅ Cập nhật AddToCart để hỗ trợ AJAX (Trả về JSON)
        [Authorize]
        [HttpPost]
        public IActionResult AddToCart(string productId, int quantity)
        {
            if (string.IsNullOrEmpty(productId) || quantity <= 0)
            {
                return Json(new { success = false, message = "Sản phẩm không hợp lệ!" });
            }

            var product = _context.MonAn.Find(productId);
            if (product == null)
            {
                return Json(new { success = false, message = "Không tìm thấy sản phẩm!" });
            }

            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            cart.AddItem(new CartItem
            {
                ProductId = productId,
                Name = product.TenMonAn,
                Price = (decimal)product.Dongia,
                Quantity = quantity
            });

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, message = "Thêm vào giỏ hàng thành công!", cartCount = cart.Items.Count });
        }


        // ✅ Hiển thị giỏ hàng
        public IActionResult Index()
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            return View(cart);
        }

        // ✅ Xóa sản phẩm khỏi giỏ hàng
        public IActionResult RemoveFromCart(string productId)
        {
            if (string.IsNullOrEmpty(productId))
            {
                return Json(new { success = false, message = "Sản phẩm không hợp lệ!" });
            }

            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart != null)
            {
                cart.RemoveItem(productId);
                HttpContext.Session.SetObjectAsJson("Cart", cart);
            }

            return Json(new { success = true, message = "Sản phẩm đã được xóa!", cartCount = cart.Items.Count });
        }

        public IActionResult IncreaseQuantity(string productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null)
            {
                item.Quantity++;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, cart });
        }

        public IActionResult DecreaseQuantity(string productId)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart") ?? new ShoppingCart();
            var item = cart.Items.FirstOrDefault(i => i.ProductId == productId);

            if (item != null && item.Quantity > 1)
            {
                item.Quantity--;
            }

            HttpContext.Session.SetObjectAsJson("Cart", cart);

            return Json(new { success = true, cart });
        }

        

        // ✅ Xử lý đặt hàng
        public IActionResult Checkout()
        {
            return View(new Order());
        }

        [HttpPost]
        public async Task<IActionResult> Checkout(Order order)
        {
            var cart = HttpContext.Session.GetObjectFromJson<ShoppingCart>("Cart");
            if (cart == null || !cart.Items.Any())
            {
                return Json(new { success = false, message = "Giỏ hàng của bạn đang trống!" });
            }

            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Bạn chưa đăng nhập!" });
            }

            order.UserId = user.Id;
            order.OrderDate = DateTime.UtcNow;
            order.TotalPrice = cart.Items.Sum(i => i.Price * i.Quantity);
            order.OrderDetails = cart.Items.Select(i => new OrderDetail
            {
                ProductId = i.ProductId,
                Quantity = i.Quantity,
                Price = i.Price
            }).ToList();

            await _context.Orders.AddAsync(order);
            await _context.SaveChangesAsync();

            HttpContext.Session.Remove("Cart");
            return Json(new { success = true, message = "Đặt hàng thành công!", orderId = order.Id });
        }
    }
}
