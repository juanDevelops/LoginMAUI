namespace LoginMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        dbLogin db = new dbLogin();

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Bienvenida", "Ok");
        }


        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            if (db.ConsultarUsuario(tbUser.Text, tbContraseña.Text))
            {
                await DisplayAlert("Aviso", "Bienvenido " + tbUser.Text, "Ok");
            }
            else
            {
                await DisplayAlert("Aviso", db.errorMessage, "Ok");
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

        private async void btnSignUp_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoUsuario());
        }
    }

}
