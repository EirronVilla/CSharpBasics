using SmartMarketConsole.Models;

namespace SmartMarketConsole.Services.Interfaces
{
    public interface ICategoryService
    {
        public ICollection<Category> GetCategories();
        public Category? GetCategoryById(int categoryId);
        public bool AddCategory(string name, string description);
        public void DeleteCategory(int categoryId);
        public bool UpdateCategory(int categoryId, string name, string description);
    }
}
