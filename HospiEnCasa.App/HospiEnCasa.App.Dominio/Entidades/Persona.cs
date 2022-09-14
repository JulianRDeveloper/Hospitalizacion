using System.ComponentModel.DataAnnotations;
using System;

namespace HospiEnCasa.App.Dominio{
    public class Persona{
        public int Id { get; set; }

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage="El nombre es demaciado largo")]
        [MinLength(2, ErrorMessage="El nombre es demaciado corto")]
        public String Nombre { get; set; }

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage="El apellido es demaciado largo")]
        [MinLength(7, ErrorMessage="El apellido es demaciado corto")]
        public String Apellidos { get; set; }

        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage="El numero es demaciado largo")]
        [MinLength(7, ErrorMessage="El numero es demaciado corto")]
        public String NumeroTelefono { get; set; }
        
        [Required(ErrorMessage="Este campo es obligatorio")]
        // [RegularExpression("[m,a,s,c,u,l,i,n,o,f,e,n]", ErrorMessage="Debe digitar el registro como lo muestra el ejemplo.")]
        // [MaxLength(9, ErrorMessage="Debe digitar el registro como lo muestra el ejemplo.")]
        // [MinLength(8, ErrorMessage="Debe digitar el registro como lo muestra el ejemplo.")]
        public Genero Genero { set; get; }
        
    }
}