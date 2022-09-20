using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio{
    public class Medico: Persona{
        //public int Id{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(3, ErrorMessage="El registro es demaciado corto.")]
        public string Especialidad {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(10, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(5, ErrorMessage="El registro es demaciado corto.")]
        public string Codigo {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(7, ErrorMessage="El registro es demaciado corto.")]
        public string RegistroRethus {get;set;}
    }
}