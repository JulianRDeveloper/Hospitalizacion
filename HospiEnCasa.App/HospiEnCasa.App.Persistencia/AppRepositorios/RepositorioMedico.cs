using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioMedico : IRepositorioMedico
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
        public RepositorioMedico(AppContext appContext){
            _appContext=appContext;
        }
        
        Medico IRepositorioMedico.AddMedico(Medico medico)
        {
            var medicoAdicionado= _appContext.Medicos.Add(medico);
            _appContext.SaveChanges();
            return medicoAdicionado.Entity; 
        }

        void IRepositorioMedico.DeleteMedico(int idMedico) // ojo con la posicion del return
        {
            var MedicoEncontrado= _appContext.Medicos.FirstOrDefault(p=>p.Id==idMedico);
            if(MedicoEncontrado==null)
                return;
            _appContext.Medicos.Remove(MedicoEncontrado); 
            _appContext.SaveChanges();
        }

        IEnumerable<Medico> IRepositorioMedico.GetAllMedicos()
        {
            return (IEnumerable<Medico>)_appContext.Medicos;
        }

        Medico IRepositorioMedico.GetMedico(int idMedico)
        {
            return _appContext.Medicos.FirstOrDefault(p=> p.Id == idMedico);
        }

        Medico IRepositorioMedico.UpdateMedico(Medico medico)
        {
            var MedicoEncontrado = _appContext.Medicos.SingleOrDefault(p=> p.Id == medico.Id);
            if(MedicoEncontrado!=null){
                MedicoEncontrado.Nombre=medico.Nombre;
                MedicoEncontrado.Apellidos=medico.Apellidos;
                MedicoEncontrado.NumeroTelefono=medico.NumeroTelefono;
                MedicoEncontrado.Genero=medico.Genero;
                MedicoEncontrado.Especialidad=medico.Especialidad;
                MedicoEncontrado.Codigo=medico.Codigo;
                MedicoEncontrado.RegistroRethus=medico.RegistroRethus;
                
                _appContext.SaveChanges();
            }
            return MedicoEncontrado;
        }
    }
}