using gjimenezS6B.Models;
using Newtonsoft.Json;
using System.Collections.ObjectModel;

namespace gjimenezS6B.Views;

public partial class vEstudiante : ContentPage
{
	private const string Url = "http://127.0.0.1/wsestudiantes/estudiante.php";
	private readonly HttpClient cliente = new HttpClient();
	private ObservableCollection<Models.Estudiante> estud;

    public vEstudiante()
	{
		InitializeComponent();
		Listar();
	}

	public async void Listar()
	{
		var content = await cliente.GetStringAsync(Url);
		List<Models.Estudiante> listEst = JsonConvert.DeserializeObject<List<Estudiante>>(content);
		estud = new ObservableCollection<Models.Estudiante>(listEst);
		lvEstudiantes.ItemsSource = estud;
	}

    private void btnAbrir_Clicked(object sender, EventArgs e)
    {
        Navigation.PushAsync(new Views.vInsertarEstudiante());
    }

    private void lvEstudiantes_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
		var objEstudiante =(Estudiante)e.SelectedItem;
		Navigation.PushAsync(new vActualizarEliminar(objEstudiante));
    }
}