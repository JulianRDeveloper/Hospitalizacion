using System;

namespace HospiEnCasa.App.Dominio{
    public class Enfermera:Persona{
        //public int Id {get;set;} //Puede generar conflictos con Persona..
        public String TarjetaProfesional {get;set;}
        public int HorasLaborables {get;set;}
    }
}