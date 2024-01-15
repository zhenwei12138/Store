using CommunityToolkit.Mvvm.ComponentModel;
using Newtonsoft.Json;
using Store.Models;

namespace Store.ViewModels
{
	public partial class MainViewModel: ObservableObject
    {
        [ObservableProperty]
        private double bodyPadding = 10;
        
        public void UpdateVariables(double windowSize)
        {
            if (windowSize >= 576)
            {
                BodyPadding = 50;
            }
            else
            {
                BodyPadding = 10;
            }

        }

        public MainViewModel()
		{
        }

    }
}

