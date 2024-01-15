using System;
using System.ComponentModel;
using Store.Models;

namespace Store.ViewModels
{
    public partial class ProductsViewModel 
    {
        
        //private double itemWidth;

        
        //private ProductModel model;

        public ProductModel Model { set; get; }
        //{
        //    get { return model; }
        //    set
        //    {
        //        if (model != value)
        //        {
        //            model = value;
        //            OnPropertyChanged(nameof(Model)); // 在这里触发属性更改通知
        //        }
        //    }
        //}

        public double ItemWidth { set; get; } = 150;
        //{
        //    get { return itemWidth; }
        //    set
        //    {
        //        if (itemWidth != value)
        //        {
        //            itemWidth = value;
        //            OnPropertyChanged(nameof(ItemWidth)); // 在这里触发属性更改通知
        //        }
        //    }
        //}

        //public event PropertyChangedEventHandler PropertyChanged;

        //protected virtual void OnPropertyChanged(string propertyName)
        //{
        //    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        //}
    }

}

