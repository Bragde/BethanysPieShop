using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BethanysPieShop.Models
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly AppDbContext db;

        public CategoryRepository(AppDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<Category> AllCategories => db.Categorys;
    }
}
