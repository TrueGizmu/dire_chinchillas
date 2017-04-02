using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Enums
{
    public enum EbonyGenes
    {
        [Display(Name = "None")]
        NoEbony = 0,
        [Display(Name="Light Ebony or Carrier")]
        LightEbony = 1,
        [Display(Name = "Medium Ebony")]
        MediumEbony = 2,
        [Display(Name = "Dark Ebony")]
        DarkEbony = 3,
        [Display(Name ="Extra Dark Ebony (Homo Ebony)")]
        ExtraDarkEbony = 4
    }
}