namespace MauiAppSample.SandBoxApp;

public partial class SubPage : ContentPage
{

    public SubPage()
    {
        InitializeComponent();
    }

    private async void OnClicked(object sender, EventArgs e)
    {
        // ���C���y�[�W�ֈړ�
        await Shell.Current.GoToAsync("//MainPage");
    }
}
