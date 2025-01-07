using ShoppingApplication.Models;
using System.Collections.ObjectModel;

namespace ShoppingApplication.Views;

public partial class ShopView : ContentPage
{
	public ShopView()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        AllCategories.Categories = SaveFile.LoadCategories();
        ObservableCollection<Product> allProducts = new ObservableCollection<Product>();
        foreach(Category category in AllCategories.Categories)
        {
            foreach(Product Product in category.Products)
            {
                allProducts.Add(Product);
            }
        }

        ProductsCollection.ItemsSource = allProducts;
    }
}