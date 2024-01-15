using Store.ViewModels;

namespace Store;

public partial class MainPage : ContentPage
{

    private readonly MainViewModel ViewModel;

    public MainPage()
	{
		InitializeComponent();
        
        ViewModel = new MainViewModel();

        SizeChanged += OnSizeChanged;
        
        BindingContext = ViewModel;
    }
    
    private void OnSizeChanged(object sender, EventArgs e)
    {
        
        ViewModel.UpdateVariables(Width);
    }
}


