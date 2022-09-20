using System.Collections.Generic;
using HospiEnCasa.App.Dominio;
using System.Linq;
using Microsoft.EntityFrameworkCore;
namespace HospiEnCasa.App.Persistencia
{
    public class RepositorioPaciente : IRepositorioPaciente
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
        public RepositorioPaciente(AppContext appContext)
        {
            _appContext = appContext;
        }

        ////    CON CAMBIOS PARA EL CRUD DB     //////
        Paciente IRepositorioPaciente.AddPaciente(Paciente paciente)
        {
            var pacienteAdicionado = _appContext.Pacientes.Add(paciente);
            _appContext.SaveChanges();
            return pacienteAdicionado.Entity; //CASTING PUEDE GENERAR ERROR
        }

        void IRepositorioPaciente.DeletePaciente(int idPaciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado == null)
                return;
            _appContext.Pacientes.Remove(pacienteEncontrado);
            _appContext.SaveChanges();
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetAllPacientes()
        {
            return (IEnumerable<Paciente>)_appContext.Pacientes;
        }

        Paciente IRepositorioPaciente.GetPaciente(int Id)
        {
            return _appContext.Pacientes.FirstOrDefault(p => p.Id == Id);
        }
        ////    CON CAMBIOS PARA EL CRUD DB     //////
        Paciente IRepositorioPaciente.UpdatePaciente(Paciente paciente)
        {
            var pacienteEncontrado = _appContext.Pacientes.SingleOrDefault(r => r.Id == paciente.Id);
            if (paciente != null)
            {
                pacienteEncontrado.Nombre = paciente.Nombre;
                pacienteEncontrado.Apellidos = paciente.Apellidos;
                pacienteEncontrado.NumeroTelefono = paciente.NumeroTelefono;
                //pacienteEncontrado.Genero=paciente.Genero;
                pacienteEncontrado.Direccion = paciente.Direccion;
                // pacienteEncontrado.Latitud=paciente.Latitud;
                // pacienteEncontrado.Longitud=paciente.Longitud;
                pacienteEncontrado.Ciudad = paciente.Ciudad;
                pacienteEncontrado.FechaNacimiento = paciente.FechaNacimiento;
                pacienteEncontrado.Familiar = paciente.Familiar;
                pacienteEncontrado.Enfermera = paciente.Enfermera;
                pacienteEncontrado.Medico = paciente.Medico;
                pacienteEncontrado.Historia = paciente.Historia;
                _appContext.SaveChanges();
            }
            return pacienteEncontrado;
        }

        Medico IRepositorioPaciente.AsignarMedico(int idPaciente, int idMedico)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var medicoEncontrado = _appContext.Medicos.FirstOrDefault(m => m.Id == idMedico);
                if (medicoEncontrado != null)
                {
                    pacienteEncontrado.Medico = medicoEncontrado;
                    _appContext.SaveChanges();
                    return medicoEncontrado;
                }
                else
                {
                    Console.WriteLine("Ya tiene un medico asignado.");
                }
            }
            return null;
        }

        Enfermera IRepositorioPaciente.AsignarEnfermera(int idPaciente, int idEnfermera)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var enfermeraEncontrada = _appContext.Enfermeras.FirstOrDefault(e => e.Id == idEnfermera);
                if (enfermeraEncontrada != null)
                {
                    pacienteEncontrado.Enfermera = enfermeraEncontrada;
                    _appContext.SaveChanges();
                    return enfermeraEncontrada;
                }
                else
                {
                    Console.WriteLine("Ya tiene una enfermera asignada.");
                }
            }
            return null;
        }

        FamiliarDesignado IRepositorioPaciente.AsignarFamiliar(int idPaciente, int idFamiliar)
        {
            var pacienteEncontrado = _appContext.Pacientes.FirstOrDefault(p => p.Id == idPaciente);
            if (pacienteEncontrado != null)
            {
                var familiarEncontrado = _appContext.FamiliaresDesignados.FirstOrDefault(f => f.Id == idFamiliar);
                if (familiarEncontrado != null)
                {
                    pacienteEncontrado.Familiar = familiarEncontrado;
                    _appContext.SaveChanges();
                    return familiarEncontrado;
                }
                else
                {
                    Console.WriteLine("Ya tiene un familiar asignado.");
                }
            }
            return null;
        }

        public IEnumerable<Paciente> GetPacientesRC()
        {
            return _appContext.Pacientes.
                                Where(p => p.SignosVitales.Any
                                (s => TipoSigno.FrecuenciaCardiaca == s.Signo && s.Valor >= 90))
                                .ToList();
        }

        public IEnumerable<Paciente> FiltroNombres(string nombre)
        {
            try
            {
                // var filtro = "%" + nombre + "%";
                Console.WriteLine(nombre);
                return _appContext.Pacientes.Where(p => p.Nombre.Contains(nombre) || p.Apellidos.Contains(nombre));
            }
            catch (Exception e)
            {
                Console.WriteLine("Error al filtrar por nombres");
                return null;
            }
            
        }

        IEnumerable<Paciente> IRepositorioPaciente.GetMalePacientes()
        {
            return _appContext.Pacientes.Where(p => p.Genero == Genero.masculino).ToList();
        }

        IEnumerable<SignoVital> IRepositorioPaciente.GetSVs(int Id){
            var paciente = _appContext.Pacientes.Where(s => s.Id==Id)
                                                .Include(s=> s.SignosVitales)
                                                .FirstOrDefault();
            return paciente.SignosVitales;
        }

    }
}