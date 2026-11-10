using QuincheExamen.View;

namespace QuincheExamen.Views;

public partial class LoginPage : ContentPage
{
    private readonly string[,] usuarios =
    {
        { "estudiante", "moviles" },
        { "suda", "2025" }
    };

    public LoginPage()
    {
        InitializeComponent();
    }

    private async void OnIniciarSesion(object sender, EventArgs e)
    {
        for (int i = 0; i < usuarios.GetLength(0); i++)
        {
            if (txtUsuario.Text == usuarios[i, 0] && txtClave.Text == usuarios[i, 1])
            {
                await Navigation.PushAsync(new RegistroPage(txtUsuario.Text));
                return;
            }
        }

        await DisplayAlert("Error", "Dato incorrecto", "OK");
    }
}