using ShoppingApplication.Models;
using System.Diagnostics;
using System.Linq;

namespace ShoppingApplication.Views;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();
        CategoriesCollection.CancelAnimations();
        BindingContext = AllCategories.Categories;
    }

    protected override void OnAppearing()
    {
        try
        {
            AllCategories.Categories = SaveFile.LoadCategories();
            List<Category> catList = AllCategories.Categories.ToList();
            CategoriesCollection.ItemsSource = catList;
        }
        catch (Exception ex)
        {
            Debug.WriteLine(ex.Message);
        }
    }

    private async void NewCategory_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NewCategoryPage));
    }

    private void NewProduct_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(NewProductPage));
    }

    private async void GoToShopView_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ShopView());
    }

    private async void GoToShops_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new Shops());
    }
}
