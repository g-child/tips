using MauiAppSample.DiSample.Service;

namespace MauiAppSample.DiSample
{
    public partial class MainPage : ContentPage
    {
        public readonly FooService _fooService;

        int count = 0;

        public MainPage(FooService fooService)
        {
            InitializeComponent();
            _fooService = fooService;
        }


        private void OnCounterClicked(object sender, EventArgs e)
        {
            count++;

            if (count == 1)
                CounterBtn.Text = $"Clicked {count} time";
            else
                CounterBtn.Text = $"Clicked {count} times";

            SemanticScreenReader.Announce(CounterBtn.Text);
        }
    }
}