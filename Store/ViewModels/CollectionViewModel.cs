using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;
using Store.Models;

namespace Store.ViewModels
{
    public partial class CollectionViewModel : INotifyPropertyChanged
    {
        
        private CollectionModel model;
        public CollectionModel Model
        {
            get { return model; }
            set
            {
                if (model != value)
                {
                    model = value;
                    OnPropertyChanged(nameof(Model)); // 在这里触发属性更改通知
                }
            }
        }


        private bool leftButtonVisiable;
        public bool LeftButtonVisiable
        {
            get { return leftButtonVisiable; }
            set
            {
                if (leftButtonVisiable != value)
                {
                    leftButtonVisiable = value;
                    OnPropertyChanged(nameof(LeftButtonVisiable)); // 在这里触发属性更改通知
                }
            }
        }

        private bool rightButtonVisiable;
        public bool RightButtonVisiable
        {
            get { return rightButtonVisiable; }
            set
            {
                if (rightButtonVisiable != value)
                {
                    rightButtonVisiable = value;
                    OnPropertyChanged(nameof(RightButtonVisiable)); // 在这里触发属性更改通知
                }
            }
        }

        private double itemWidth = 150;
        public double ItemWidth
        {
            get { return itemWidth; }
            set
            {
                if (itemWidth != value)
                {
                    itemWidth = value;
                    OnPropertyChanged(nameof(ItemWidth)); // 在这里触发属性更改通知
                }
            }
        }

        public ProductsViewModel[] productsList;

        public ProductsViewModel[] ProductsList
        {
            get { return productsList; }
            set
            {
                productsList = value;
                OnPropertyChanged(nameof(ProductsList));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public CollectionViewModel()
		{
            Task.Run(async () => {
                await LoadData();
            }).Wait();
        }
        private async Task LoadData()
        {
            Model = await GetMockDataAsync();

            ProductsList = model.ProductsList.Select(m => {
                var productsVm = new ProductsViewModel();
                productsVm.ItemWidth = 150;
                productsVm.Model = m;
                return productsVm;
            }).ToArray();
        
        }
      

        private async Task<CollectionModel> GetMockDataAsync()
        {
            CollectionModel model = new CollectionModel();

            using var stream = await FileSystem.OpenAppPackageFileAsync("MockData.json");

            using (var reader = new StreamReader(stream))
            {
                var jsonString = await reader.ReadToEndAsync();
                // Deserialize JSON to model
                model = JsonConvert.DeserializeObject<CollectionModel>(jsonString);
            }

            return model;
        }

       
        public void OnCollectionViewVisiableChanged(int FirstIndex, int LastIndex) {
            if (LastIndex == Model.ProductsList.Length - 1)
            {
                RightButtonVisiable = false;
            }
            else
            {
                RightButtonVisiable = true;
            }

            if (FirstIndex > 0)
            {
                LeftButtonVisiable = true;
            }
            else
            {
                LeftButtonVisiable = false;
                RightButtonVisiable = false;
            }
        }
    }
}

