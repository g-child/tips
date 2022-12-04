namespace MauiAppSample.SandBoxApp;

public partial class BasicCodeBindingPage : ContentPage
{
	public BasicCodeBindingPage()
	{
		InitializeComponent();

		label.BindingContext = slider;
		label.SetBinding(RotationProperty, "Value");
	}
}