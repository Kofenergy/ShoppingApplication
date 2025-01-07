namespace ShoppingApplication
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();

            Routing.RegisterRoute(nameof(Views.NewCategoryPage), typeof(Views.NewCategoryPage));
            Routing.RegisterRoute(nameof(Views.NewProductPage), typeof(Views.NewProductPage));


        }
    }
}
