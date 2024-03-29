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
        char genero = cbFemenino.IsChecked ? 'f' : 'm';
        bool contraseña = tbContraseña.Text == tbRepetirContraseña.Text ? true : false;

        if (!contraseña)
        {
            await DisplayAlert("Aviso", $"Las contraseñas no coinciden.", "Ok");
            return;
        }

        if (db.InsertarUsuario(tbNombre.Text, tbTelefono.Text, tbEmail.Text, 'f', dpFechaNacimiento.Date, tbContraseña.Text))
        {
            await DisplayAlert("Aviso", $"Usuario {tbNombre.Text} registrado correctamente.", "Ok");
            await Navigation.PushAsync(new MainPage());
        }
        else
        {

            await DisplayAlert("Aviso", db.errorMessage, "Ok");
        }
    }

    private async void btnCancelar_Clicked(object sender, EventArgs e)
    {
        await DisplayAlert("Aviso", "Bienvenida", "Ok");
    }

    private async void Button_Clicked_1(object sender, EventArgs e)
    {
        await DisplayAlert("Aviso", "Bienvenida", "Ok");
    }

    private void cbMasculino_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (cbMasculino.IsChecked)
        {
            cbFemenino.IsChecked = false;
        }
    }

    private void cbFemenino_CheckedChanged(object sender, CheckedChangedEventArgs e)
    {
        if (cbFemenino.IsChecked)
        {
            cbMasculino.IsChecked = false;
        }
    }

}