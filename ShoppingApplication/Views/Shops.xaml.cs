using ShoppingApplication.Models;
using System.Collections.ObjectModel;

namespace ShoppingApplication.Views;

public partial class Shops : ContentPage
{
	public Shops()
	{
		InitializeComponent();
	}

    protected override void OnAppearing()
    {
        AllCategories.Categories = SaveFile.LoadCategories();

        ShopPicker.Items.Clear();

        foreach (var category in AllCategories.Categories)
        {
            foreach (var Product in category.Products) 
            {

                if (!ShopPicker.Items.Contains(Product.DefaultShop))
                {
                    ShopPicker.Items.Add(Product.DefaultShop);
                }
               
            }
        }
    }

    private void OnSelectClicked(object sender, EventArgs e)
    {
        InvisibleLayout.IsVisible = true;

        

        AllCategories.Categories = SaveFile.LoadCategories();
        ObservableCollection<Product> allProductsInShop = new ObservableCollection<Product>();
        foreach (var category in AllCategories.Categories)
        {
            foreach (var Product in category.Products)
            {
                if(ShopPicker.SelectedItem.ToString().Contains(Product.DefaultShop)) 
                    allProductsInShop.Add(Product);
            }
        }

        ProductsCollection.ItemsSource = allProductsInShop;

    }
}