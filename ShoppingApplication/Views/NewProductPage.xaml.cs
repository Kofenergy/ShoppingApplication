using ShoppingApplication.Models;
using System.Globalization;

namespace ShoppingApplication.Views;

public partial class NewProductPage : ContentPage
{
	public NewProductPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        AllCategories.Categories = SaveFile.LoadCategories();

        CategoryPicker.Items.Clear();

        foreach (var category in AllCategories.Categories)
        {
            CategoryPicker.Items.Add(category.Name);
        }
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        
        if (NameEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz nazwê produktu.", "OK");
            return;
        }

        if (CategoryPicker.SelectedItem == null)
        {
            await DisplayAlert("Uwaga", "Nie wybrano kategorii produktu.", "OK");
            return;
        }

        if (QuantityEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz iloœæ produktu.", "OK");
            return;
        }

        if (UnitEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz jednostkê iloœci produktu.", "OK");
            return;
        }

        if (ShopEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz sklep dla produktu.", "OK");
            return;
        }

        NumberFormatInfo provider = new NumberFormatInfo();
        provider.NumberDecimalSeparator = ".";
        provider.NumberGroupSeparator = ",";

        string newProductName = NameEditor.Text.Trim();
        string newProductCategory = CategoryPicker.SelectedItem.ToString();
        double newProductQuantity;
        if (!double.TryParse(QuantityEditor.Text.Trim(), provider, out newProductQuantity))
        {
            
            await DisplayAlert("Uwaga", "Podaj liczbę.", "OK");
            return; 
        }

       
        if (newProductQuantity <= 0)
        {
            await DisplayAlert("Uwaga", "Podaj Liczbę większą od 0", "OK");
            return;
        }
        string newProductUnit = UnitEditor.Text.Trim();
        string newProductShop = ShopEditor.Text.Trim();

        Product newProduct = new Product(newProductName, newProductCategory, newProductQuantity, newProductUnit, newProductShop);

        AllCategories.AddProduct(newProduct);

        await Shell.Current.GoToAsync("..");
    }
}