using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class PacientesModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        public IEnumerable<Paciente> ListPacientes {get;set;}
        public PacientesModel(IRepositorioPaciente repositorio_Paciente){
            _repoPaciente=repositorio_Paciente;
        }

        public void OnPost(){
            ListPacientes=_repoPaciente.GetAllPacientes();
        }
        public void OnGet()
        {
            ListPacientes=_repoPaciente.GetAllPacientes();
        }
    }
}
