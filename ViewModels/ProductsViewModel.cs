using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WPF_Shopping_Cart.Models;

namespace WPF_Shopping_Cart.ViewModels
{
    class ProductsViewModel : BindableBase
    {
        private ObservableCollection<Products> _products;
        private Products _selectedBook;
        private int _quantity;
        private int _cartItems;
        private bool _isItemSelected;

        public ProductsViewModel()
        {
            _products = new ObservableCollection<Products>();
            _products.Add(new Products() { Id = 1, Name = "Don Quixote", Author = "Miguel deCervantes", Description = "The plot revolves around the adventures of a noble from La Mancha named Alonso Quixano, who reads so many chivalric romances that he loses his mind and decides to become a knight-errant to revive chivalry and serve his nation, under the name Don Quixote de", Price = 19.64, StockQuantity = 19 });
            _products.Add(new Products() { Id = 2, Name = "The God of Small Thigs ", Author = "Miguel deCervantes", Description = "It is a story about the childhood experiences of fraternal twins whose lives are destroyed by the \"Love Laws\" that lay down \"who should be loved, and how.And how much\" ", Price = 19.64, StockQuantity = 23 });
            _products.Add(new Products() { Id = 3, Name = "The Lord of the Rings", Author = "Miguel deCervantes", Description = "", Price = 25.90, StockQuantity = 15 });
            _products.Add(new Products() { Id = 4, Name = "The White Tiger ", Author = "Miguel deCervantes", Description = "Published in 2008, it won the 40th Man Booker Prize the same year.", Price = 20.99, StockQuantity = 3 });
            _products.Add(new Products() { Id = 5, Name = "Lazarillo de Tormes", Author = "Miguel deCervantes", Description = "The Life of Lazarillo de Tormes and of His Fortunes and Adversities, written by an anonymous author.", Price = 9.99, StockQuantity = 8 });

            AddToCartCommand = new DelegateCommand(AddToCart);

        }

        private void AddToCart()
        {
            if(SelectedBook.StockQuantity > 0 && SelectedBook.StockQuantity < Quantity)
            {
                var Book = _products.FirstOrDefault(x => x.Id == SelectedBook.Id);
                Book.StockQuantity = SelectedBook.StockQuantity - Quantity;
                CartItems++;
            }
            else
            {
                MessageBox.Show("Out of stock");
            }
            

        }

        public ObservableCollection<Products> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }

        private ICommand _addToCartCommand;

        public ICommand AddToCartCommand
        {
            get { return _addToCartCommand; }
            set { SetProperty(ref _addToCartCommand, value); }
        }

        public Products SelectedBook
        {
            get => _selectedBook;
            set => SetProperty(ref _selectedBook, value);
        }

        public int Quantity
        {
            get => _quantity;
            set => SetProperty(ref _quantity, value);
        }
        public int CartItems
        {
            get => _cartItems;
            set => SetProperty(ref _cartItems, value);
        }

        public bool IsItemSelected
        {
            get => _isItemSelected;
            set => SetProperty(ref _isItemSelected, value);
        }
    }
}
