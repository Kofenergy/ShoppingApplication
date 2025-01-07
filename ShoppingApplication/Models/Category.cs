using System.Collections.ObjectModel;
using System.ComponentModel;

namespace ShoppingApplication.Models
{
    public class Category : INotifyPropertyChanged
    {
        private string _name;
        public ObservableCollection<Product> _Products { get; set; } = new ObservableCollection<Product>();

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public ObservableCollection<Product> Products
        {
            get => _Products;
            set
            {
                _Products = value;
                OnPropertyChanged("Products");
            }
        }

        public Category(string Name, ObservableCollection<Product> Products = null)
        {
            this.Name = Name;
            this.Products = Products;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}
