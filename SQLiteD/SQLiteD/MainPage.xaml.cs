using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace SQLiteD
{
	public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();

            using (var datos = new DataAccess())
            {
                listaListView.ItemsSource = datos.GetEquipo();
            }

            agregarButton.Clicked += AgregarButton_Clicked;
		}

        private async void AgregarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(marcaEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Marca", "Aceptar");
                marcaEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(ModeloEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Modelo", "Aceptar");
                ModeloEntry.Focus();
                return;
            }
            if (string.IsNullOrEmpty(SerieEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Serie", "Aceptar");
                SerieEntry.Focus();
                return;
            }
            var equipo = new Equipo
            {
                Marca = marcaEntry.Text,
                Modelo = ModeloEntry.Text,
                Serie = SerieEntry.Text,
                
            };
            using (var datos = new DataAccess())
            {
                datos.InsertEquipo(equipo);
                listaListView.ItemsSource = datos.GetEquipo();
            }
            marcaEntry.Text = string.Empty;
            ModeloEntry.Text = string.Empty;
            SerieEntry.Text = string.Empty;
           await DisplayAlert("Confirmación", "Equipo agregado", "Aceptar");
        }
    }
}
