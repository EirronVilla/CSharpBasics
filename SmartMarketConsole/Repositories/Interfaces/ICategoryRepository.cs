using SmartMarketConsole.Models;

namespace SmartMarketConsole.Repositories.Interfaces
{
    public interface ICategoryRepository
    {
        public bool AddCategory(Category category);
        public Category? GetCategoryById(int categoryId);
        public void UpdateCategory(Category category);
        public void DeleteCategory(int categoryId);
        public ICollection<Category> GetAllCategories();
        public int GetNextCategoryId();
    }
}
