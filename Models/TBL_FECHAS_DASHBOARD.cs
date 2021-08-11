using System.ComponentModel.DataAnnotations;

namespace AppWebHojaCosto.Models
{
    public class TBL_FECHAS_DASHBOARD
    {
        [Key]
        public int FdCodigoN { get; set; }

        public string FdMarcaS { get; set; }

        public string FdColeccionS { get; set; }

        //[Required]
        public string FdTipoInventarioS { get; set; }

        //[Required]
        //public string FdUsuarioS { get; set; }
        public string FdSemana1S { get; set; }
        public string FdSemana2S { get; set; }
        public string FdSemana3S { get; set; }
        public string FdSemana4S { get; set; }
        public string FdSemana5S { get; set; }
        public string FdSemana6S { get; set; }
        public string FdSemana7S { get; set; }
        public string FdSemana8S { get; set; }
        public string FdSemana9S { get; set; }
        public string FdSemana10S { get; set; }
        //public string FdRefAprobadas1S { get; set; }
        //public string FdRefAprobadas2S { get; set; }
        //public string FdRefAprobadas3S { get; set; }
        //public string FdRefAprobadas4S { get; set; }
        //public string FdRefAprobadas5S { get; set; }
        //public string FdRefAprobadas6S { get; set; }
        //public string FdRefAprobadas7S { get; set; }
        //public string FdRefAprobadas8S { get; set; }
        //public string FdRefAprobadas9S { get; set; }
        //public string FdRefAprobadas10S { get; set; }
    }
}