namespace MauiAppSample.SandBoxApp;

public partial class SubPage : ContentPage
{

    public SubPage()
    {
        InitializeComponent();
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // メインページへ移動
        await Shell.Current.GoToAsync("//MainPage");
    }
}
