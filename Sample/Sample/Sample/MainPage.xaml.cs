using System.Threading.Tasks;
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

        protected override async void OnAppearing()
        {
            base.OnAppearing();
            using (NoSleepService.Instance.StayAwakeDuring())
            {
                await Task.Delay(30 * 1000);
            }
        }

        protected override void OnDisappearing()
        {
            base.OnDisappearing();
        }
    }
}
