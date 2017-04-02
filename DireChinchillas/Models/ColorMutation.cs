using DireChinchillas.Enums;
using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Models
{
    public class ColourMutation
    {
        public int ColourId { get; set; }

        public string Name { get; set; }

        [Display(Name="Beige gene")]
        public BeigeGenes BeigeGene { get; set; }

        [Display(Name="White gene")]
        public WhiteGenes WhiteGene { get; set; }

        [Display(Name="Velver/TOV gene")]
        public TovGenes TovGene { get; set; }

        [Display(Name="Ebony gene")]
        public EbonyGenes EbonyGene { get; set; }

        [Display(Name="Recessive gene")]
        public RecessiveGenes RecessiveGene { get; set; }
    }
}