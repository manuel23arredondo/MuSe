using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Muse.Prism.Views
{
    public partial class MonitorPage : ContentPage
    {
        public IList<Monitor> Monitors { get; private set; }

        public MonitorPage()
        {
            InitializeComponent();

            Monitors = new List<Monitor>();
            Monitors.Add(new Monitor
            {
                Name = "Luis",
                FathersName = "Concha",
            });

            Monitors.Add(new Monitor
            {
                Name = "José",
                FathersName = "Slobotkzy",
            });

            Monitors.Add(new Monitor
            {
                Name = "Ricardo",
                FathersName = "Pérez",
            });

            BindingContext = this;
        }

        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e)
        {
            Monitor tappedItem = e.Item as Monitor;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Monitor selectedItem = e.SelectedItem as Monitor;
        }
    }
}
