using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartMarketConsole.Presentation.Views
{
    public class CategoryView
    {
        public int EnterCategoryId()
        {
            int categoryId;
            while (true)
            {
                Console.Write("Enter category ID: ");
                string input = Console.ReadLine() ?? string.Empty;
                if (int.TryParse(input, out categoryId) && categoryId > 0)
                {
                    return categoryId;
                }
                Console.WriteLine("Invalid category ID. Please enter a valid positive integer.");
            }
        }

        public string EnterCategoryName()
        {
            Console.Write("Enter category name: ");
            string categoryName = Console.ReadLine() ?? string.Empty;
            return categoryName;
        }

        public string EnterCategoryDescription()
        {
            Console.Write("Enter category description: ");
            string categoryDescription = Console.ReadLine() ?? string.Empty;
            return categoryDescription;
        }
    }
}
