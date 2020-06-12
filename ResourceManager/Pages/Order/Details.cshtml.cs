using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager
{
    [AuthorizeRoles(Role.Admin)]
    public class DetailsModel : PageModel
    {
        private readonly ResourceManager.Dal.ResourceManagerContext _context;
        private readonly UserManager<Worker> _userManager;

        public DetailsModel(ResourceManager.Dal.ResourceManagerContext context,
            UserManager<Worker> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        [BindProperty]
        public Order Order { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Order = await _context.Orders
                .Include(o => o.ApprovedBy)
                .Include(o => o.OrderStatus)
                .Include(o => o.OrderedBy)
                .Include(o => o.Supplier)
                .Include(o => o.Supply).FirstOrDefaultAsync(m => m.Id == id);

            var OrderItems = await _context.OrderItems.Where(o => o.OrderId == Order.Id)
                .Include(i => i.Resource)
                .ToListAsync();

            Order.OrderItems = OrderItems;


            if (Order == null)
            {
                return NotFound();
            }
            OrderId = Order.Id;
            return Page();
        }

        [BindProperty]
        public int OrderId { get; set; }

        public async Task<IActionResult> OnPostApproveAsync()
        {
            var order = await _context.Orders.FindAsync(OrderId);

            order.ApprovedById = (await _userManager.GetUserAsync(User)).Id;

            order.OrderStatusId = _context.OrderStatuses.Where(s => s.Name.Equals("Підтверджене")).Single().Id;

            await _context.SaveChangesAsync();

            return await OnGetAsync(OrderId);
        }
    }
}
