using e_commerce_web.Data;
using e_commerce_web.Models.Domain;
using e_commerce_web.Repository.Interfaces;

namespace e_commerce_web.Repository
{
    public class SqlCategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbcontext _dbContext;
        public SqlCategoryRepository(ApplicationDbcontext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<Category?> GetCategoryByIdAsync(Guid categoryId)
        {
            var existingCategory = await _dbContext.Categories.FindAsync(categoryId);
            if (existingCategory == null)
            {
                return null;
            }
            return existingCategory;
        }
    }
}
