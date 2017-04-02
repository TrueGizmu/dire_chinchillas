using System;

namespace DireChinchillas.Models
{
    public class Weight
    {
        public int ChinchillaId { get; set; }
        public DateTime Date { get; set; }

        public int Value { get; set; }

        public virtual Chinchilla Chinchilla { get; set; }
    }
}