using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_REF_SINC
    {
        [Key]
        [MaxLength(20)]
        [Display(Name = "text_RsReferenciaS", ResourceType = typeof(Resources.Sincronizacion.Index))]
        public string RsReferenciaS { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_RsTipoInventarioS", ResourceType = typeof(Resources.Sincronizacion.Index))]
        public string RsTipoInventarioS { get; set; }
    }
}