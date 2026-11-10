namespace QuincheExamen.View;

public partial class RegistroPage : ContentPage
{
    private readonly string usuario;

    public RegistroPage(string usuario)
    {
        InitializeComponent();
        this.usuario = usuario;
        lblUsuario.Text = "Usuario conectado: " + usuario;

        pickerPais.ItemsSource = new List<string> { "Ecuador", "Colombia", "Perú" };
        pickerCiudad.ItemsSource = new List<string> { "Cuenca", "Quito", "Guayaquil", "Bogotá", "Lima" };
    }

    private void OnCalcularPago(object sender, EventArgs e)
    {
        if (!double.TryParse(txtMontoInicial.Text, out double inicial) || inicial < 0 || inicial > 1500)
        {
            DisplayAlert("Error", "Monto inicial no válido", "OK");
            return;
        }

        double costo = 1500;
        double cuota = (costo - inicial) / 4 + costo * 0.04;
        txtPagoMensual.Text = cuota.ToString("F2");
    }

    private async void OnVerResumen(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(txtNombre.Text) ||
            string.IsNullOrWhiteSpace(txtApellido.Text) ||
            string.IsNullOrWhiteSpace(txtEdad.Text) ||
            string.IsNullOrWhiteSpace(txtPagoMensual.Text) ||
            pickerPais.SelectedItem == null ||
            pickerCiudad.SelectedItem == null)
        {
            await DisplayAlert("Error", "Complete todos los campos y calcule el pago mensual", "OK");
            return;
        }

        double inicial = double.Parse(txtMontoInicial.Text);
        double cuota = double.Parse(txtPagoMensual.Text);
        double total = inicial + cuota * 4;

        await Navigation.PushAsync(new ResumenPage(
            usuario,
            txtNombre.Text,
            txtApellido.Text,
            txtEdad.Text,
            dpFecha.Date.ToString("dd/MM/yyyy"),
            pickerCiudad.SelectedItem.ToString(),
            pickerPais.SelectedItem.ToString(),
            inicial.ToString("F2"),
            cuota.ToString("F2"),
            total.ToString("F2")));
    }
}