using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories
{
    public interface ICategoryRepository
    {
        public bool AddCategory(Category category);
        public Category? GetCategoryById(int categoryId);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int categoryId);
        public List<Category> GetAllCategories();
    }
}
