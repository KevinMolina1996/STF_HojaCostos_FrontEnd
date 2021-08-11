using System;
using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_ALERTA
    {
        [Key]
        public int AlCodigoN { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_AlColeccionS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlColeccionS { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_AlMarcaS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlMarcaS { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_AlLineaS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlLineaS { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_AlReferenciaS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlReferenciaS { get; set; }

        [MaxLength(300)]
        [Display(Name = "text_AlDescripcionS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlDescripcionS { get; set; }

        [MaxLength(10)]
        [Display(Name = "text_AlEstadoS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlEstadoS { get; set; }

        [MaxLength(20)]
        [Display(Name = "text_AlAreaS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlAreaS { get; set; }

        [Display(Name = "text_AlFechaD", ResourceType = typeof(Resources.Alertas.Index))]
        public DateTime AlFechaD { get; set; }

        [MaxLength(100)]
        [Display(Name = "text_AlCambioS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlCambioS { get; set; }

        [Display(Name = "text_AlValorAnteriorMS", ResourceType = typeof(Resources.Alertas.Index))]
        public decimal AlValorAnteriorM { get; set; }

        [Display(Name = "text_AlValorActualM", ResourceType = typeof(Resources.Alertas.Index))]
        public decimal AlValorActualM { get; set; }

        [Display(Name = "text_AlVariacionM", ResourceType = typeof(Resources.Alertas.Index))]
        public decimal AlVariacionM { get; set; }

        [MaxLength(50)]
        [Display(Name = "text_AlUsuarioS", ResourceType = typeof(Resources.Alertas.Index))]
        public string AlUsuarioS { get; set; }

        [MaxLength(50)]
        public string AlLeidoS { get; set; }
    }
}