using System.Collections.Generic;
using Xamarin.Forms;

namespace Muse.Prism.Views
{
    public partial class MonitoreadasPage : ContentPage
    {
        public IList<Monitored> Monitoreds { get; private set; }
        public MonitoreadasPage()
        {
            InitializeComponent();
            Monitoreds = new List<Monitored>();
            Monitoreds.Add(new Monitored
            {
                Name = "Monse",
                FathersName = "Nava",
            });

            Monitoreds.Add(new Monitored
            {
                Name = "Andrea",
                FathersName = "Pérez",
            });

            Monitoreds.Add(new Monitored
            {
                Name = "Mariel",
                FathersName = "Benítez",
            });

            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Monitored tappedItem = e.Item as Monitored;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Monitored selectedItem = e.SelectedItem as Monitored;
        }
    }
}
