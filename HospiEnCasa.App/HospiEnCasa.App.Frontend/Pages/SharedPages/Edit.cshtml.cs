using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class EditModel : PageModel
    {
        //  INSTANCIAMIENTO REPOSITORIOS
        private readonly IRepositorioPaciente _repoPaciente;
        private readonly IRepositorioMedico _repoMedico;
        private readonly IRepositorioEnfermera _repoNurse;
        private readonly IRepositorioFamiliarDesignado _repoFamiliar;
        
        //  INSTANCIAMIENTO ENTIDADES
        [BindProperty]
        public Paciente Paciente {get;set;}
        public Medico Medico {get;set;}
        public Enfermera Enfermera {get;set;}
        public FamiliarDesignado Familiar {get;set;}

        //  INYECCION DE REPOSITORIOS
        public EditModel(
            IRepositorioPaciente repositorioPaciente, 
            IRepositorioMedico repositorioMedico,
            IRepositorioEnfermera repositorioEnfermera,
            IRepositorioFamiliarDesignado repositorioFamiliar)
            {
                _repoPaciente=repositorioPaciente;
                _repoMedico=repositorioMedico;
                _repoNurse=repositorioEnfermera;
                _repoFamiliar=repositorioFamiliar;
            }

        public IActionResult OnGet(int? Id){
            if(Id.HasValue){
                Paciente= _repoPaciente.GetPaciente(Id.Value);
                Medico= _repoMedico.GetMedico(Id.Value);
                Enfermera= _repoNurse.GetEnfermera(Id.Value);
                Familiar= _repoFamiliar.GetFamiliar(Id.Value);
            }else{
                Paciente=new Paciente();
                Medico=new Medico();
                Enfermera=new Enfermera();
                Familiar= new FamiliarDesignado();
            }
            return Page();
        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            try{
                if(Paciente.Id>0){Paciente= _repoPaciente.UpdatePaciente(Paciente);}else{_repoPaciente.AddPaciente(Paciente);}
            }catch(Exception){
                Console.WriteLine("not Paciente");
            }
            try{
                if(Medico.Id>0){Medico= _repoMedico.UpdateMedico(Medico);}else{_repoMedico.AddMedico(Medico);}
            }catch(Exception){
                Console.WriteLine("not Medico");
            }
            try{
                if(Enfermera.Id>0){Enfermera= _repoNurse.UpdateEnfermera(Enfermera);}else{_repoNurse.AddEnfermera(Enfermera);}
            }catch(Exception){
                Console.WriteLine("not Nurse");
            }
            try{
                if(Familiar.Id>0){Familiar= _repoFamiliar.UpdateFamiliar(Familiar);}else{_repoFamiliar.AddFamiliar(Familiar);}
            }catch(Exception){
                Console.WriteLine("not Family");
            }
            return Page();     
        }
    }
}
