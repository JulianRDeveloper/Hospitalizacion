using System;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Consola{

class Program{
    
    private static IRepositorioPaciente _repoPaciente= new RepositorioPaciente(new Persistencia.AppContext());
    private static IRepositorioMedico _repoMedico= new RepositorioMedico(new Persistencia.AppContext());
    private static IRepositorioEnfermera _repoEnfermera = new RepositorioEnfermera(new Persistencia.AppContext());
    private static IRepositorioFamiliarDesignado _repoFamiliar = new RepositorioFamiliarDesignado(new Persistencia.AppContext());
    static void Main(string[] args){
        Console.WriteLine("Hello, World EF!");
        //AddPaciente();
        //BuscarPaciente(6);
        //AddMedico();
        //BuscarMedico(7);
        //AddEnfermera();
        //BuscarEnfermera(8);
        //AddFamiliar();
        //BuscarFamiliar(9);
        //AsignarMedico(6,7);
        //AsignarEnfermera(6,8);
        //AsignarFamiliar(6,9);
        //GetAllPacientes();
        AddPacienteFull();
        //AddSignosPaciente(12);
        
    }
    private static void AddPaciente(){
        var paciente = new Paciente{
            Nombre = "Nicolay",
            Apellidos= "Perez",
            NumeroTelefono= "300164500",
            Genero= Genero.masculino,
            Direccion= "Calle 4 No 74-44",
            Longitud= 5.07062F,
            Latitud= -75.52290F,
            Ciudad= "Manizales",
            FechaNacimiento = new DateTime(1990, 04, 12)
        };
        _repoPaciente.AddPaciente(paciente);
    }

    private static void AddPacienteFull(){
        var paciente = new Paciente{
            Nombre= "Lina",
            Apellidos= "Romero",
            NumeroTelefono= "(8)6700915",
            Genero= Genero.femenino,
            Direccion= "Barrio El Buque, Norte",
            Longitud= 2.03531F,
            Latitud= -45.26150F,
            Ciudad= "Villavicencio",
            FechaNacimiento= new DateTime(1990, 02, 6),
            SignosVitales= new List<SignoVital> {
                new SignoVital{FechaHora= new DateTime(2022,09,9,10,20,0),Valor=29,Signo=TipoSigno.TemperaturaCorporal},
                new SignoVital{FechaHora= new DateTime(2022,09,9,10,22,0),Valor=94,Signo=TipoSigno.SaturacionOxigeno},
                new SignoVital{FechaHora= new DateTime(2021,09,9,10,25,0),Valor=88,Signo=TipoSigno.FrecuenciaCardiaca}
            },
            Historia= new Historia{
                Diagnostico= "COVID",
                Entorno="En Casa",
                Sugerencias= new List<SugerenciaCuidado> {
                    new SugerenciaCuidado{FechaHora= new DateTime(2022,09,9,10,35,0),Descripcion="Actualizar SVs cada 4horas."},
                    new SugerenciaCuidado{FechaHora= new DateTime(2022,09,9,10,37,0),Descripcion="Elevacion de la cama 80°"}
            }}
        };
        _repoPaciente.AddPaciente(paciente);
    }
    private static void BuscarPaciente(int idPaciente){
        var paciente= _repoPaciente.GetPaciente(idPaciente);
        Console.WriteLine("Paciente : "+paciente.Nombre+" "+paciente.Apellidos);
    }



    private static void AddMedico(){
        var medico = new Medico{
            Nombre = "Daniela",
            Apellidos= "Lopez",
            NumeroTelefono= "3021645001",
            Genero= Genero.femenino,
            Especialidad= "Cardiologia",
            Codigo= "MED-0101",
            RegistroRethus= "CAR-21545-125"
        };
        _repoMedico.AddMedico(medico);
    }
    private static void BuscarMedico(int idMedico){
        var medico= _repoMedico.GetMedico(idMedico);
        Console.WriteLine("Doctor(a) : "+medico.Nombre+" "+medico.Apellidos);
    }
    private static void AddEnfermera(){
            var enfermera = new Enfermera{
            Nombre = "Azuzena",
            Apellidos= "Cardenas",
            NumeroTelefono= "3107671368",
            Genero= Genero.femenino,

            TarjetaProfesional= "14525878-84",
            HorasLaborables = 32
            };
            _repoEnfermera.AddEnfermera(enfermera);
    }
    private static void BuscarEnfermera(int idEnfermera){
        var enfermera= _repoEnfermera.GetEnfermera(idEnfermera);
        Console.WriteLine("Enfermera : "+enfermera.Nombre+" "+enfermera.Apellidos);
    }
    private static void AddFamiliar(){
        var familiar = new FamiliarDesignado{
            Nombre = "Carlos",
            Apellidos= "Perez",
            NumeroTelefono= "3158457477",
            Genero= Genero.masculino,

            Parentesco= "Hermano",
            Correo= "el_hermano@micorreo.com"
        };
        _repoFamiliar.AddFamiliar(familiar);
    }

    private static void AddSignosPaciente(int idPaciente){
        var paciente= _repoPaciente.GetPaciente(idPaciente);
        if(paciente!=null){
            if(paciente.SignosVitales!=null){
                paciente.SignosVitales.Add(new SignoVital{FechaHora= new DateTime(2022,09,10,16,50,0),Valor=31,Signo=TipoSigno.TemperaturaCorporal});
                paciente.SignosVitales.Add(new SignoVital{FechaHora= new DateTime(2022,09,10,16,52,0),Valor=96,Signo=TipoSigno.SaturacionOxigeno});
                paciente.SignosVitales.Add(new SignoVital{FechaHora= new DateTime(2021,09,10,16,55,0),Valor=90,Signo=TipoSigno.FrecuenciaCardiaca});
            }else{
                paciente.SignosVitales= new List<SignoVital>{
                    new SignoVital{FechaHora= new DateTime(2022,09,10,16,50,0),Valor=31,Signo=TipoSigno.TemperaturaCorporal},
                    new SignoVital{FechaHora= new DateTime(2022,09,10,16,52,0),Valor=96,Signo=TipoSigno.SaturacionOxigeno},
                    new SignoVital{FechaHora= new DateTime(2021,09,10,16,55,0),Valor=90,Signo=TipoSigno.FrecuenciaCardiaca} 
                };
            }
            _repoPaciente.UpdatePaciente(paciente);
        }
    }
    private static void BuscarFamiliar(int idFamiliar){
        var familiar = _repoFamiliar.GetFamiliar(idFamiliar);
        Console.WriteLine("Familiar : "+familiar.Nombre+" "+familiar.Apellidos+" / Parentesco: "+familiar.Parentesco);
    }

    private static void AsignarMedico(int idPaciente, int idMedico){
        var medico= _repoPaciente.AsignarMedico(idPaciente, idMedico);
        Console.WriteLine("Medico Asignado: "+medico.Nombre+" "+medico.Apellidos);
    }

    private static void AsignarEnfermera(int idPaciente, int idEnfermera){
        var enfermera= _repoPaciente.AsignarEnfermera(idPaciente, idEnfermera);
        Console.WriteLine("Enfermera Asignada: "+enfermera.Nombre+" "+enfermera.Apellidos);
    }

    private static void AsignarFamiliar(int idPaciente, int idFamiliar){
        var familiar= _repoPaciente.AsignarFamiliar(idPaciente, idFamiliar);
        Console.WriteLine("Familiar Designado(a): "+familiar.Nombre+" "+familiar.Apellidos);
    }

    private static void GetAllPacientes(){
        var pacientes= _repoPaciente.GetAllPacientes();
        foreach (var paciente in pacientes)
        {
            Console.WriteLine(paciente.Nombre);
            Console.WriteLine(paciente.Apellidos);
            Console.WriteLine(paciente.FechaNacimiento);
        }
        //Console.WriteLine(pacientes);
    }

}
}
