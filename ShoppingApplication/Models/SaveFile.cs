using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShoppingApplication.Models
{
    internal class SaveFile
    {
        public static void SaveCategories(List<Category> categories)
        {
            XDocument xDocument = new XDocument();
            xDocument.Add(new XElement("Categories"));

            foreach (Category category in categories)
            {
                if (category.Products == null)
                {
                    xDocument.Element("Categories").Add(new XElement(category.Name));
                    continue;
                }

                xDocument.Element("Categories").Add(new XElement(category.Name,
                    category.Products.Select(Product => new XElement("Product",
                    new XElement("Name", Product.Name),
                    new XElement("ParentCategory", Product.ParentCategory),
                    new XElement("Quantity", Product.Quantity),
                    new XElement("QuantityUnit", Product.QuantityUnit),
                    new XElement("DefaultShop", Product.DefaultShop),
                    new XElement("isBought", Product.IsProductBought)
                    ))));
            }

            string _fileName = "Products.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);

            xDocument.Save(_filePath);
        }

        public static ObservableCollection<Category> LoadCategories()
        {
            ObservableCollection<Category> categories = new ObservableCollection<Category>();

            string _fileName = "Products.xml";
            string _filePath = Path.Combine(FileSystem.AppDataDirectory, _fileName);
            Debug.WriteLine(_filePath);

            if (!File.Exists(_filePath))
                SaveCategories(categories.ToList());

            XDocument xml = XDocument.Load(_filePath);
            XElement xmlRoot = xml.Root;

            foreach (XElement el in xmlRoot.Elements())
            {
                string catName = el.Name.ToString();

                ObservableCollection<Product> tempProducts = new ObservableCollection<Product>();
                foreach (XElement Product in el.Elements())
                {
                    if (Product == null)
                        continue;

                    NumberFormatInfo provider = new NumberFormatInfo();
                    provider.NumberDecimalSeparator = ".";
                    provider.NumberGroupSeparator = ",";

                    string ProductName = Product.Element("Name").Value;
                    string ProductCategory = Product.Element("ParentCategory").Value;
                    double ProductQuantity = Convert.ToDouble(Product.Element("Quantity").Value, provider);
                    string ProductQuantityUnit = Product.Element("QuantityUnit").Value;
                    string ProductDefaultShop = Product.Element("DefaultShop").Value;
                    bool ProductIsBought = Boolean.Parse(Product.Element("isBought").Value);

                    Debug.WriteLine("Odczytana wartość bool: " + ProductIsBought);

                    tempProducts.Add(new Product(ProductName, ProductCategory, ProductQuantity, ProductQuantityUnit,
                        ProductDefaultShop, ProductIsBought));
                }
                categories.Add(new Category(catName, tempProducts));
            }
            return categories;
        }
    }
}
