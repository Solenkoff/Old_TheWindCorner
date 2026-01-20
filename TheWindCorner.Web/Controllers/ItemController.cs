namespace TheWindCorner.Web.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    using TheWindCorner.Data;
    using TheWindCorner.Data.Models.Entities;
    using TheWindCorner.Data.Models.Entities.Enums;
    using TheWindCorner.Web.ViewModels.Item;

    public class ItemController : BaseController
    {
        private readonly ApplicationDbContext dbContext;

        public ItemController(ApplicationDbContext _dbContext)
        {
            this.dbContext = _dbContext;          
        }

        [HttpGet]    
        public async Task<IActionResult> Index()
        {
            IEnumerable<Item> allItems = await this.dbContext
                .Items
                .ToArrayAsync();

            return View(allItems);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewData["Categories"] = Enum.GetValues(typeof(Category)).Cast<Category>();
            ViewData["ItemTypes"] = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();

            return this.View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddItemInputModel inputModel)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Categories"] = Enum.GetValues(typeof(Category)).Cast<Category>();
                ViewData["ItemTypes"] = Enum.GetValues(typeof(ItemType)).Cast<ItemType>();
                return View(inputModel);
            }

            Item item = new Item()
            {
                Category = inputModel.Category,
                ItemType = inputModel.ItemType,
                Title = inputModel.Title,
                Size = inputModel.Size ?? "-",
                Brand = inputModel.Brand ?? "-",
                Year = inputModel.Year,
                Description = inputModel.Description,
                IsApproved = false,
                IsDeleted = false,
                IsSold = false
            };
          
            await this.dbContext.Items.AddAsync(item);
            await this.dbContext.SaveChangesAsync();

            return this.RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public async Task<IActionResult> Details(string? id)
        { 
            Guid itemGuid = Guid.Empty;
            bool isGuidValid = this.IsGuidValid(id, ref itemGuid);
            if (!isGuidValid)
            {
                return RedirectToAction(nameof(Index));
            }

            Item? item = await this.dbContext
                .Items
                .FirstOrDefaultAsync(i => i.Id == itemGuid);
            if(item == null)
            {
                return RedirectToAction(nameof(Index)); 
            }

            return this.View(item);
        }
    }
}
