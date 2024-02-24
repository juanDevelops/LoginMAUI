namespace LoginMAUI
{
    public partial class MainPage : ContentPage
    {
        int count = 0;

        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnIngresar_Clicked(object sender, EventArgs e)
        {
            await DisplayAlert("Aviso", "Bienvenida", "Ok");
        }

        private async void btnNewUser_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new NuevoUsuario());
        }
    }

}
