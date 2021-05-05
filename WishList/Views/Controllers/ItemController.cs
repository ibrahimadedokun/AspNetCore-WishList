using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WishList.Data;
using WishList.Models;

namespace WishList.Controllers
{
    public class ItemController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ItemController(ApplicationDbContext context)
        {
            this._context = context;
        }

        public IActionResult Index()
        {
            var items = new List<Item>(_context.Items);
            return View("Index", items);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("Create");
        }

        [HttpPost]
        public IActionResult Create(Item item)
        {
            _context.Items.Add(item);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int Id)
        {
            var itemToBeDeleted = _context.Items.FirstOrDefault(i => i.Id == Id);
            if (itemToBeDeleted != null)
            {
                _context.Items.Remove(itemToBeDeleted);
            }
            return RedirectToAction("Index");
        }
    }
}
