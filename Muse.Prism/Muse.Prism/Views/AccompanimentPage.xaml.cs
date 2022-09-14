using System;
using System.Collections.Generic;
using Xamarin.Forms;
using static Xamarin.Essentials.AppleSignInAuthenticator;

namespace Muse.Prism.Views
{
    public partial class AccompanimentPage : ContentPage
    {
        List<Monitor> monitors;

        public AccompanimentPage()
        {
            InitializeComponent();
            InitApp();
        }

        private void InitApp()
        {
            monitors = new List<Monitor>();
            monitors.Add(new Monitor { Name = "Luis" , FathersName = "Concha"});
            monitors.Add(new Monitor { Name = "Ricardo", FathersName = "Perez" });
            monitors.Add(new Monitor { Name = "José", FathersName = "Slobotzky" });

            foreach (var monitor in monitors)
            {
                pickermon.Items.Add((monitor.Name + ' ' + monitor.FathersName));
            }
        }
    }
}
