using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Mvvm;

namespace WPF_Shopping_Cart.Models
{
    public class Products : BindableBase
    {
        private int _stockQuantity;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public int StockQuantity
        {
            get => _stockQuantity;
            set => SetProperty(ref _stockQuantity, value);
        }

    }
}
