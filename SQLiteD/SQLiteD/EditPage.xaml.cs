using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SQLiteD
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class EditPage : ContentPage
	{
        private Equipo equipo;
		public EditPage (Equipo equipo)
		{
			InitializeComponent ();

            this.equipo = equipo;

            MarcaEntry.Text = equipo.Marca;
            ModeloEntry.Text = equipo.Modelo;
            SerieEntry.Text = equipo.Serie;

            actualizarButton.Clicked += ActualizarButton_Clicked;
            borrarButton.Clicked += BorrarButton_Clicked;
		}

        private async void BorrarButton_Clicked(object sender, EventArgs e)
        {
            var rta = await DisplayAlert("Confirmación", "¿Desea borrar el equipo?", "Si", "No");
            if (!rta)
            { 
                return;
            }
            using (var datos = new DataAccess())
            {
                datos.DeleteEquipo(equipo);
            }
            await DisplayAlert("Confirmación", "Empleado borrado correctamente", "Aceptar");
            await Navigation.PopAsync();
        }

        private async void ActualizarButton_Clicked(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(MarcaEntry.Text))
            {
                await DisplayAlert("Error", "Debe ingresar Marca", "Aceptar");
                MarcaEntry.Focus();
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
            equipo.Marca = MarcaEntry.Text;
            equipo.Modelo = ModeloEntry.Text;
            equipo.Serie = SerieEntry.Text;
            
            using (var datos = new DataAccess())
            {
                datos.UpdateEquipo(equipo);
            }
            await DisplayAlert("Confirmación", "Equipo actualizado correctamente", "Aceptar");
            await Navigation.PopAsync();
        }
    }

}
    
