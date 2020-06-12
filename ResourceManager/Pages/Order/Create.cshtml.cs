using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ResourceManager.Authorize;
using ResourceManager.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ResourceManager
{
    [AuthorizeRoles(Role.Admin)]
    public class CreateModel : PageModel
    {
        private readonly ResourceManager.Dal.ResourceManagerContext _context;
        private readonly UserManager<Worker> _userManager;

        public CreateModel(ResourceManager.Dal.ResourceManagerContext context,
            UserManager<Worker> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public IActionResult OnGet()
        {
            ViewData["ApprovedById"] = new SelectList(_context.Workers, "Id", "Id");
            ViewData["OrderStatusId"] = new SelectList(_context.OrderStatuses, "Id", "Id");
            ViewData["OrderedById"] = new SelectList(_context.Workers, "Id", "Id");
            ViewData["SupplierId"] = new SelectList(_context.Suppliers, "Id", "Name");

            ViewData["ResourceId"] = new SelectList(_context.Resources, "Id", "Name");

            Order = new Order();

            Order.OrderItems = new List<OrderItem>()
            {
                new OrderItem(){},
                new OrderItem(){},
                new OrderItem(){},
            };

            return Page();
        }

        [BindProperty]
        public Order Order { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Order.OrderPrice = Order.OrderItems.Sum(s => s.Quantity * s.UnitPrice);
            Order.TotalPrice = Order.OrderPrice + Order.ShipmentPrice;
            Order.OrderStatusId = _context.OrderStatuses.Where(s => s.Name.Equals("Нове")).Single().Id;
            Order.OrderedById = (await _userManager.GetUserAsync(User)).Id;
            Order.OrderDate = DateTime.Now;

            var items = Order.OrderItems;
            Order.OrderItems = null;


            _context.Orders.Add(Order);
            await _context.SaveChangesAsync();
            items.ForEach(item => item.OrderId = Order.Id);
            _context.OrderItems.AddRange(items);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
