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
        //db.InsertarUsuario(tbNombre.Text, tbTelefono.Text, tbEmail.Text, 'f', dpFechaNacimiento.Date, tbContraseña.Text);
        if (db.InsertarUsuario("Juan Pérez", "123456789", "juan@example.com", 'm', Convert.ToDateTime("1990-01-01"), "contraseña123"))
        {
            await DisplayAlert("Aviso", "Bienvenida", "Ok");
        }

        await DisplayAlert("Aviso", db.errorMessage, "Ok");
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