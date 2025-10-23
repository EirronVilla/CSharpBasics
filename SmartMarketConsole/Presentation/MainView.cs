namespace SmartMarketConsole.Presentation
{
    public class MainView
    {
        public int GetOption()
        {
            int choice;
            bool validInput = false;
            do
            {
                validInput = int.TryParse(Console.ReadLine(), out choice);
                validInput = validInput && choice >= 1 && choice <= 5;
                if (!validInput)
                {
                    Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                }
            } while (!validInput);

            return choice;
        }

        public int MainMenu()
        {
            Console.WriteLine("Welcome to the Smart Market!");
            Console.WriteLine("1. Costumers.");
            Console.WriteLine("2. Categories.");
            Console.WriteLine("3. Products.");
            Console.WriteLine("4. Transactions.");
            Console.WriteLine("5. Finish Program.");

            return GetOption();
        }

        public int ProductsMenu()
        {
            Console.WriteLine("Products Menu:");
            Console.WriteLine("1. List all products.");
            Console.WriteLine("2. Search product by ID.");
            Console.WriteLine("3. Search products by Category.");
            Console.WriteLine("4. Add new product.");
            Console.WriteLine("5. Update product.");
            Console.WriteLine("6. Delete product.");
            Console.WriteLine("7. Return to Main Menu.");

            return GetOption();
        }

        public int CategoriesMenu()
        {
            Console.WriteLine("Categories Menu:");
            Console.WriteLine("1. List all categories.");
            Console.WriteLine("2. Search category by ID.");
            Console.WriteLine("3. Add new category.");
            Console.WriteLine("4. Update category.");
            Console.WriteLine("5. Delete category.");
            Console.WriteLine("6. Return to Main Menu.");

            return GetOption();
        }

        public int CostumersMenu()
        {
            Console.WriteLine("Costumers Menu:");
            Console.WriteLine("1. List all costumers.");
            Console.WriteLine("2. Search costumer by ID.");
            Console.WriteLine("3. Add new costumer.");
            Console.WriteLine("4. Update costumer.");
            Console.WriteLine("5. Delete costumer.");
            Console.WriteLine("6. Return to Main Menu.");

            return GetOption();
        }

        public int TransactionsMenu()
        {
            Console.WriteLine("Transactions Menu:");
            Console.WriteLine("1. List all transactions.");
            Console.WriteLine("2. Search transaction by ID.");
            Console.WriteLine("3. Add new transaction.");
            Console.WriteLine("4. Update transaction.");
            Console.WriteLine("5. Delete transaction.");
            Console.WriteLine("6. Return to Main Menu.");

            return GetOption();
        }
    }
}
