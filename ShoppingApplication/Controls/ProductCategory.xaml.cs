using Microsoft.Maui;
using System.Collections.ObjectModel;
using System.Diagnostics;

namespace ShoppingApplication.Controls;

public partial class ProductCategory : ContentView
{
	public static readonly BindableProperty CategoryNameProperty = BindableProperty.Create(nameof(CategoryName), typeof(string), typeof(ProductCategory), "Category Name");
	public static readonly BindableProperty ProductsProperty = BindableProperty.Create(nameof(Products), typeof(ObservableCollection<Product>), typeof(ProductCategory));
	public string CategoryName
	{
		get => (string)GetValue(CategoryNameProperty);
		set => SetValue(CategoryNameProperty, value);
	}

	public ObservableCollection<Product> Products
	{
		get => (ObservableCollection<Product>)GetValue(ProductsProperty);
		set => SetValue(ProductsProperty, value);
	}

	public ProductCategory()
	{
		InitializeComponent();
    }

    private void OnProductsButtonClicked(object sender, EventArgs e)
    {
        if (ProductsCollection.IsVisible == false)
        {
            ProductsCollection.IsVisible = true;
            ProductsButton.Text = "Hide products";
        }
        else
        {
            ProductsCollection.IsVisible = false;
            ProductsButton.Text = "Show products";
        }
    }
}
