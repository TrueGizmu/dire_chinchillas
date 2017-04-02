using DireChinchillas.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Models
{
    public class Chinchilla
    {
        public int ChinchillaId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(250, MinimumLength = 3)]
        public string Name { get; set; }

        public SexTypes Sex { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }

        [DisplayName("Date of death")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DeathDate { get; set; }

        public string Description { get; set; }

        [DisplayName("Colour")]
        public int ColourId { get; set; }
        [DisplayName("Mother")]
        public int? MotherId { get; set; }
        [DisplayName("Father")]
        public int? FatherId { get; set; }
                
        public virtual ColourMutation Colour { get; set; }
        public virtual Chinchilla Mother { get; set; }
        public virtual Chinchilla Father { get; set; }
        public virtual ICollection<Chinchilla> Children { get; set; }
        public virtual ICollection<Weight> WeightHistory { get; set; }
    }
}
