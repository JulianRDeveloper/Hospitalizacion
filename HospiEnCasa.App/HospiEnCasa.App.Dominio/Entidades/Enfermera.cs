using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio{
    public class Enfermera:Persona{

        //public int Id {get;set;} //Puede generar conflictos con Persona..
        [Required(ErrorMessage="Este campo es obligatorio.")]
        [MaxLength(15, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(7, ErrorMessage="El registro es demaciado corto.")]
        public String TarjetaProfesional {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio.")]
        [Range(60, 99999, ErrorMessage="El minimo de horas laborables es 60.")]
        public int HorasLaborables {get;set;}
    }
}