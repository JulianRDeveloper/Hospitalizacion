using System;
using HospiEnCasa.App.Dominio;
using System.ComponentModel.DataAnnotations;


namespace HospiEnCasa.App.Dominio{
    public class Paciente:Persona{
        //public int Id {get;set;}
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(50, ErrorMessage="La dirrecion es demaciado larga")]
        [MinLength(2, ErrorMessage="La direccion es demaciado corta")]
        public String Direccion { get; set; }
        
        // [Required(ErrorMessage="Este campo es obligatorio")]
        public double Latitud { get; set; }

        // [Required(ErrorMessage="Este campo es obligatorio")]
        public double Longitud { get; set; }
        
        [Required(ErrorMessage="Este campo es obligatorio")]
        [MaxLength(15, ErrorMessage="El nombre demaciado corto")]
        [MinLength(2, ErrorMessage="El nombre es demaciado corto")]
        public String Ciudad { get; set; }
        
        [Required(ErrorMessage="Este campo es obligatorio")]
        public DateTime FechaNacimiento { get; set; }
        

        public List<SignoVital> SignosVitales {get;set;} //Aregado por mi
        public FamiliarDesignado Familiar {get; set;}
        public Enfermera Enfermera {get;set;}
        public Medico Medico {get; set;}
        public Historia Historia {get; set;}
    }
}