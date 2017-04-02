using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Enums
{
    public enum RecessiveGenes
    {
        [Display(Name = "None")]
        NoRecessive = 0,
        Violet = 1,
        Sapphire = 2,
        [Display(Name = "Violet Carrier")]
        VioletCarier = 3,
        [Display(Name = "Sapphire Carrier")]
        SapphireCarier = 4
    }
}