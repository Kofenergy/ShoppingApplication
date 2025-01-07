using System.Collections.ObjectModel;

namespace ShoppingApplication.Models
{
    public class AllCategories
    {
        private static ObservableCollection<Category> _categories { get; set; } = new ObservableCollection<Category>();

        public static ObservableCollection<Category> Categories 
        {
            get => _categories;
            set => _categories = value;
        }

        public static void AddCategory(Category category)
        {
            Categories.Add(category);
            SaveFile.SaveCategories(Categories.ToList());
        }

        public static void AddProduct(Product newProduct)
        {
            foreach (var category in Categories)
            {
                if (category.Name == newProduct.ParentCategory)
                    category.Products.Add(newProduct);
            }
            SaveFile.SaveCategories(Categories.ToList());
        }
    }
}
