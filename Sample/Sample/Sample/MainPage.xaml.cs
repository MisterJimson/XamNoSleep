using Xamarin.Forms;
using XamNoSleep;

namespace Sample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            NoSleepService.Instance.AllowSleep = false;
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
