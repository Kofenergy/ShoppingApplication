using ShoppingApplication.Models;
using System.Diagnostics;
using System.Globalization;

namespace ShoppingApplication.Controls;

public partial class ShoppingProduct : ContentView
{
	public static readonly BindableProperty ProductNameProperty = BindableProperty.Create(nameof(ProductName), typeof(string), typeof(ShoppingProduct), "Default name");
	public static readonly BindableProperty DefaultShopProperty = BindableProperty.Create(nameof(DefaultShop), typeof(string), typeof(ShoppingProduct), "Default shop");
    public static readonly BindableProperty QuantityProperty = BindableProperty.Create(nameof(Quantity), typeof(double), typeof(ShoppingProduct), -1.0);
	public static readonly BindableProperty QuantityUnitProperty = BindableProperty.Create(nameof(QuantityUnit), typeof(string), typeof(ShoppingProduct), "unit");
    public static readonly BindableProperty IsProductBoughtProperty = BindableProperty.Create(nameof(IsProductBought), typeof(bool), typeof(ShoppingProduct), false);

    public string ProductName
	{
		get => (string)GetValue(ProductNameProperty);
		set => SetValue(ProductNameProperty, value);
	}

	public string DefaultShop
	{
		get => (string)GetValue(DefaultShopProperty);
		set => SetValue(DefaultShopProperty, value);
	}

	public double Quantity
	{
		get => (double)GetValue(QuantityProperty);
		set => SetValue(QuantityProperty, value);
	}

	public string QuantityUnit
	{
		get => (string)GetValue(QuantityUnitProperty);
		set => SetValue(QuantityUnitProperty, value);
	}

    public bool IsProductBought
    {
        get => (bool)GetValue(IsProductBoughtProperty);
        set => SetValue(IsProductBoughtProperty, value);
    }

    public ShoppingProduct()
    {
        InitializeComponent();
    }

    private void IsBought_Changed(object sender, CheckedChangedEventArgs e)
    {
        if (sender is CheckBox checkBox)
        {
            if (checkBox.IsChecked)
			{
				NameLabel.TextColor = Colors.Grey;
                NameLabel.TextDecorations = TextDecorations.Strikethrough;
                QuantityLabel.TextColor = Colors.Grey;
                UnitLabel.TextColor = Colors.Grey;
				ShopLabel.TextColor = Colors.Grey;

                ((Product)BindingContext).IsProductBought = true;
				if(BindingContext is Product Product)
				{
                    foreach (var category in AllCategories.Categories)
                    {
						int lastIndex = category.Products.Count - 1;
                        if (category.Name == Product.ParentCategory)
                        {
                            int ProductIndex = category.Products.IndexOf(Product);
                            if (ProductIndex != lastIndex && ProductIndex >= 0 && lastIndex != 0)
                            {
                                category.Products.Move(ProductIndex, category.Products.Count - 1);
                            }
                           
                            break;
                        }
                    }
                }
 

            } 
			else
			{
                NameLabel.TextColor = Colors.White;
                NameLabel.TextDecorations = TextDecorations.None;
                QuantityLabel.TextColor = Colors.White;
                UnitLabel.TextColor = Colors.White;
                ShopLabel.TextColor = Colors.White;

                ((Product)BindingContext).IsProductBought = false;
                if (BindingContext is Product Product)
                {
                    foreach (var category in AllCategories.Categories)
                    {
                        if (category.Name == Product.ParentCategory)
                        {
                            int ProductIndex = category.Products.IndexOf(Product);
                            if (ProductIndex > 0)
                                category.Products.Move(ProductIndex, 0);
                        }
                    }
                }
            }

			SaveFile.SaveCategories(AllCategories.Categories.ToList());
        }
    }

    private void Delete_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is Product Product)
        {
			foreach (var category in AllCategories.Categories)
			{
				if(category.Name == Product.ParentCategory)
				{
					category.Products.Remove(Product);
					SaveFile.SaveCategories(AllCategories.Categories.ToList());
				}
			}
        }
    }

    private void QuantityValue_Changed(object sender, ValueChangedEventArgs e)
    {
        if (BindingContext is Product newProduct)
        {
            newProduct.Quantity = ((Stepper)sender).Value;
            SaveFile.SaveCategories(AllCategories.Categories.ToList());
        }
    }

}