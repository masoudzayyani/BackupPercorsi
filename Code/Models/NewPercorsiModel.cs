using System.ComponentModel.DataAnnotations;

namespace PathApp.Models
{
    public class NewPercorsiModel
    {
        [Display(Name = "Path ID")]
        public System.Int32 IdPercorso { get; set; }

        [Display(Name = "Subnetwork ID")]
        public System.Int32 IdSottorete { get; set; }

        [Display(Name = "Original Station ID")]
        public System.Int32 IdStazioneOrigine { get; set; }

        [Display(Name = "Original Station Name")]
        public string StazioneOrigineName { get; set; }

        [Display(Name = "Destination Station ID")]
        public System.Int32 IdStazioneDestinazione { get; set; }

        [Display(Name = "Destination Station Name")]
        public string StazioneDestinazioneName { get; set; }

        [Display(Name = "Via1 ID")]
        public System.Int32 IdVia1 { get; set; }

        [Display(Name = "Via1 Name")]
        public string Via1Name { get; set; }

        [Display(Name = "Via2 ID")]
        public System.Int32 IdVia2 { get; set; }

        [Display(Name = "Via2 Name")]
        public string Via2Name { get; set; }

        [Display(Name = "Distance")]
        public System.Int32 Distanza { get; set; }

        [Display(Name = "Version")]
        public string Versione { get; set; }
    }
}
