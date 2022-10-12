namespace MuSe.Web.Data.Entities
{
    using System;
    using System.ComponentModel.DataAnnotations;
    public class WomanDiary:IEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [MaxLength(50, ErrorMessage = "El campo {0} no puede tener más de {1} caracteres")]
        [Display(Name = "Descripción")]
        public string Description { get; set; }

        [Required(ErrorMessage = "{0} es obligatorio")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:dd/MM/yyyy}")]
        [Display(Name = "Fecha")]
        public DateTime DiaryDate { get; set; }

        public Woman Woman { get; set; }
        public Mood Mood { get; set; }
    }
}
