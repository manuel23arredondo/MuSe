namespace MuSe.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using MuSe.Web.Data;
    using System.Collections.Generic;
    using System.Linq;

    public class CombosHelper:ICombosHelper
    {
        private readonly DataContext dataContext;

        public CombosHelper(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }

        public IEnumerable<SelectListItem> GetComboHelpTypes()
        {
            var list = this.dataContext.HelpTypes.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona el tipo de ayuda)",
                Value = "0"
            });
            return list;
        }
        
        public IEnumerable<SelectListItem> GetComboMoods()
        {
            var list = this.dataContext.Moods.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona cómo te sientes)",
                Value = "0"
            });
            return list;
        }
        
        public IEnumerable<SelectListItem> GetComboReliabilities()
        {
            var list = this.dataContext.Reliabilities.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona la gravedad de la acción)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboViolentometers()
        {
            var list = this.dataContext.Violentometers.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona el tipo de acción violenta)",
                Value = "0"
            });
            return list;
        }

        public IEnumerable<SelectListItem> GetComboKindOfPlaces()
        {
            var list = this.dataContext.KindOfPlaces.Select(b => new SelectListItem
            {
                Text = b.Description,
                Value = $"{b.Id}"
            }).ToList();
            list.Insert(0, new SelectListItem
            {
                Text = "(Seleccciona el tipo de lugar)",
                Value = "0"
            });
            return list;
        }
    }
}
