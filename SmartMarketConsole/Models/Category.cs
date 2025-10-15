namespace SmartMarketConsole.Models

{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public Category()
        {
            Id = 0;
            Name = "";
            Description = "";
        }

        public Category(int id, string name, string description)
        {
            Id = id;
            Name = name;
            Description = description;
        }

        /// <summary>
        /// String representation of the Category object.
        /// </summary>
        /// <returns>String.</returns>
        override
        public string ToString()
        {
            return $"{Name}: {Description}.";
        }
    }
}
