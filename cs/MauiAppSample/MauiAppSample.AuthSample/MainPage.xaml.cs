using Microsoft.Identity.Client;

namespace MauiAppSample.AuthSample;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private async void LoginBtn_Clicked(object sender, EventArgs e)
    {
        LoginBtn.Text = "Log In Clicked !";
        SemanticScreenReader.Announce(LoginBtn.Text);

        var app = PublicClientApplicationBuilder.Create("<REPLACE>")
            .WithRedirectUri("<REPLACE>")
            .WithB2CAuthority("<REPLACE>")
            .Build();

        var result = await app.AcquireTokenInteractive(new string[] { "openid", "offline_access" }).ExecuteAsync();
    }
}

