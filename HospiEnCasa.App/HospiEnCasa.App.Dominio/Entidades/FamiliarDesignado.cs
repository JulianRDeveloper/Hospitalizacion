using System;
using System.ComponentModel.DataAnnotations;

namespace HospiEnCasa.App.Dominio{
    public class FamiliarDesignado:Persona{
        //public int Id {get;set;}
        
        [Required(ErrorMessage="Este campo es obligatorio.")]
        [MaxLength(15, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(3, ErrorMessage="El registro es demaciado corto.")]
        public string Parentesco {get;set;}

        [Required(ErrorMessage="Este campo es obligatorio.")]
        [MaxLength(30, ErrorMessage="El registro es demaciado largo.")]
        [MinLength(3, ErrorMessage="El registro es demaciado corto.")]
        [EmailAddress(ErrorMessage="Debe ingresar una direccion de E-mail.")]
        public string Correo {get;set;}
        //public int PacienteId {get;set;} //adherido por mi
    }
}