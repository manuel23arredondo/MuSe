using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Muse.Prism.Views
{
    public partial class IncidentsPage : ContentPage
    {
        public IList<Incidents> Incidents { get; private set; }
        public IncidentsPage()
        {
            InitializeComponent();
            Incidents = new List<Incidents>();
            Incidents.Add(new Incidents
            {
                Action = "Patear",
                Ubication = "Camino Real a Cholula",
                Date = DateTime.Now
            });
            
            Incidents.Add(new Incidents
            {
                Action = "Abuso Sexual",
                Ubication = "Angelópolis",
                Date = DateTime.Now
            });
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Incidents tappedItem = e.Item as Incidents;
        }
        
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Incidents selectedItem = e.SelectedItem as Incidents;
        }
    }
}
