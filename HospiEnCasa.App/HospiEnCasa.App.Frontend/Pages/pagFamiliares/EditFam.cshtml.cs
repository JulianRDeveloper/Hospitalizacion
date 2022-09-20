using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class EditFamModel : PageModel
    {
//  INSTANCIAMIENTO REPOSITORIOS
        // private readonly IRepositorioPaciente _repoPaciente;
        // private readonly IRepositorioMedico _repoMedico;
        // private readonly IRepositorioEnfermera _repoNurse;
        private readonly IRepositorioFamiliarDesignado _repoFamiliar;
        
        //  INSTANCIAMIENTO ENTIDADES
        // [BindProperty]
        // public Paciente Paciente {get;set;}
        [BindProperty]
        // public Medico Medico {get;set;}
        // public Enfermera Enfermera {get;set;}
        public FamiliarDesignado Familiar {get;set;}
        //public JSInteropClasses1 alerta {get;set;}

        //  INYECCION DE REPOSITORIOS
        public EditFamModel(IRepositorioFamiliarDesignado repositorioFamiliar)
            {
                // _repoPaciente=repositorioPaciente;
                // _repoMedico=repositorioMedico;
                // _repoNurse=repositorioEnfermera;
                _repoFamiliar=repositorioFamiliar;
            }

        public IActionResult OnGet(int? Id){
            if(Id.HasValue){
                //Paciente= _repoPaciente.GetPaciente(Id.Value);
                // Medico= _repoMedico.GetMedico(Id.Value);
                // Enfermera= _repoNurse.GetEnfermera(Id.Value);
                Familiar= _repoFamiliar.GetFamiliar(Id.Value);
            }else{
                // Paciente=new Paciente();
                // Medico=new Medico();
                // Enfermera=new Enfermera();
                Familiar= new FamiliarDesignado();
            }
            return Page();
        }

        public IActionResult OnPost(){
            if(!ModelState.IsValid){
                return Page();
            }
            try{
                if(Familiar.Id>0){Familiar= _repoFamiliar.UpdateFamiliar(Familiar);}else{_repoFamiliar.AddFamiliar(Familiar);}
            }catch(Exception){
                Console.WriteLine("not Familiar");
            }
            return Page();
        }
    }
}
