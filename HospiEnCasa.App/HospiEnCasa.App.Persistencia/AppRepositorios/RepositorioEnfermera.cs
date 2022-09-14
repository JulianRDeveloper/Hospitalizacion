using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioEnfermera : IRepositorioEnfermera
    {
        // <summary>
        // Referencia al contexto del paciente
        // </summary>
        private readonly AppContext _appContext;
        // <summary>
        // Metodo constructor que utiliza
        // Inyeccion de dependencias para indicar el contexto a utilizar
        // </summary>
        // <param name="appContext"></param>//
        public RepositorioEnfermera(AppContext appContext){
            _appContext=appContext;
        }
        
        Enfermera IRepositorioEnfermera.AddEnfermera(Enfermera enfermera)
        {
            var EnfermeraAdicionado= _appContext.Enfermeras.Add(enfermera);
            _appContext.SaveChanges();
            return EnfermeraAdicionado.Entity; 
        }

        void IRepositorioEnfermera.DeleteEnfermera(int idEnfermera) // ojo con la posicion del return
        {
            var EnfermeraEncontrado= _appContext.Enfermeras.FirstOrDefault(p=>p.Id==idEnfermera);
            if(EnfermeraEncontrado==null)
                return;
            _appContext.Enfermeras.Remove(EnfermeraEncontrado); 
            _appContext.SaveChanges();
        }

        IEnumerable<Enfermera> IRepositorioEnfermera.GetAllEnfermeras()
        {
            return (IEnumerable<Enfermera>)_appContext.Enfermeras;
        }

        Enfermera IRepositorioEnfermera.GetEnfermera(int idEnfermera)
        {
            return _appContext.Enfermeras.FirstOrDefault(p=> p.Id == idEnfermera);
        }

        Enfermera IRepositorioEnfermera.UpdateEnfermera(Enfermera enfermera)
        {
            var EnfermeraEncontrado = _appContext.Enfermeras.FirstOrDefault(p=> p.Id == enfermera.Id);
            if(EnfermeraEncontrado!=null){
                EnfermeraEncontrado.Nombre=enfermera.Nombre;
                EnfermeraEncontrado.Apellidos=enfermera.Apellidos;
                EnfermeraEncontrado.NumeroTelefono=enfermera.NumeroTelefono;
                EnfermeraEncontrado.Genero=enfermera.Genero;

                EnfermeraEncontrado.TarjetaProfesional=enfermera.TarjetaProfesional;
                EnfermeraEncontrado.HorasLaborables=enfermera.HorasLaborables;

                _appContext.SaveChanges();
            }
            return EnfermeraEncontrado;
        }
    }
}