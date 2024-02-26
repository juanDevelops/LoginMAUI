namespace LoginMAUI;

public partial class RecuperarContraseña : ContentPage
{
	public RecuperarContraseña()
	{
		InitializeComponent();
	}

    dbLogin db = new dbLogin();

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        if (db.ActualizarContraseña(tbUser.Text, tbEmail.Text, tbContraseña.Text))
        {
            await DisplayAlert("Aviso", "Contraseña guardada para el usuario " + tbUser.Text, "Ok");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {
            await DisplayAlert("Aviso", "Usuario o contraseña incorrectos.", "Ok");
        }
    }

    private void togglePassword_Clicked(object sender, EventArgs e)
    {
        Entry entry = tbContraseña;

        entry.IsPassword = !entry.IsPassword;

        var button = togglePassword; // Reemplaza "togglePassword" por el nombre real del control
        var fontImageSource = button.Source as FontImageSource;
        if (fontImageSource != null)
        {
            fontImageSource.Glyph = entry.IsPassword ? "\uf06e" : "\uf070"; // Reemplaza "\uf06e" y "\uf070" por los códigos de los glifos que deseas usar
        }
    }

    private void togglePassword2_Clicked(object sender, EventArgs e)
    {
        Entry entry = tbRepetirContraseña;

        entry.IsPassword = !entry.IsPassword;

        var button = togglePassword2; // Reemplaza "togglePassword" por el nombre real del control
        var fontImageSource = button.Source as FontImageSource;
        if (fontImageSource != null)
        {
            fontImageSource.Glyph = entry.IsPassword ? "\uf06e" : "\uf070"; // Reemplaza "\uf06e" y "\uf070" por los códigos de los glifos que deseas usar
        }
    }
}