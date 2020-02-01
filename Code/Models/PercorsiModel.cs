using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathApp.Models
{
    public class PercorsiModel
    {
        //public int ID { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Display(Name = "Path ID")]
        [Required(ErrorMessage = "Please Insert Path ID")]
        [Range(0, int.MaxValue, ErrorMessage = "ID just could be at range of positive number")]
        public System.Int32 IdPercorso { get; set; }

        [Display(Name = "Subnetwork ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Subnetwork ID just could be at range of positive number")]
        [Required(ErrorMessage = "Please Insert Subnetwork ID")]
        public System.Int32 IdSottorete { get; set; }

        [Display(Name = "Original Station ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Original Station ID just could be at range of positive number")]
        [Required(ErrorMessage = "Please Insert Original Station ID")]
        public System.Int32 IdStazioneOrigine { get; set; }

        [Display(Name = "Destination Station ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Destination Station ID just could be at range of positive number")]
        [Required(ErrorMessage = "Please Insert Destination Station ID")]
        public System.Int32 IdStazioneDestinazione { get; set; }

        [Display(Name = "Via1 ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Via1 ID just could be at range of positive number")]
        [System.ComponentModel.DefaultValue(0)]
        public System.Int32 IdVia1 { get; set; }

        [Display(Name = "Via2 ID")]
        [Range(0, int.MaxValue, ErrorMessage = "Via2 ID just could be at range of positive number")]
        [System.ComponentModel.DefaultValue(0)]
        public System.Int32 IdVia2 { get; set; }

        [Display(Name = "Distance")]
        [Required(ErrorMessage = "Please Insert Distance")]
        [Range(0, int.MaxValue, ErrorMessage = "Distance just could be at range of positive number")]
        public System.Int32 Distanza { get; set; }

        [Display(Name = "Version")]
        public string Versione { get; set; }
    }
}
