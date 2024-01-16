
using System.Collections.ObjectModel;
using Store.Models;
using Store.ViewModels;
namespace Store.Widgets;

public partial class ProductCollection : ContentView
{


    CollectionViewModel ViewModel;
    int firstVisibleIndex;
    int lastVisibleIndex;

    public ProductCollection()
    {
        InitializeComponent();
        ViewModel = new CollectionViewModel();
        this.BindingContext = ViewModel;
        SizeChanged += OnSizeChanged;
        ViewModel.PropertyChanged += (sender, e) =>
        {
            Console.WriteLine(e.PropertyName);
        };


        CollectionView ProductCollectionView = (CollectionView)this.FindByName("ProductCollectionView");
        ProductCollectionView.SizeChanged += UpdateItemSize;
        Console.WriteLine(ProductCollectionView.Width);
    }

    private void UpdateItemSize(object sender, EventArgs e) {
        if (sender is View view)
        {
            double newWidth = view.Width;
            Double MaxCount = newWidth / 150;

            Double ItemWidth = (newWidth - 10 * ((int)MaxCount - 1)) / (int)MaxCount;

            foreach (var item in ViewModel.ProductsList)
            {

                item.ItemWidth = ItemWidth;
            }
            Console.Write(MaxCount);
            // ViewModel.ProductsList = ViewModel.Model.ProductsList.Select(m =>
            // {
            //     var productsVm = new ProductsViewModel();
            //     productsVm.ItemWidth = ItemWidth;
            //     productsVm.Model = m;
            //     return productsVm;
            // }).ToArray();

            if ((int)MaxCount > 0)
            {
               ViewModel.ProductsList = ViewModel.Model.ProductsList.Take((int)MaxCount).Select(m =>
               {
                   var productsVm = new ProductsViewModel();
                   productsVm.ItemWidth = ItemWidth;
                   productsVm.Model = m;
                   return productsVm;
               }).ToArray();
            }
            else
            {
               ViewModel.ProductsList = new ProductsViewModel[0];
            }
        }
    }

    private void LeftButton_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("left button click");
        CollectionView ProductCollectionView = (CollectionView)this.FindByName("ProductCollectionView");
        ProductCollectionView.ScrollTo(firstVisibleIndex - 1);
       
    }
     
    private void RightButton_Clicked(object sender, EventArgs e)
    {
        Console.WriteLine("right button click");
        CollectionView ProductCollectionView = (CollectionView)this.FindByName("ProductCollectionView");
        ProductCollectionView.ScrollTo(lastVisibleIndex + 1);
    }

    
    private void OnCollectionViewScrolled(object sender, ItemsViewScrolledEventArgs e)
    {
        // 获取当前屏幕上可见元素的索引范围
        firstVisibleIndex = e.FirstVisibleItemIndex;
        lastVisibleIndex = e.LastVisibleItemIndex;
        ViewModel.OnCollectionViewVisiableChanged(firstVisibleIndex, lastVisibleIndex);
    }

   

    private void OnSizeChanged(object sender, EventArgs e)
    {
        ColumnDefinition Column0 = (ColumnDefinition)this.FindByName("column0");
        ColumnDefinition Column1 = (ColumnDefinition)this.FindByName("column1");
        AbsoluteLayout RightContent = (AbsoluteLayout)this.FindByName("RightContent");
        Double ContentWidth = Width;
        if (ContentWidth >= 897)
        {
            Column0.Width = new GridLength(1, GridUnitType.Star);
            Column1.Width = new GridLength(2, GridUnitType.Star);

            RightContent.IsVisible = true;
        }
        else if (ContentWidth >= 668)
        {
            Column0.Width = new GridLength(1, GridUnitType.Star);
            Column1.Width = new GridLength(1, GridUnitType.Star);
            RightContent.IsVisible = true;
        }
        else
        {
            Column0.Width = new GridLength(1, GridUnitType.Star); ;
            Column1.Width = 0;
            RightContent.IsVisible = false;
        }
    }

}
