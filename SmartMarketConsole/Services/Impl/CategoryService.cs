using SmartMarketConsole.Models;
using SmartMarketConsole.Repositories.Interfaces;
using SmartMarketConsole.Services.Interfaces;

namespace SmartMarketConsole.Services.Impl
{
    public class CategoryService : ICategoryService
    {
        private IProductRepository _productRepository { get; set; }
        private ICategoryRepository _categoryRepository { get; set; }
        
        public CategoryService(
            IProductRepository productRepository,
            ICategoryRepository categoryRepository)
        {
            _productRepository = productRepository;
            _categoryRepository = categoryRepository;
        }

        public bool AddCategory(string name, string description)
        {
            try
            {
                if(string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Category name cannot be empty.");
                }
                if(string.IsNullOrWhiteSpace(description))
                {
                    throw new Exception("Category description cannot be empty.");
                }
                
                var currentId = _categoryRepository.GetNextCategoryId();
                var success = _categoryRepository.AddCategory(new Category(currentId, name, description));
                if(!success)
                {
                    Console.WriteLine("A category with the same ID already exists.");
                }

                return success;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while adding the category: {ex.Message}");
                return false;
            }
        }

        public void DeleteCategory(int categoryId)
        {
            try
            {
                if(categoryId <= 0)
                {
                    throw new Exception("Invalid category ID.");
                }

                var productsInCategory = _productRepository.GetAllProducts().Where(product => product.Category.Id == categoryId).ToList();
                if (productsInCategory.Count > 0)
                {
                    throw new Exception("Category not found.");
                }

                _categoryRepository.DeleteCategory(categoryId);
            } catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while deleting the category: {ex.Message}");
                throw;
            }
        }

        public ICollection<Category> GetCategories()
        {
            return _categoryRepository.GetAllCategories();
        }

        public Category? GetCategoryById(int categoryId)
        {
            try
            {
                if(categoryId <= 0)
                {
                    throw new Exception("Invalid category ID.");
                }

                return _categoryRepository.GetCategoryById(categoryId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while retrieving the category: {ex.Message}");
                throw;
            }
        }

        public bool UpdateCategory(int categoryId, string name, string description)
        {
            try
            {
                if(categoryId <= 0)
                {
                    throw new Exception("Invalid category ID.");
                }
                if(string.IsNullOrWhiteSpace(name))
                {
                    throw new Exception("Category name cannot be empty.");
                }
                if(string.IsNullOrWhiteSpace(description))
                {
                    throw new Exception("Category description cannot be empty.");
                }
                var existingCategory = _categoryRepository.GetCategoryById(categoryId);
                if (existingCategory is null)
                {
                    throw new Exception("Category not found.");
                }

                existingCategory.Name = name;
                existingCategory.Description = description;
                _categoryRepository.UpdateCategory(existingCategory);
                return true;

            }
            catch (Exception ex)
            {
                Console.WriteLine($"An error occurred while updating the category: {ex.Message}");
                return false;
            }
        }
    }
}
