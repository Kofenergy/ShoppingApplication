using System.ComponentModel;

namespace ShoppingApplication
{
    public class Product : INotifyPropertyChanged
    {
        private string _name;
        private string _parentCategory;
        private double _quantity;
        private string _quantityUnit;
        private string _defaultShop;
        private bool _isProductBought;
        private bool _isProductNotBought;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }
        public string ParentCategory
        {
            get => _parentCategory;
            set
            {
                _parentCategory = value;
                OnPropertyChanged("ParentCategory");
            }
        }
        public double Quantity
        {
            get => _quantity;
            set
            {
                _quantity = value;
                OnPropertyChanged("Quantity");
            }
        }

        public string QuantityUnit
        {
            get => _quantityUnit;
            set
            {
                _quantityUnit = value;
                OnPropertyChanged("QuantityUnit");
            }
        }

        public string DefaultShop
        {
            get => _defaultShop;
            set
            {
                _defaultShop = value;
                OnPropertyChanged("DefaultShop");
            }
        }
        public bool IsProductBought
        {
            get => _isProductBought;
            set
            {
                _isProductBought = value;
                OnPropertyChanged("IsProductBought");
            }
        }

        public bool IsProductNotBought
        {
            get => _isProductNotBought;
            set
            {
                _isProductNotBought = value;
                OnPropertyChanged("IsProductNotBought");
            }
        }

        public Product(string Name, string ParentCategory, double Quantity, string QuantityUnit,
            string DefaultShop, bool IsProductBought = false)
        {
            this.Name = Name;
            this.ParentCategory = ParentCategory;
            this.Quantity = Quantity;
            this.QuantityUnit = QuantityUnit;
            this.DefaultShop = DefaultShop;
            this.IsProductBought = IsProductBought;
            this.IsProductNotBought = !IsProductBought;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
