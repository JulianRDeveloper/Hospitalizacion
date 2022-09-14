using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class DetailsModel : PageModel
    {
        //  INSTANCIAMIENTO REPOSITORIOS
        private readonly IRepositorioPaciente _repoPaciente;
        private readonly IRepositorioMedico _repoMedico;
        private readonly IRepositorioEnfermera _repoNurse;
        private readonly IRepositorioFamiliarDesignado _repoFamiliar;
        
        //  INSTANCIAMIENTO ENTIDADES
        public Paciente Paciente {get;set;}
        public Medico Medico {get;set;}
        public Enfermera Enfermera {get;set;}
        public FamiliarDesignado Familiar {get;set;}

        //  INYECCION DE REPOSITORIOS
        public DetailsModel(
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

        public IActionResult OnGet(int Id){
            Paciente= _repoPaciente.GetPaciente(Id);
            Medico= _repoMedico.GetMedico(Id);
            Enfermera= _repoNurse.GetEnfermera(Id);
            Familiar= _repoFamiliar.GetFamiliar(Id);
            return Page();
        }
    }
}
