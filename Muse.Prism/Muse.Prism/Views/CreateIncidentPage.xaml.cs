using System.Collections.Generic;
using Xamarin.Forms;

namespace Muse.Prism.Views
{
    public partial class CreateIncidentPage : ContentPage
    {
        List<ActionItem> actions;

        public CreateIncidentPage()
        {
            InitializeComponent();
            InitApp();
        }

        void InitApp()
        {
            actions = new List<ActionItem>();
            actions.Add(new ActionItem { Name = "Bromas hirientes" });
            actions.Add(new ActionItem { Name = "Culpabilizar" });
            actions.Add(new ActionItem { Name = "Celar" });
            actions.Add(new ActionItem { Name = "Humillar en público" });
            actions.Add(new ActionItem { Name = "Manosear" });
            actions.Add(new ActionItem { Name = "Pellizcar/Arañar" });
            actions.Add(new ActionItem { Name = "Abuso sexual" });
            actions.Add(new ActionItem { Name = "Violar" });

            foreach (var action in actions)
            {
                pickeract.Items.Add(action.Name);
            }
        }

        private void PickerAction_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            
        }
    }
}
