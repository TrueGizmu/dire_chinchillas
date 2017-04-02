using System.ComponentModel.DataAnnotations;

namespace DireChinchillas.Enums
{
    public enum TovGenes
    {
        [Display(Name = "None")]
        NoVelvetTOV = 0,
        [Display(Name ="Velvet/TOV")]
        VelvetTOV = 1
    }
}