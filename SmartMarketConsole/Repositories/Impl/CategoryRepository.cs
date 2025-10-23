using SmartMarketConsole.Data;
using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;

namespace SmartMarketConsole.Repositories.Impl
{
    public  class CategoryRepository : ICategoryRepository
    {
        private readonly IDbContext _dbContext;

        public CategoryRepository(IDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public bool AddCategory(Category category)
        {
            try
            {
                _dbContext.CategoryStorage.Add(category.Id, category);
                return true;
            }
            catch (ArgumentException)
            {
                Console.WriteLine("A category with the same ID already exists.");
                return false;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            var removedSuccessfully = _dbContext.CategoryStorage.Remove(categoryId);
            if (!removedSuccessfully)
            {
                Console.WriteLine("Category not found.");
                throw new Exception("Category not found");
            }
        }

        public ICollection<Category> GetAllCategories()
        {
            try
            {
                return _dbContext.CategoryStorage.Values.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving categories: {ex.Message}");
                return new List<Category>();
            }
        }

        public Category? GetCategoryById(int categoryId)
        {
            try
            {
                var category = _dbContext.CategoryStorage[categoryId];
                if (category is null)
                {
                    throw new KeyNotFoundException();
                }

                return category;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Category not found.");
                return null;
            }
        }

        public int GetNextCategoryId()
        {
            return _dbContext.CategoryStorage.Count == 0 ? 1 : _dbContext.CategoryStorage.Keys.Max() + 1;
        }

        public void UpdateCategory(Category category)
        {
            try
            {
                _dbContext.CategoryStorage[category.Id] = category;
            }
            catch (KeyNotFoundException)
            {
                Console.WriteLine("Category not found.");
                throw new Exception("Category not found");
            }
        }
    }
}
