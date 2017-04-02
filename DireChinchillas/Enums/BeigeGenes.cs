using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Enums
{
    public enum BeigeGenes
    {
        [Display(Name="None")]
        NoBeige = 0,
        [Display(Name = "Hetero Beige")]
        HeteroBeige = 1,
        [Display(Name = "Homo Beige")]
        HomoBeige = 2
    }
}