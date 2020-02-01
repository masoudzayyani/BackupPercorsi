using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PathApp.Models
{

    public class StazioneModel
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required(ErrorMessage = "Please Insert Station ID")]
        [Display(Name ="Station ID")]
        [Range(0,int.MaxValue,ErrorMessage ="ID just could be at range of positive number")]
        //[DataType(DataType.)]
        public System.Int32 IDStazione { get; set; }

        [Display(Name = "Code")]
        [Required(ErrorMessage = "Please Insert Code")]
        [Range(0, int.MaxValue, ErrorMessage = "Code just could be at range of positive number")]
        public System.Int32 CodiceStazione { get; set; }

        [Display(Name = "Name")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please Insert Name")]
        [DataType(DataType.Text,ErrorMessage ="Please Just Use Letters")]
        public string NomeStazione { get; set; }

        [Display(Name = "Card Withdrawal")]
        [Required(ErrorMessage = "Please Insert Card withdrawal")]
        [Range(0, int.MaxValue, ErrorMessage = "Card Withdrawal just could be at range of positive number")]
        public System.Int32 RitiroTessera { get; set; }

        [Display(Name = "Reload Subscription")]
        [Required(ErrorMessage = "Please Insert Reload Subscription")]
        [Range(0, int.MaxValue, ErrorMessage = "Reload Subscription just could be at range of positive number")]
        public System.Int32 RiCaricaAbbonamento { get; set; }

        [Display(Name = "Version")]
        [Required(ErrorMessage = "Please Insert Version")]
        public string Versione { get; set; }
    }
}
