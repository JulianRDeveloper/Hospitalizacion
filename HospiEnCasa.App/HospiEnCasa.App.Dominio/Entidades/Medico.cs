using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio{
    public class Medico: Persona{
        //public int Id{get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="La dirrecion es demaciado larga")]
        [MinLength(3, ErrorMessage="La direccion es demaciado corta")]
        public string Especialidad {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(10, ErrorMessage="La dirrecion es demaciado larga")]
        [MinLength(5, ErrorMessage="La direccion es demaciado corta")]
        public string Codigo {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(20, ErrorMessage="La dirrecion es demaciado larga")]
        [MinLength(7, ErrorMessage="La direccion es demaciado corta")]
        public string RegistroRethus {get;set;}
    }
}