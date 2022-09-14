using System;
using System.Collections.Generic;
using System.ComponentModel;
using Xamarin.Forms;

namespace Muse.Prism.Views
{
    [DesignTimeVisible(false)]
    public partial class IncidentsPage : ContentPage
    {
        public IList<Incident> Incidents { get; private set; }
        public IncidentsPage()
        {
            InitializeComponent();
            Incidents = new List<Incident>();
            Incidents.Add(new Incident
            {
                Name = "Patear",
                Location = "Camino Real a Cholula",
                Date = DateTime.Now
            });
            
            Incidents.Add(new Incident
            {
                Name = "Abuso Sexual",
                Location = "Angelópolis",
                Date = DateTime.Now
            });

            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Incident tappedItem = e.Item as Incident;
        }
        
        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Incident selectedItem = e.SelectedItem as Incident;
        }
    }
}
