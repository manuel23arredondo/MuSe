namespace MuSe.Web.Helpers
{
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;

    public interface ICombosHelper
    {
        public IEnumerable<SelectListItem> GetComboHelpTypes();
        public IEnumerable<SelectListItem> GetComboMoods();
        public IEnumerable<SelectListItem> GetComboReliabilities();
        public IEnumerable<SelectListItem> GetComboViolentometers();
        public IEnumerable<SelectListItem> GetComboKindOfPlaces();
    }
}
