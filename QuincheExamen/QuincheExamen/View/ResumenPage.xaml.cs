namespace QuincheExamen.View;

public partial class ResumenPage : ContentPage
{
    public ResumenPage(string usuario, string nombre, string apellido, string edad,
                       string fecha, string ciudad, string pais,
                       string montoInicial, string pagoMensual, string pagoTotal)
    {
        InitializeComponent();

        lblUsuario.Text = "Usuario conectado: " + usuario;
        lblNombre.Text = nombre;
        lblApellido.Text = apellido;
        lblEdad.Text = edad;
        lblFecha.Text = fecha;
        lblCiudad.Text = ciudad;
        lblPais.Text = pais;
        lblMontoInicial.Text = montoInicial;
        lblPagoMensual.Text = pagoMensual;
        lblPagoTotal.Text = pagoTotal;
    }
}