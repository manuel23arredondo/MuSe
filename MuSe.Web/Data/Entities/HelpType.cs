﻿namespace MuSe.Web.Data.Entities
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public class HelpType:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Tipo de ayuda")]
        public string Description { get; set; }

        public ICollection<HelpDirectory> HelpDirectories { get; set; }
    }
}
