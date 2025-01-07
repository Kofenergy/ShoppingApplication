using ShoppingApplication.Models;

namespace ShoppingApplication.Views;

public partial class NewCategoryPage : ContentPage
{
	public NewCategoryPage()
	{
		InitializeComponent();
    }

    protected override void OnAppearing()
    {
        AllCategories.Categories = SaveFile.LoadCategories();
    }

    private async void CreateButton_Clicked(object sender, EventArgs e)
    {
        if (CategoryEditor.Text == null)
        {
            await DisplayAlert("Uwaga", "Wpisz nazwê kategorii.", "OK");
            return;
        }

        string newCategoryName = CategoryEditor.Text;

        Category category = new Category(newCategoryName);
        AllCategories.Categories.Add(category);
        SaveFile.SaveCategories(AllCategories.Categories.ToList());

        await Shell.Current.GoToAsync("..");
    }
}