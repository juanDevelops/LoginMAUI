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
        bool contrase�a = tbContrase�a.Text == tbRepetirContrase�a.Text ? true : false;

        if (!contrase�a)
        {
            await DisplayAlert("Aviso", $"Las contrase�as no coinciden.", "Ok");
            return;
        }

        if (db.InsertarUsuario(tbNombre.Text, tbTelefono.Text, tbEmail.Text, 'f', dpFechaNacimiento.Date, tbContrase�a.Text))
        {
            await DisplayAlert("Aviso", $"Usuario {tbNombre.Text} registrado correctamente.", "Ok");
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