using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using HospiEnCasa.App.Dominio;
using HospiEnCasa.App.Persistencia;

namespace HospiEnCasa.App.Frontend.Pages
{
    public class PacientesModel : PageModel
    {
        private readonly IRepositorioPaciente _repoPaciente;
        // [BindProperty]
        // public Paciente Paciente {get;set;}
        public IEnumerable<Paciente> ListPacientes {get;set;}
        public IEnumerable<Paciente> FindedPacientes {get;set;}
        public string findBar {get;set;}
        public Paciente Paciente {get;set;}
        public PacientesModel(IRepositorioPaciente repositorio_Paciente){
            _repoPaciente=repositorio_Paciente;
        }

        public void OnGet()
        {
            if(FindedPacientes==null){
                ListPacientes=_repoPaciente.GetAllPacientes();
            }
            //return Page();           
        }

         public IActionResult OnPost(string? busqueda){
            //ListPacientes=_repoPaciente.GetAllPacientes();
            Console.WriteLine(busqueda);
            if(busqueda!=null){
                FindedPacientes= _repoPaciente.FiltroNombres(busqueda);
            }
            return Page();
        }
    }
}
