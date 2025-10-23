using SmartMarketConsole.Presentation.Views;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Presentation.Controllers
{
    public class CategoryController
    {
        private readonly ICategoryService _categoryService;
        private readonly CategoryView _categoryView;

        public CategoryController(ICategoryService categoryService, CategoryView categoryView)
        {
            _categoryService = categoryService;
            _categoryView = categoryView;
        }

        public void ListCategories()
        {
            var categories = _categoryService.GetCategories();
            _categoryView.DisplayCategories(categories);
        }

        public void AddCategory()
        {
            string name = _categoryView.EnterCategoryName();
            string description = _categoryView.EnterCategoryDescription();
            _categoryService.AddCategory(name, description);
        }

        public void SearchCategory()
        {
            int categoryId = _categoryView.EnterCategoryId();
            var category = _categoryService.GetCategoryById(categoryId);

            if (category is null)
            {
                return;
            }

            _categoryView.DisplayCategories([category]);
        }

        public void DeleteCategory()
        {
            int categoryId = _categoryView.EnterCategoryId();
            _categoryService.DeleteCategory(categoryId);
        }

        public bool IsCategoryEmpty(int categoryId)
        {
            return !_categoryService.GetCategories().Any();
        }

        public void UpdateCategory()
        {
            int categoryId = _categoryView.EnterCategoryId();
            var categoryName = _categoryView.EnterCategoryName();
            var categoryDescription = _categoryView.EnterCategoryDescription();
            _categoryService.UpdateCategory(categoryId, categoryName, categoryDescription);

        }
    }
}
