namespace LoginMAUI;

public partial class NuevoUsuario : ContentPage
{
	public NuevoUsuario()
	{
		InitializeComponent();
	}

    dbLogin db = new dbLogin();

    private async void btnGuardar_Clicked(object sender, EventArgs e)
    {
        db.InsertarUsuario(tbNombre.Text, tbTelefono.Text, tbEmail.Text, 'f', dpFechaNacimiento.Date, tbContraseña.Text);
        await DisplayAlert("Aviso", "Bienvenida", "Ok");
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Aviso", "Bienvenida", "Ok");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await DisplayAlert("Aviso", "Bienvenida", "Ok");
    }
}